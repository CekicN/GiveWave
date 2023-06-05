import { Injectable } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  /*getProduct() {
    return this.http.get<any>("https://localhost:7200/controller/getAllProducts")
    .pipe(map((res: any) => {
      return res;
    }))
  }*/
}
