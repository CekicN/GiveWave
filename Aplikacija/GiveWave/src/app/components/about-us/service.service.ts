import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { EmailContent } from 'app/Models/EmailContent';


const Url = "https://localhost:7200/SendEmail";
@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }

  sendEmail(content:EmailContent)
  {
    return this.http.post<string>(Url, content);
  }

}
