import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProductService } from '../product.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { CartService } from '../cart.service';


@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit{
  cities:any;
  status:string[] = ['New', 'Second hand']
  searchText:string = '';
  productList: any;
  public totalItem: number = 0;
  selectedItem1! : string;
  selectedItem2! : string;

  constructor(private service:ProductService, library:FaIconLibrary,private router:Router,private cartService: CartService){
    library.addIcons(faMagnifyingGlass);
  }

  updateSearch(){
    this.service.setSeatchText(this.searchText);
  }

  ngOnInit(): void {
    this.service.getCities().subscribe(p => this.cities = p);

    this.cartService.getProducts()
    .subscribe(res => {
      this.totalItem = res.length;
    })
  }

  goToCartPage(){
    this.router.navigate(['/cart']);
  }
  onChangeCity(newValue:any) {
    console.log(newValue);
    this.selectedItem1 = newValue;
    this.service._city = newValue;
  }

  onChangeStatus(newValue:any) {
    console.log(newValue);
    this.selectedItem2 = newValue;
    this.service._status = newValue;
  }
}
