import { Injectable } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }


}
