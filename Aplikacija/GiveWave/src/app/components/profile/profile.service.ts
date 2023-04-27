import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { User } from 'app/Models/User';
import { MyProducts } from 'app/Models/MyProducts';
import { DonationHistory } from 'app/Models/DonationsHistory';

const Users = "https://localhost:7200/controller/PreuzmiProfil";
const product = "http://localhost:3000/MyProducts";
const donations = "http://localhost:3000/DonationHistory"
@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  public email:string = '';
  constructor(private http: HttpClient) {}
  getAllUsers()
  {
    return this.http.get<User[]>(Users);
  }
  getUser(email:String|null)
  {
    return this.http.post<User>(Users, `"${email}"`, { headers: { 'Content-Type': 'application/json' }});
  }
  getMyProducts()
  {
    return this.http.get<MyProducts[]>(product);
  }
  getDonations()
  {
    return this.http.get<DonationHistory[]>(donations);
  }
}
