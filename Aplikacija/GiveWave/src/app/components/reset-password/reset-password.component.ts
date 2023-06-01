import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPassword } from 'app/Models/reset-password';
import { ConfrimPasswordValidator } from 'app/helpers/confirm-password.validators';
import { ResetPasswordService } from 'app/services/reset-password.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent {
  resetPasswordForm!:FormGroup;
  emailToReset!:string;
  token!:string;
  resetPasswordObj = new ResetPassword();

  constructor(private fb:FormBuilder, private activatedRoute:ActivatedRoute, private resetService:ResetPasswordService, private router:Router){

  }
  ngOnInit():void{
    this.resetPasswordForm = this.fb.group({
      password:[null, Validators.required],
      confirmPassword:[null,Validators.required]
  },{
    validator:ConfrimPasswordValidator("password","confirmPassword")
  });

  this.activatedRoute.queryParams.subscribe(val=>{
    this.emailToReset = val['email'];
    let uriToken = val['code'];
    //this.token=val['code'];

    //this.token=uriToken.replace(/ /g,'+');
    //let etoken = decodeURIComponent(uriToken);
   let etoken=decodeURIComponent(uriToken.replace(/%2F/g,'/'));
   this.token=etoken.replace(/ /g,'+');
    //const etoken = val['code'];
//const parts = etoken.split('.');
//const header = parts[0];
//const payload = parts[1];
//const signature = parts[2];

//const encodedHeader = btoa(header).replace('+', '-').replace('/', '_').replace(/=+$/, '');
//const encodedPayload = btoa(payload).replace('+', '-').replace('/', '_').replace(/=+$/, '');
//const encodedSignature = btoa(signature).replace('+', '-').replace('/', '_').replace(/=+$/, '');

//const encodedToken = `${encodedHeader}.${encodedPayload}.${encodedSignature}`;
//this.token=encodedToken;
//console.log(encodedToken);
    console.log(this.token);
    console.log(this.emailToReset);
    //console.log(this.resetPasswordObj.confirmPassword);
    //console.log(this.resetPasswordObj.newPassword);
  })
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
reset(){
  if(this.resetPasswordForm.valid){
    this.resetPasswordObj.email = this.emailToReset;
    this.resetPasswordObj.newPassword = this.resetPasswordForm.value.password;
    this.resetPasswordObj.confirmPassword = this.resetPasswordForm.value.confirmPassword;
    this.resetPasswordObj.token=this.token;

    this.resetService.resetPassword(this.resetPasswordObj)
    .subscribe({
      next:(res)=>{
        this.router.navigate(['/login']);
      },
      error:(err)=>{
        console.log("error");
      }
    })

  }else{
    this.validateAllFormsFields(this.resetPasswordForm);
  }
}





}
