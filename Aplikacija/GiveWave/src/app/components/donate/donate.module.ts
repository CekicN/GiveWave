import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonateComponent } from './donate/donate.component';
import { PorodiceComponent } from './porodice/porodice.component';

@NgModule({
  declarations: [
    DonateComponent,
    PorodiceComponent
  ],
  imports: [
    CommonModule
  ]
})


export class DonateModule {
  

}

