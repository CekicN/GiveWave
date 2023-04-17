
import { group } from '@angular/animations';
import { Component} from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators } from '@angular/forms';







@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  type: string = "password";
  isText : boolean = false;
  eyeIcon: string = "fa-eye-slash"
  loginForm!: FormGroup;
  constructor(private fb: FormBuilder){
    

  }
  ngOnInit():void{
    this.loginForm=this.fb.group({
      username: ['',[Validators.required]],
      password:['',[Validators.required]]
    })
  }
  hideShowPass(){
    this.isText = this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type="password";

  }
  onSubmit(){
    if(this.loginForm.valid){
      console.log(this.loginForm.value);
      //send the obj to database
    }else{
      //throw the error using toaster and required fields
      this.validateAllFormsFields(this.loginForm)
      alert("Form is incorrect");
      
      
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
