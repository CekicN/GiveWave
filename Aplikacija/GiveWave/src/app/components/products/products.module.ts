import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { CategoriesComponent } from './categories/categories.component';
import { RecursiveCategoriesComponent } from './recursive-categories/recursive-categories.component';
import { ProductFilterComponent } from './product-filter/product-filter.component';
import { ProductListComponent } from './product-list/product-list.component';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SearchProductsPipe } from 'app/pipes/search-products.pipe';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  declarations: [
    ProductsComponent,
    CategoriesComponent,
    RecursiveCategoriesComponent,
    ProductFilterComponent,
    ProductListComponent,
    SearchProductsPipe,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    FontAwesomeModule
  ],
  exports:[
    ProductDetailsComponent
  ]
})
export class ProductsModule { }
