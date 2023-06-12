import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'app/Models/Product';
import { ProductInfo } from 'app/Models/ProductInfo';
import { User } from 'app/Models/User';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:7200/controller/';


  constructor(private http:HttpClient) { }
  getData(){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.get<User>(this.apiUrl + "PrikaziSveKorisnike",{ headers: httpOptions});
  }
  removeUser(ime:string){
    return this.http.get(`${this.apiUrl}/ObrisiKorisnika/${ime}`);
  }
  changeRoles(imena:string){
    return this.http.get(`${this.apiUrl}/PromeniRolu/${imena}`);
  }
 //ovde ide update user
  getDonations(){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.get<any>(this.apiUrl + "PrikaziSveDonacije",{ headers: httpOptions});
  }
  getProducts(){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.get<Product>(this.apiUrl + "getAllProducts",{ headers: httpOptions});
  }
}
