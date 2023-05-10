import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, filter, from, fromEvent, map, mergeMap, throttleTime } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LastActiveService {
  private recordTimeoutMs:number = 1000;
  private localStorageKey: string = '_lastActive';
  private events: string[] = ['keydown', 'click', 'wheel', 'mousemove'];

  private lastActive!: BehaviorSubject<Date>;
  public lastActive$!: Observable<Date>;
  constructor() {
    const lastActiveDate = this.getLastActive() ?? new Date();
    this.lastActive = new BehaviorSubject<Date>(lastActiveDate);
    this.lastActive$ = this.lastActive.asObservable();
   }
  getLastActive():Date | null {
    const valueFromStorage = localStorage.getItem(this.localStorageKey);
    if(!valueFromStorage)
    {
      return null;
    }
    return new Date(valueFromStorage);
  }
  public setUp() {
    from(this.events)
      .pipe(
        mergeMap(event => fromEvent(document, event)),
         throttleTime(this.recordTimeoutMs))
         .subscribe(_ => this.recordLastActiveDate());

    fromEvent<StorageEvent>(window, 'storage')
      .pipe(
        filter(event => event.storageArea === localStorage
          && event.key === this.localStorageKey
          && !!event.newValue),
        map(event => event.newValue ? new Date(event.newValue) : null)
      )
      .subscribe(newDate => {
        if(newDate)
        {
          this.lastActive.next(newDate)
        }
      });
  }
  private recordLastActiveDate() {
    var currentDate = new Date(); 
    localStorage.setItem(this.localStorageKey, currentDate.toString());
    this.lastActive.next(currentDate);
  }
}
