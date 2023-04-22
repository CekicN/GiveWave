import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { User } from 'app/Models/User';
import { MyProducts } from 'app/Models/MyProducts';

const Users = "http://localhost:3000/users";
const produc = "http://localhost:3000/MyProducts";
@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {}
  getAllUsers()
  {
    return this.http.get<User[]>(Users);
  }
  getUsersById(id:number)
  {
    return this.http.get<User>(`${Users}/${id}`);
  }
  getMyProducts()
  {
    return this.http.get<MyProducts[]>(produc);
  }
}
