import { Component } from '@angular/core';
import { DonateService } from '../donate.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faArrowLeftLong, faHandHoldingHeart } from '@fortawesome/free-solid-svg-icons';
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-family-details',
  templateUrl: './family-details.component.html',
  styleUrls: ['./family-details.component.css']
})
export class FamilyDetailsComponent {

  data = ['City:', 'Address', 'Num of family memers', 'Phone number', 'Bank account']
  items = ['Majce', 'Patike', 'Igracke', 'Novac', 'itd'];
  constructor(private service:DonateService, private library:FaIconLibrary)
  {
    library.addIcons(faArrowLeftLong, faHandHoldingHeart);
  }

  viewFamilies()
  {
    this.service.setFalse();
  }
}
