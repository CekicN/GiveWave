import { Injectable } from '@angular/core';
import { HttpClient,HttpClientModule } from "@angular/common/http"


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private baseUrl:string="https://localhost:7200/api/Authentication/"
  public isLogged:boolean = false;
  constructor(private http: HttpClient) { }

  signUp(userObj:any){
    return this.http.post<any>(`${this.baseUrl}Register`,userObj)

  }
  //https://localhost:7200/api/Authentication/Login
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}Login`,loginObj)

  }
}
