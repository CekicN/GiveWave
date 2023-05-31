import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { ProfileDataComponent } from './profile-data/profile-data.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProfileImageComponent } from './profile-image/profile-image.component';
import { MyProductsComponent } from './my-products/my-products.component';
import { DonateHistoryComponent } from './donate-history/donate-history.component';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddProductModalComponent } from './add-product-modal/add-product-modal.component';
import { ProductsModule } from '../products/products.module';


@NgModule({
  declarations: [
    ProfileComponent,
    ProfileDataComponent,
    ProfileImageComponent,
    MyProductsComponent,
    DonateHistoryComponent,
    MyProductsFilterPipe,
    AddProductModalComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    ProductsModule
  ],
  exports:[]
})
export class ProfileModule { }
