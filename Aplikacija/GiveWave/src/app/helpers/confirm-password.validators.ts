import { FormGroup } from "@angular/forms";

export function ConfrimPasswordValidator(controlName:string, matchControlName:string){
    return (formGroup:FormGroup)=>{
        const passwordControl = formGroup.controls[controlName];
        const confirmpasswordControl = formGroup.controls[matchControlName];
        if(confirmpasswordControl.errors && confirmpasswordControl.errors['confirmPasswordValidator']){
            return;
        }
        if(passwordControl.value !== confirmpasswordControl.value){
            confirmpasswordControl.setErrors({confirmPasswordValidator:true})
        }else{
            confirmpasswordControl.setErrors(null);
        }
    }
}