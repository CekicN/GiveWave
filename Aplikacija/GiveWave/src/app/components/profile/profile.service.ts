import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { User } from 'app/Models/User';
import { MyProducts } from 'app/Models/MyProducts';
import { DonationHistory } from 'app/Models/DonationsHistory';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { ProductHelper } from 'app/Models/ProductHelper';
import { uploadPhoto } from 'app/Models/uploadPhoto';

const Url = "https://localhost:7200/controller/";
const donations = "http://localhost:3000/DonationHistory"
const api = "http://localhost:7200/";
@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  public email:string = '';
  private _displayStyle$ = new BehaviorSubject<string>("none");
  displayStyle = this._displayStyle$.asObservable();
  public productId!:number;

  private familyId$ = new BehaviorSubject<number>(-1);
  familyId = this.familyId$.asObservable();

  private displayFamilyModal$ = new BehaviorSubject<string>("none");
  displayFamilyModal = this.displayFamilyModal$.asObservable();

  private subject = new Subject<any>();

  openFamilyModal()
  {
    this.displayFamilyModal$.next("block");
  }
  closeFamilyModal()
  {
    this.displayFamilyModal$.next("none");
  }
  setFamilyId(id:number)
  {
    this.familyId$.next(id);
  }
  sendClickEvent()
  {
    this.subject.next(null);
  }
  getClickEvent()
  {
    return this.subject.asObservable();
  }
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
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
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
  addEmptyProduct()
  {
    return this.http.post<number>(Url+"addEmptyProduct", {headers:{'Content-Type':'application/json'}});
  }
  addProduct(data:ProductHelper, id:number)
  {
    return this.http.put(Url+"addProduct/"+id,data);
  }
  cancelAdding(id:number, email:string|null)
  {
    return this.http.delete(`${Url}CancleAdding/${id}/${email}`);
  }
  updatePhoto(upload:uploadPhoto)
  {
    const formData = new FormData();
    if(upload.id)
      formData.append('id', upload.id.toString());
    if(upload.email)
      formData.append('email', upload.email);
    if(upload.files)
      upload.files.forEach((e:File) => {
        formData.append('files', e);
      });
    return this.http.put<any>(Url+"updatePhoto",formData);
  }
  getMyProducts(email:string|null)
  {
    return this.http.get<MyProducts[]>(Url+"VratiProizvodePremaEmailu/"+email, {headers:{'Content-Type':'application/json'}});
  }
  getImage(email:string|null, id:number)
  {
    const formData = new HttpParams();
    formData.set('id', id.toString());
    if(email)
      formData.set('email', email);
    return this.http.get<string>(Url+"GetImage", {
      params: formData
    });
  }
  getDonations(email:string)
  {
    return this.http.get<DonationHistory[]>(`${api}getDonationHistory/${email}`,{headers:{'Content-Type':'application/json'}});
  }

 
}
