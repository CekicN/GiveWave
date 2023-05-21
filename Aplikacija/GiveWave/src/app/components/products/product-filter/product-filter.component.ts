import { Component } from '@angular/core';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent {
  cities:string[] = ['Prokuplje', 'Nis', 'Kragujevac', 'Beograd', 'Krusevac']
  status:string[] = ['New', 'Second hand']
  searchText = '';
}
