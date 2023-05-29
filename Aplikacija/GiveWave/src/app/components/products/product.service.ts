import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from 'app/Models/Categories';
import { Product } from 'app/Models/Product';
import { BehaviorSubject } from 'rxjs';


const url = "http://localhost:3001/Cities"
const api = "https://localhost:7200/controller/"
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private searchText$ = new BehaviorSubject<string>('');
  searchText = this.searchText$.asObservable();
  constructor(private http:HttpClient) { }
  setSeatchText(searchText:string)
  {
    this.searchText$.next(searchText);
  }
  getCategories()
  {
    return this.http.get<any>(api+'PreuzmiKategorije');
  }
  getAllProducts()
  {
    return this.http.get<Product[]>(`${api}getAllProducts`);
  }
  getCities()
  {
    return this.http.get(url);
  }
}
