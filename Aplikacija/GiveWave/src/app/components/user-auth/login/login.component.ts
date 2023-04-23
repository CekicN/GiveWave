
import { group } from '@angular/animations';
import { Component} from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faFacebook, faGithub, faGoogle} from '@fortawesome/free-brands-svg-icons';
<<<<<<< HEAD
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'app/services/auth.service';





=======
import { faLock, faUser } from '@fortawesome/free-solid-svg-icons';
>>>>>>> 6400b6ec6e186fc93adf523113794f6a400988b4

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


<<<<<<< HEAD
  constructor(private fb: FormBuilder, library:FaIconLibrary, private auth:AuthService, private router:Router){
    library.addIcons(faFacebook, faGithub, faGoogle, faLock);
=======
  constructor(private fb: FormBuilder, library:FaIconLibrary){
    library.addIcons(faFacebook, faGithub, faGoogle, faLock, faUser);
>>>>>>> 6400b6ec6e186fc93adf523113794f6a400988b4

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
  onLogin(){
    if(this.loginForm.valid){
      //send the obj to database
      this.auth.login(this.loginForm.value)
      .subscribe({
        next:(res)=>{
          alert(res.message)
          this.loginForm.reset();
          this.router.navigate(['home']);
        },
        error:(err)=>{
          alert(err?.error.message);
          
        }
        })
    
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
