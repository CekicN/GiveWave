import { Component, OnInit } from '@angular/core';
import { DonateService } from '../donate.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DonationHelper } from 'app/Models/DonationHelper';
import { AuthService } from 'app/services/auth.service';
import { Porodica } from 'app/Models/Porodica';

@Component({
  selector: 'app-donate-modal',
  templateUrl: './donate-modal.component.html',
  styleUrls: ['./donate-modal.component.css']
})
export class DonateModalComponent implements OnInit{
  displayStyle!:string
  familyId!:number;
  donateForm!:FormGroup;
  supp!:string[];
  family!:Porodica|null;
  constructor(private service:DonateService, private library:FaIconLibrary, private fb:FormBuilder, private authService:AuthService){
    service.donateFamily.subscribe(p => this.displayStyle = p);
    service.family.subscribe(p => this.family = p);
    service.familyId.subscribe(p => {
      this.familyId = p;
      this.service.getSupplies(this.familyId).subscribe((q:string[]) => 
      {
        this.supp = q;
        q.forEach(p => this.addItem());
      });
    });
    library.addIcons(faXmark);

    this.donateForm = fb.group({
      supplies:this.fb.array([]),
      opis:['', Validators.required]
    })
  }
  ngOnInit(): void {
  }

  get supplies():FormArray
  {
    return this.donateForm.get('supplies') as FormArray;
  }

  addItem() {
    this.supplies.push(this.build());
  }
  build():FormGroup
  {
    return this.fb.group({
      supply:''
    })
  }

  closeModal()
  {
    this.service.closeModal();
  }

  omit(obj: any, field: string) {
    const { [field]: _, ...rest } = obj;
    return rest;
  }

  donate()
  {
    if(this.donateForm.valid)
    {
      console.log(this.donateForm.value)
      let data:any = this.donateForm.value;
      let donacija:DonationHelper = this.donateForm.value;
      donacija = this.omit(donacija, 'supplies');
      let d = data.supplies.map((obj:any) => obj.supply);
      let s:string[] = [];
      this.supp.forEach((p, i) => {
        if(d[i] == true)
          s.push(p)
      })
      donacija.donacija = s;
      donacija.email = this.authService.email;
      donacija.idPorodice = this.familyId;
      console.log(donacija);

      this.service.donate(donacija).subscribe(q => {
        this.service.closeModal();
        this.donateForm.reset();
      });
    }
    else
    {
      this.validateAllFormsFields(this.donateForm);
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
