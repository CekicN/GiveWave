import { Component, OnInit } from '@angular/core';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProductService } from '../product.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit{
  cities:any;
  status:string[] = ['New', 'Second hand']
  searchText = '';
  constructor(private service:ProductService, library:FaIconLibrary)
  {
    library.addIcons(faMagnifyingGlass);
  }

  ngOnInit(): void {
    this.service.getCities().subscribe(p => this.cities = p);
  }
  
}
