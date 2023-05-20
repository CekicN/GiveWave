import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { CategoriesComponent } from './categories/categories.component';
import { RecursiveCategoriesComponent } from './recursive-categories/recursive-categories.component';



@NgModule({
  declarations: [
    ProductsComponent,
    CategoriesComponent,
    RecursiveCategoriesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
