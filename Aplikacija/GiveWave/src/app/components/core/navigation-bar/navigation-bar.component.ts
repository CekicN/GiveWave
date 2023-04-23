import { Component } from '@angular/core';
import { LoginService } from 'app/components/services/login.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {

  public loggedIn$!: Observable<boolean>;
  constructor(private loginService:LoginService)
  {
    this.loggedIn$ = loginService.loggedIn$;
  }

  public logOut()
  {
    this.loginService.logOut();
  }
}
