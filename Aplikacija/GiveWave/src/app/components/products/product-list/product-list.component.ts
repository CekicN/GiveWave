import { Component, OnInit } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { Product } from 'app/Models/Product';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { SearchProductsPipe } from 'app/pipes/search-products.pipe';
import { ProductInfo } from 'app/Models/ProductInfo';
import { ApiService } from '../api.service';
import { ChatService } from 'app/components/friends/chat.service';
import { CartService } from '../cart.service';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products!:Product[] | any;
  searchText:string = '';

  //public productList!: Product[];

  constructor(library:FaIconLibrary, private productService:ProductService, private route:Router,private cartService: CartService)
  {
    library.addIcons(faShoppingCart);
    productService.searchText.subscribe(p => this.searchText = p);
    productService.category.subscribe(p => {
      productService.getProductsViaCategory(p).subscribe(products => this.products = products);
    })
  }
  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(res => {
      this.products = res;
      console.log(this.products);

      this.products.forEach( (a: any) => {
        Object.assign(a,{quantity:1});
      });
    })
  }

  visitProfile(email:string)
  {
    this.route.navigate(['/profile', email]);
  }

  addToCart(item: Product) {
      this.cartService.addToCart(item);
  }

  viewDetails(id:number)
  {
    
    this.productService.getMoreInfo(id).subscribe(p => {
      let product:ProductInfo = p;
      this.productService.setProduct(product);
      this.productService.openModal();
    });
  }
}
