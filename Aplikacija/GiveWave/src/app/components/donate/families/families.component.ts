import { Component, ElementRef, ViewChild } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faHandHoldingHeart } from '@fortawesome/free-solid-svg-icons';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-families',
  templateUrl: './families.component.html',
  styleUrls: ['./families.component.css']
})
export class FamiliesComponent {

  niz = [1,1,1,1,1,1,1,1];
  constructor(private library:FaIconLibrary)
  {
    library.addIcons(faHandHoldingHeart);
  }

}
