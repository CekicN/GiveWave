import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Porodica } from 'app/Models/Porodica';
import { BehaviorSubject } from 'rxjs';
import { FamilyHelper } from 'app/Models/FamilyHelper';
import { uploadPhoto } from 'app/Models/uploadPhoto';
import { DonationHelper } from 'app/Models/DonationHelper';
const api = "https://localhost:7200/"
@Injectable({
  providedIn: 'root'
})
export class DonateService { 

  private searchText$ = new BehaviorSubject<string>('');
  searchText = this.searchText$.asObservable();

  private view$ = new BehaviorSubject<boolean>(false);
  view = this.view$.asObservable();

  private family$ = new BehaviorSubject<Porodica|null>(null);
  family = this.family$.asObservable();

  private donateFamily$ = new BehaviorSubject<string>('');
  donateFamily = this.donateFamily$.asObservable();

  private familyId$ = new BehaviorSubject<number>(-1);
  familyId = this.familyId$.asObservable();
  
  constructor(private http:HttpClient) { }

  set _family(p:Porodica)
  {
    this.family$.next(p);
  }
  setSearchText(searchText:string)
  {
    this.searchText$.next(searchText);
  }

  openModal(id:number)
  {
    this.donateFamily$.next('block');
    this.familyId$.next(id);
  }

  closeModal()
  {
    this.donateFamily$.next('none');
  }

  setTrue()
  {
    this.view$.next(true);
  }
  setFalse()
  {
    this.view$.next(false);
  }

  getAllFamilies()
  {
    return this.http.get<Porodica[]>(`${api}getAllFamilies`);
  }

  addEmptyFamily()
  {
    return this.http.post<number>(`${api}addEmptyFamily`,{headers:{'Content-Type':'application/json'}});
  }
  addFamily(data:FamilyHelper, id:number)
  {
    return this.http.put(api+"AddFamily/"+id,data);
  }
  cancelAdding(id:number, email:string|null)
  {
    return this.http.delete(`${api}CancleAddingFamily/${id}/${email}`);
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
    return this.http.put<any>(api+"updatePhoto",formData);
  }

  familyDetails(id:number)
  {
    return this.http.get<Porodica>(`${api}getDetails/${id}`);
  }
  getSupplies(id:number)
  {
    return this.http.get<string[]>(`${api}getSupplies/${id}`);
  }

  donate(donacija:DonationHelper)
  {
    return this.http.post(`${api}Donate`, donacija);
  }
}
