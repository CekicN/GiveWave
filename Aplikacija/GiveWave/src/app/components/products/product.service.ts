import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from 'app/Models/Categories';
import { Product } from 'app/Models/Product';
import { ProductInfo } from 'app/Models/ProductInfo';
import { BehaviorSubject } from 'rxjs';


const url = "http://localhost:3001/Cities"
const api = "https://localhost:7200/controller/"
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  

  private searchText$ = new BehaviorSubject<string>('');
  searchText = this.searchText$.asObservable();

  private productDetails$ = new BehaviorSubject<string>('');
  productDetails = this.productDetails$.asObservable();

  private product$ = new BehaviorSubject<any>(null);
  product= this.product$.asObservable();

  private city$ = new BehaviorSubject<string>('');
  city = this.city$.asObservable();

  private status$ = new BehaviorSubject<string>('');
  status = this.status$.asObservable();

  constructor(private http:HttpClient) { }

  set _city(c:string)
  {
    this.city$.next(c);
  }
  set _status(c:string)
  {
    this.status$.next(c);
  }
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
  getMoreInfo(id:number)
  {
    return this.http.get<ProductInfo>(`${api}PrikaziViseInfoOProizvodu/${id}`);
  }
  openModal()
  {
    this.productDetails$.next('block');
    console.log(this.productDetails$.value);
  }

  closeModal()
  {
    this.productDetails$.next('none');
    console.log(this.productDetails$.value);
  }

  setProduct(_product:ProductInfo)
  {
    this.product$.next(_product);
  }
  getStatus()
  {
    return this.http.get
  }
  getCitiesFilter(grad:string)
  {
    return this.http.get<Product[]>(`${api}PrikaziPoGradu/${grad}`);
  }
  getStatusFilter(status:string){
    return this.http.get<Product[]>(`${api}PrikaziPoStatusu/${status}`);
  }
}
