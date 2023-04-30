import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { User } from 'app/Models/User';
import { MyProducts } from 'app/Models/MyProducts';
import { DonationHistory } from 'app/Models/DonationsHistory';

const Users = "https://localhost:7200/controller/";
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
    return this.http.post<User>(Users + "PreuzmiProfil", `"${email}"`, { headers: { 'Content-Type': 'application/json' }});
  }
  getProfilePicture(email:String)
  {
    const headers = new HttpHeaders();
    return this.http.post('', email, {headers, responseType: 'blob'});
  }
  updateProfilePicture(image:any, email:String|null|undefined)
  {
    const formData = new FormData();
    formData.append('source', image, image.name);

    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    return this.http.put<any>(Users+"updatePhoto/" + email,formData, {headers});
  }
  updateUser(user:any)
  {
    return this.http.put<User>(Users+"updateData", user);
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
