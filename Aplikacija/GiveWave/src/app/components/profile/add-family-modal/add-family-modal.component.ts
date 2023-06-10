import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { uploadPhoto } from 'app/Models/uploadPhoto';
import { AuthService } from 'app/services/auth.service';
import { DonateService } from 'app/components/donate/donate.service';
import { ProductService } from 'app/components/products/product.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FamilyHelper } from 'app/Models/FamilyHelper';

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
      najpotrebnijestvari:new FormArray([]),
      opis:['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.productService.getCities().subscribe(c => this.cities = c);
  }
  get najpotrebnijestvari(): FormArray {
    return this.addFamilyForm.get('najpotrebnijestvari') as FormArray;
  }
  addItem() {
    const newItem = this.fb.control('', Validators.required);
    this.najpotrebnijestvari.push(newItem);
  }
  removeItem(index: number) {
    this.najpotrebnijestvari.removeAt(index);
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

  addFamily()
  {
    if(this.addFamilyForm.valid)
    {
      //za dodavanjNewType
      const family:FamilyHelper = this.addFamilyForm.value;
      family.email = this.authService.email;
      console.log(family);
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
