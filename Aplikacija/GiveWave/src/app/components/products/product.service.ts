import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from 'app/Models/Categories';


const url = 'http://localhost:3000/Categories'
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getCategories()
  {
    return this.http.get<any>(url);
  }
}
