import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {

  isLogged!:boolean;
  constructor(public authService:AuthService, private router:Router)
  {
    authService.isLoggedIn.subscribe(logged => this.isLogged = logged);
  }

  viewProfile()
  {
    this.router.navigate(['/profile', localStorage.getItem('email')]);
  }
  public logOut()
  {
    this.authService.logout();//postavlja _isLoggedIn$ na false
    localStorage.removeItem('email');
    localStorage.removeItem('token');
    this.router.navigate(['/']);
  }
}
