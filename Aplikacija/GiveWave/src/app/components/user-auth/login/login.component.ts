import { group } from '@angular/animations';
import { Component} from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { IconName } from '@fortawesome/fontawesome-svg-core';
import { faFacebook, faGithub, faGoogle} from '@fortawesome/free-brands-svg-icons';
import { faLock, faUser, faEyeSlash, faEye} from '@fortawesome/free-solid-svg-icons';
import { Res } from 'app/Models/AuthRes';
import { AuthService } from 'app/services/auth.service';
import { ResetPasswordService } from 'app/services/reset-password.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  isLogged!:boolean;

  type: string = "password";
  isText : boolean = false;
  eyeIcon: IconName = 'eye-slash'; 
  public resetPasswordEmail!: string;
  public isValidEmail!:boolean;
  loginForm!: FormGroup;


  constructor(private fb: FormBuilder, library:FaIconLibrary, private route:Router, private authService:AuthService, private resetService:ResetPasswordService){
    library.addIcons(faFacebook, faGithub, faGoogle, faLock, faUser, faEyeSlash, faEye);
    authService.isLoggedIn.subscribe(logged => this.isLogged = logged);
  }
  
  ngOnInit():void{
    this.loginForm=this.fb.group({
      username: ['',[Validators.required]],
      password:['',[Validators.required]]
    })
  }
  hideShowPass(){
    this.isText ? this.eyeIcon = "eye" : this.eyeIcon = 'eye-slash';
    this.isText ? this.type = "text" : this.type="password";
    this.isText = !this.isText;
  }
  onSubmit(){
    if(this.loginForm.valid){
      this.authService.login(this.loginForm.value)
        .subscribe({
          next:(res) => {
            localStorage.setItem('username', this.loginForm.value.username);
            this.loginForm.reset();
            this.route.navigate(['/']);
          },
          error:(err)=> {
            alert("doslo je do greske");
            console.log(err);
          }
        }) 
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

  checkValidEmail(event: string){
    const value = event;
    const pattern = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$/;//regex patern for checking email
    this.isValidEmail=pattern.test(value);
    return this.isValidEmail


  }
  confirmToSend(){
    if(this.checkValidEmail(this.resetPasswordEmail)){
      console.log(this.resetPasswordEmail);
      

      //api call to be done

      this.resetService.sendResetPasswordLink(this.resetPasswordEmail)
      .subscribe({
        next:(res)=>{
          this.resetPasswordEmail="";
          const buttonRef = document.getElementById("closeButton");
          buttonRef?.click();

        },
        error:(err)=>{
          alert("It doesn't work!");

        }
      })
    }

  }

}