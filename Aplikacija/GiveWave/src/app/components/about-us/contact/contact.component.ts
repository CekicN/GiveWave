import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faFacebook, faInstagram } from '@fortawesome/free-brands-svg-icons';
import { IconName, faEnvelope, faLocationDot, faPhone } from '@fortawesome/free-solid-svg-icons';
import {EmailContent} from '../../../Models/EmailContent';
import { ServiceService } from '../service.service';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {

  public contactForm!:FormGroup;
  content!:EmailContent;
  constructor(library:FaIconLibrary, private fb:FormBuilder, private service:ServiceService)
  {
    library.addIcons(faPhone, faLocationDot, faEnvelope, faInstagram, faFacebook);
    this.contactForm = fb.group({
      Name:['', Validators.required],
      Email:['', Validators.required],
      Subject:['', Validators.required],
      Text:['', Validators.required]
    })
  }
  
  submit()
  {

    if(this.contactForm.valid)
    {
      this.content = this.contactForm.value;
      this.service.sendEmail(this.content).subscribe(res => {
      })
      alert("Mejl je poslat");
      this.contactForm.reset();
    }
    else
    {
      this.validateAllFormsFields(this.contactForm);
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
