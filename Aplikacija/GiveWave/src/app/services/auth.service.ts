import { Injectable } from '@angular/core';
import { HttpClient,HttpClientModule } from "@angular/common/http"
import { BehaviorSubject, tap } from 'rxjs';


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
      })
    )

  }
  logout()
  {
    this._isLoggedIn$.next(false);
  }
}
