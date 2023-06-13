import { Injectable } from '@angular/core';
import { HttpClient,HttpClientModule } from "@angular/common/http"
import { BehaviorSubject, tap } from 'rxjs';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private baseUrl:string="https://localhost:7200/api/Authentication/"
  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  isLoggedIn = this._isLoggedIn$.asObservable();

  get token()
  {
    return localStorage.getItem('token');
  }
  get email()
  {
    let email = this.decodeToken(this.token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] as string;
    return email;
  }
  get role(){
    let role = this.decodeToken(this.token)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] as string;
    return role;
  }
  constructor(private http: HttpClient) { 
    this._isLoggedIn$.next(!!this.token)
  }

  signUp(userObj:any){
    return this.http.post<any>(`${this.baseUrl}signup`,userObj)

  }
  //https://localhost:7200/api/Authentication/Login
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}login`,loginObj).pipe(
      tap((res:any) => {
        this._isLoggedIn$.next(true);
        localStorage.setItem('token', res.token);
        console.log(this.role);
      })
    )

  }
  logout()
  {
    this._isLoggedIn$.next(false);
    localStorage.removeItem('token');
  }
  decodeToken(token:string|null):any
  {
    try {
      if(token != null)
        return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
}
