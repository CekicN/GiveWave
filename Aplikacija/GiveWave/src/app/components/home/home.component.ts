import { Component } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import {faArrowRight, faArrowLeft} from '@fortawesome/free-solid-svg-icons'
import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  isLoggedIn!:boolean;
  constructor(library: FaIconLibrary, private service:AuthService, private router:Router)
  {
    library.addIcons(faArrowLeft, faArrowRight);
    service.isLoggedIn.subscribe(logged => this.isLoggedIn = logged);
  }
  text:string[] = [
    "Help at your fingertips - donate money, food, shoes and clothes for the vulnerable and give them hope for a better future!",
    "Your donation changes lives - together we can support those most at risk and build a community of solidarity.",
    "Donate with ease - our application allows you to easily and quickly donate what is most needed by the vulnerable.",
    "Give love, donate resources - with your contribution, you help people in need to cope with difficult situations and rebuild their lives.",
    "Let your generosity be an echo of hope - your donation can be the key to providing basic needs and support to those most vulnerable.",
    "Simply donate, make a big impact - your small gesture can have a big impact on the lives of those who need help the most."
  ];
  isActive = 1;
  next() {
    if (this.isActive == this.text.length) this.isActive = 0;
    this.isActive ++;
  }
  pre() {
    this.isActive --;
    if (this.isActive == 0) this.isActive = this.text.length;
  }
  Active(t:string):boolean{
    return (this.text.indexOf(t)+1) == this.isActive;
  }
  Donate()
  {
    if(this.isLoggedIn)
    {
      this.router.navigate(['donate']);
    }
    else
    {
      this.router.navigate(['login']);
    }
  }
}
