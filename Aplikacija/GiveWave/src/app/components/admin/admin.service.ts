import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Donations } from 'app/Models/Donations';
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
    console.log(ime);
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.delete(this.apiUrl + `ObrisiKorisnika/${ime}`,{headers:httpOptions});
  }
  changeRoles(imena:string){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put(this.apiUrl+`PromeniRolu/${imena}`,{headers:httpOptions});
  }
  getDonations(){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.get<Donations>(this.apiUrl + "PrikaziSveDonacije",{ headers: httpOptions});
  }
  getProducts(){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.get<Product>(this.apiUrl + "getAllProducts",{ headers: httpOptions});
  }
  removeProducts(identifikator : number){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.delete(this.apiUrl+`PromeniRolu/${identifikator}`, {headers:httpOptions});                 

  }
  removeDonations(id:number){
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.delete(this.apiUrl+`BrisanjeNeprikladneDonacije/${id}`,{headers:httpOptions});
  }
}
