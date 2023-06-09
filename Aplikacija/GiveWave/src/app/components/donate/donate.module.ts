import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonateComponent } from './donate/donate.component';
import { DonateFilterComponent } from './donate-filter/donate-filter.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LuckyGalleryComponent } from './lucky-gallery/lucky-gallery.component';
import { FamiliesComponent } from './families/families.component';
import { NgbPopoverModule} from '@ng-bootstrap/ng-bootstrap';
import { FamilyDetailsComponent } from './family-details/family-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchFamiliesPipe } from 'app/pipes/search-families.pipe';

@NgModule({
  declarations: [

    DonateComponent,
      DonateFilterComponent,
      LuckyGalleryComponent,
      FamiliesComponent,
      FamilyDetailsComponent,
      SearchFamiliesPipe
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    NgbPopoverModule,
    FormsModule,
    ReactiveFormsModule
  ]
})


export class DonateModule {
  

}

