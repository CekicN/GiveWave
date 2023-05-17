import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { EmailContent } from 'app/Models/EmailContent';


const Url = "https://localhost:7200/SendEmail";
const CountUrl = "https://localhost:7200/controller/";
@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }

  sendEmail(content:EmailContent)
  {
    return this.http.post<string>(Url, content);
  }

  countUsers()
  {
    return this.http.get<number>(CountUrl+"CountUsers");
  }
  countProducts()
  {
    return this.http.get<number>(CountUrl+"CountProducts");
  }
}
