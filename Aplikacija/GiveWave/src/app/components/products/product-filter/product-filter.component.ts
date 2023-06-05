import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProductService } from '../product.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit{
  cities:any;
  status:string[] = ['New', 'Second hand']
  searchText = '';
  productList: any;

  constructor(private service:ProductService, library:FaIconLibrary,private router:Router)
  {
    library.addIcons(faMagnifyingGlass);
  }
  updateSearch()
  {
    this.service.setSeatchText(this.searchText);
  }
  ngOnInit(): void {
    this.service.getCities().subscribe(p => this.cities = p);
  }

  goToCartPage(){
    this.router.navigate(['/cart']);
  }
}
