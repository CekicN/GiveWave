import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from 'app/Models/Product';
import { BehaviorSubject } from 'rxjs';
import { ProductInfo } from 'app/Models/ProductInfo';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList: Product[] |  ProductInfo[]= [];
  public productList = new BehaviorSubject<any>([]);
  private baseUrl:string = "https://localhost:7200/controller/";

  constructor(private httpClient: HttpClient) { 

  }
  
  updateCartItemCount(){
    
  }

  getProducts(){
    return this.productList.asObservable();
  }

  //opciono
  setProduct(product: any){
    this.cartItemList.push(product);
    this.productList.next(product);
  }

  addToCart(product: Product | any) {
    this.cartItemList.push(product);
    this.productList.next(this.cartItemList);
  }

  //remove 1 item from the card 
  removeCartItem(product: any){
    this.cartItemList.map((a: any, index:any) => {
      if(product.id === a.id){
        this.cartItemList.splice(index,1);
      }
    })

    this.productList.next(this.cartItemList);

  }

  removeAllCart(){
    this.cartItemList = [];
    this.productList.next(this.cartItemList);

  }

  sendEmailProducts(email:string){
    return this.httpClient.post<any>(`${this.baseUrl}PosaljiMailZaProizvod?email=${email}`,{});
  }



}
