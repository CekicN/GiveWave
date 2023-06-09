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
    "Dosta ljudi sirom sveta koristi ovu aplikaciju jer omogucava jednostavan,brz i siguran nacin za doniranje.",
    "Ova aplikacija je dobrinela hiljadama ljudi sirom sveta razne potrebstine.",
    "Uz ovu aplikaciju je sve manje ugrozenih osoba.",
    "Klikni na dugme i postavi stvari koje zelis da doniras!"
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
