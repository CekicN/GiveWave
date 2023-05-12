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
    this.isLogged = authService.isLogged;
  }

  public logOut()
  {
    this.authService.isLogged = false; 
    localStorage.removeItem('email');
    this.router.navigate(['/']);
  }
}
