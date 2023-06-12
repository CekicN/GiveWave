import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AdminGuard  {
  constructor(private router:Router, private authService:AuthService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if(localStorage.getItem('token') && this.authService.role=='Admin')
    {
      return true;
    }
    else
    {
      this.router.navigate([''], {queryParams:{returnUrl:state.url}});
      alert("You don't have permission to access to this page!")
      return false;
    }
  }
}

