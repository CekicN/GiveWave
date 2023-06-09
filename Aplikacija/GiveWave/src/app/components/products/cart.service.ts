import { Injectable } from '@angular/core';
import { Product } from 'app/Models/Product';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList: Product[] = [];
  public productList = new BehaviorSubject<any>([]);

  constructor() { }

  getProducts(){
    return this.productList.asObservable();
  }

  //opciono
  setProduct(product: any){
    this.cartItemList.push(product);
    this.productList.next(product);
  }

  addToCart(product: Product) {
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



}
