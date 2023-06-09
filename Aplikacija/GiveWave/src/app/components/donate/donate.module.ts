import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonateComponent } from './donate/donate.component';
import { DonateFilterComponent } from './donate-filter/donate-filter.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LuckyGalleryComponent } from './lucky-gallery/lucky-gallery.component';
import { FamiliesComponent } from './families/families.component';
import { NgbPopoverModule, NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [

    DonateComponent,
      DonateFilterComponent,
      LuckyGalleryComponent,
      FamiliesComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    NgbPopoverModule,
    NgbProgressbarModule
  ]
})


export class DonateModule {
  

}

