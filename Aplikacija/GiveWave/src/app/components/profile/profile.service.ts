import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { User } from 'app/Models/User';
import { MyProducts } from 'app/Models/MyProducts';
import { DonationHistory } from 'app/Models/DonationsHistory';
import { BehaviorSubject } from 'rxjs';

const Url = "https://localhost:7200/controller/";
const donations = "http://localhost:3000/DonationHistory"
@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  public email:string = '';
  private _displayStyle$ = new BehaviorSubject<string>("none");
  displayStyle = this._displayStyle$.asObservable();

  openModal()
  {
    this._displayStyle$.next("block");
  }
  closeModal()
  {
    this._displayStyle$.next("none");
  }
  constructor(private http: HttpClient) {}
  getAllUsers()
  {
    return this.http.get<User[]>(Url);
  }
  getUser(email:String|null)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.post<User>(Url + "PreuzmiProfil", `"${email}"`, { headers: httpOptions});
  }

  updateProfilePicture(image:any, email:String|null|undefined)
  {
    const formData = new FormData();
    formData.append('source', image, image.name);

    let headers = new HttpHeaders()
    .set('Authorization', 'Bearer '+localStorage.getItem('token'));
    headers.append('Content-Type', 'multipart/form-data');
    return this.http.put<any>(Url+"updatePhoto/" + email,formData, {headers:headers});
  }
  Like(email:String)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.patch<number>(Url+"Like/"+email, {headers:httpOptions});
  }
  Dislike(email:String)
  {
    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'));
    httpOptions.append('Content-Type', 'application/json');
    return this.http.patch<number>(Url+"Dislike/"+email, {headers:httpOptions});
  }
  updateUsername(email:string|null|undefined, data:String)
  {
    let obj = {
      email:email,
      data:data
    }

    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put<User>(Url+"updateUsername", obj, {headers:httpOptions});
  }
  updatePhoneNumber(email:string|null|undefined, data:String)
  {
    let obj = {
      email:email,
      data:data
    }

    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put<User>(Url+"updatePhoneNumber", obj, {headers:httpOptions});
  }
  updateAddress(email:string|null|undefined, data:String)
  {
    let obj = {
      email:email,
      data:data
    }

    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put<User>(Url+"updateAddress", obj, {headers:httpOptions});
  }
  updateGender(email:string|null|undefined, data:String)
  {
    let obj = {
      email:email,
      data:data
    }

    let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
    return this.http.put<User>(Url+"updateGender", obj, {headers:httpOptions});
  }
  getMyProducts(email:string|null)
  {
    return this.http.get<MyProducts[]>(Url+"VratiProizvodePremaEmailu/"+email, {headers:{'Content-Type':'application/json'}});
  }
  getDonations()
  {
    return this.http.get<DonationHistory[]>(donations);
  }
}
