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

  constructor(library: FaIconLibrary, private service:AuthService, private router:Router)
  {
    library.addIcons(faArrowLeft, faArrowRight);
  }
  text:string[] = [
    "a Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ut at eos minima repudiandae. Assumenda repudiandae neque distinctio, minima perferendis voluptas?",
    "a Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ut at eos minima repudiandae. ",
    "a Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ut",
    "a Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ufdjfhdjfbdjbwbfjnfdnft"
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
    if(this.service.isLogged)
    {
      this.router.navigate(['donate']);
    }
    else
    {
      this.router.navigate(['login']);
    }
  }
}
