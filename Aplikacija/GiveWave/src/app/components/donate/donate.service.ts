import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Porodica } from 'app/Models/Porodica';
import { BehaviorSubject } from 'rxjs';
const api = "https://localhost:7200/"
@Injectable({
  providedIn: 'root'
})
export class DonateService { 

  private searchText$ = new BehaviorSubject<string>('');
  searchText = this.searchText$.asObservable();

  private view$ = new BehaviorSubject<boolean>(false);
  view = this.view$.asObservable();
  constructor(private http:HttpClient) { }

  setSearchText(searchText:string)
  {
    this.searchText$.next(searchText);
  }

  setTrue()
  {
    this.view$.next(true);
  }
  setFalse()
  {
    this.view$.next(false);
  }

  getAllFamilies()
  {
    return this.http.get<Porodica[]>(`${api}getAllFamilies`);
  }
}
