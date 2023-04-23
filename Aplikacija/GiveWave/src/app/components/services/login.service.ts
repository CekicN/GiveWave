import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LastActiveService } from './last-active.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private localStorageKey:string = '__loggedIn';

  private loggedIn!: BehaviorSubject<boolean>;
  public loggedIn$!: Observable<boolean>;

  constructor(private lastActiveService:LastActiveService) {
    this.loggedIn = new BehaviorSubject(this.getLogged() ?? false);
    this.loggedIn$ = this.loggedIn.asObservable();
   }
  public logIn() {
    localStorage.setItem(this.localStorageKey, 'true');
    this.loggedIn.next(true);
  }

  public logOut() {
    localStorage.removeItem(this.localStorageKey);
    this.loggedIn.next(false);
  }

  private getLogged(): boolean | null {
    const valueFromStorage = localStorage.getItem(this.localStorageKey);
    if (!valueFromStorage) {
      return null;
    }

    return !!valueFromStorage;
  }
}
