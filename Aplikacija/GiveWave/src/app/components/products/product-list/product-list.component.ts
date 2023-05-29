import { Component, OnInit } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { Product } from 'app/Models/Product';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { SearchProductsPipe } from 'app/pipes/search-products.pipe';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products!:Product[];
  searchText:string = '';
  constructor(library:FaIconLibrary, private productService:ProductService, private route:Router)
  {
    library.addIcons(faShoppingCart);
    productService.searchText.subscribe(p => this.searchText = p);
  }
  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(res => {
      this.products = res;
      console.log(this.products);
    });
  }
  visitProfile(email:string)
  {
    this.route.navigate(['/profile', email]);
  }
  addToCart(id:number)
  {
    console.log(id);
  }
}
