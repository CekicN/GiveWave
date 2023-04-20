import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { User } from 'app/Models/User';

const ENDPOINT = "localhost:3000/users"
@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {}
  getAll()
  {
    return this.http.get<User[]>(ENDPOINT);
  }
  getById(id:number)
  {
    return this.http.get<User[]>(`${ENDPOINT}/${id}`);
  }
}
