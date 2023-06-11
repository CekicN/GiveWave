import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiveWaveadminComponent } from './give-waveadmin/give-waveadmin.component';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { DonationsComponent } from './donations/donations.component';



@NgModule({
  declarations: [
    GiveWaveadminComponent,
    UsersComponent,
    ProductsComponent,
    DonationsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AdminModule { }
