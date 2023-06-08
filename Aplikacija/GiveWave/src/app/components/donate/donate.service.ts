import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DonateService {

  private view$ = new BehaviorSubject<boolean>(false);
  view = this.view$.asObservable();
  constructor() { }

  setTrue()
  {
    this.view$.next(true);
  }
  setFalse()
  {
    this.view$.next(false);
  }
}
