import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faHandHoldingHeart } from '@fortawesome/free-solid-svg-icons';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';
import { DonateService } from '../donate.service';

@Component({
  selector: 'app-families',
  templateUrl: './families.component.html',
  styleUrls: ['./families.component.css']
})
export class FamiliesComponent {
  niz = [1,2,3,4,5,6,7,8];
  constructor(private library:FaIconLibrary, private service:DonateService)
  {
    library.addIcons(faHandHoldingHeart);
  }

  viewFamily()
  {
    this.service.setTrue();
  }
}
