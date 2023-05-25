import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from 'app/Models/Categories';


const url = "http://localhost:3001/Cities"
const api = "https://localhost:7200/controller/"
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getCategories()
  {
    return this.http.get<any>(api+'PreuzmiKategorije');
  }

  getCities()
  {
    return this.http.get(url);
  }
}
