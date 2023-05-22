import { Component, OnInit } from '@angular/core';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProductService } from '../product.service';
@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit{
  cities:any;
  status:string[] = ['New', 'Second hand']
  searchText = '';
  constructor(private service:ProductService)
  {}
  ngOnInit(): void {
    this.service.getCities().subscribe(p => this.cities = p);
  }
  
}
