import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResetPassword } from 'app/Models/reset-password';

@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {
  private baseUrl:string = "https://localhost:7200/api/Authentication/"
  constructor(private http:HttpClient) { }

  sendResetPasswordLink(email:string){
    return this.http.post<any>(`${this.baseUrl}forgotpassword?email=${email}`,{});
  }
  resetPassword(resetPasswordObj:ResetPassword){
    const formData = new FormData(); 
    formData.append('token',resetPasswordObj.token);
    formData.append('newPassword',resetPasswordObj.newPassword);
    formData.append('confirmPassword',resetPasswordObj.confirmPassword);
    formData.append('email',resetPasswordObj.email);
    return this.http.post<any>(`${this.baseUrl}ResetPassword`,formData);
    

  }
}
