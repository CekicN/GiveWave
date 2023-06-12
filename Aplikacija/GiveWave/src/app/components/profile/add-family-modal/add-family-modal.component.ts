import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { uploadPhoto } from 'app/Models/uploadPhoto';
import { AuthService } from 'app/services/auth.service';
import { DonateService } from 'app/components/donate/donate.service';
import { ProductService } from 'app/components/products/product.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FamilyHelper } from 'app/Models/FamilyHelper';
import { Porodica } from 'app/Models/Porodica';

@Component({
  selector: 'app-add-family-modal',
  templateUrl: './add-family-modal.component.html',
  styleUrls: ['./add-family-modal.component.css']
})
export class AddFamilyModalComponent implements OnInit {

  displayStyle:string = '';
  familyId!:number;
  cities!:any;
  imageUrl:string[] = ["https://localhost:7200//uploads/common/noimage.png"];
  addFamilyForm!:FormGroup;

  get supplies():FormArray
  {
    return this.addFamilyForm.get('supplies') as FormArray;
  }

  constructor(private profileService:ProfileService,
              private authService:AuthService,
              private donateService:DonateService,
              private productService:ProductService,
              private cdr:ChangeDetectorRef,
              private fb:FormBuilder)
  {
    profileService.displayFamilyModal.subscribe(p => this.displayStyle = p);
    profileService.familyId.subscribe(p => this.familyId = p);
    this.addFamilyForm = fb.group({
      naziv:['', Validators.required],
      brClanova:['', Validators.required],
      grad:['', Validators.required],
      adresa:['', Validators.required],
      supplies:this.fb.array([]),
      opis:['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.productService.getCities().subscribe(c => this.cities = c);
    this.addItem();
  }
  addItem() {
    this.supplies.push(this.build());
  }
  build():FormGroup
  {
    return this.fb.group({
      supply:new FormControl('',[Validators.required])
    })
  }
  removeItem() {
    this.supplies.removeAt(this.supplies.length - 1);
  }
  addPhotos(event:Event)
  {
    const files = (<HTMLInputElement>event.target).files;
    if(files)
    {
      const upload:uploadPhoto = {
        id:this.familyId,
        email:this.authService.email,
        files:Array.from(files)
      } 
      this.donateService.updatePhoto(upload).subscribe((res:any) => {
        this.imageUrl = res.imageUrls
        this.cdr.detectChanges();
      });
    }
  }
  closeModal()
  {
    this.donateService.cancelAdding(this.familyId, this.authService.email).subscribe(msg => console.log(msg));
    this.imageUrl = ["https://localhost:7200//uploads/common/noimage.png"];
    this.addFamilyForm.reset();
    this.profileService.closeFamilyModal();
  }

  omit(obj: any, field: string) {
    const { [field]: _, ...rest } = obj;
    return rest;
  }

  addFamily()
  {
    if(this.addFamilyForm.valid)
    {
      //za dodavanjNewType
      let data:any = this.addFamilyForm.value;
      let porodica:FamilyHelper = this.addFamilyForm.value;
      porodica = this.omit(porodica, 'supplies');
      porodica.najpotrebnijestvari = data.supplies.map((obj:any) => obj.supply);
      porodica.email = this.authService.email;

      console.log(porodica);
      this.donateService.addFamily(porodica, this.familyId).subscribe(p => {
        this.imageUrl = ["https://localhost:7200//uploads/common/noimage.png"];
        this.addFamilyForm.reset();
        this.profileService.closeFamilyModal();
      });
    }  
    else
    {
      this.validateAllFormsFields(this.addFamilyForm);
      this.cdr.detectChanges();
    }
  }
  private validateAllFormsFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({
          onlySelf:true
        });
      }else if(control instanceof FormGroup){
        this.validateAllFormsFields(control);
      }
    })

  }
}
