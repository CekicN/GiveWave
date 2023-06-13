import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

import { Porodica } from 'app/Models/Porodica';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const api = "https://localhost:7200/"

@Injectable({
  providedIn: 'root'
})
export class FamilyServiceService {

	constructor(private http:HttpClient) {}
	getFamilies()
	{
		return this.http.get<Porodica[]>(`${api}getAllFamiliesToValidate`);
	}


	overi(id:number, status:string)
	{
		let httpOptions = new HttpHeaders()
                      .set('Authorization', 'Bearer '+localStorage.getItem('token'))
                      .set('Content-Type', 'application/json');
		return this.http.put(`${api}controller/validateFamily/${id}/${status}`, {headers:httpOptions});
	}
	cancelAdding(id:number, email:string)
	{
		return this.http.delete(`${api}CancleAddingFamily/${id}/${email}`);
	}
}
