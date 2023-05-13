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
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.post<User>(Users + "PreuzmiProfil", `"${email}"`, { headers: httpOptions});
  }

  updateProfilePicture(image:any, email:String|null|undefined)
  {
    const formData = new FormData();
    formData.append('source', image, image.name);

    let headers = new HttpHeaders()
    .set('Authorization', 'Bearer '+localStorage.getItem('token'))
    .set('Content-Type', 'multipart/form-data');
    return this.http.put<any>(Users+"updatePhoto/" + email,formData, {headers:headers});
  }
  Like(email:String)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.patch<number>(Users+"Like/"+email, {headers:httpOptions});
  }
  Dislike(email:String)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.patch<number>(Users+"Dislike/"+email, {headers:httpOptions});
  }
  updateUser(user:any)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put<User>(Users+"updateData", user, {headers:httpOptions});
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
