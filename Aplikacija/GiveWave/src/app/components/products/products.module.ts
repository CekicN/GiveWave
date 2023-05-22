import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { CategoriesComponent } from './categories/categories.component';
import { RecursiveCategoriesComponent } from './recursive-categories/recursive-categories.component';
import { ProductFilterComponent } from './product-filter/product-filter.component';
import { ProductListComponent } from './product-list/product-list.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProductsComponent,
    CategoriesComponent,
    RecursiveCategoriesComponent,
    ProductFilterComponent,
    ProductListComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class ProductsModule { }
