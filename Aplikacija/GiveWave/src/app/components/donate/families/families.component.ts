import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faHandHoldingHeart } from '@fortawesome/free-solid-svg-icons';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';
import { DonateService } from '../donate.service';
import { Porodica } from 'app/Models/Porodica';
import { SearchFamiliesPipe } from 'app/pipes/search-families.pipe';
@Component({
  selector: 'app-families',
  templateUrl: './families.component.html',
  styleUrls: ['./families.component.css']
})
export class FamiliesComponent implements OnInit {

  families!:Porodica[];
  searchText:string = '';
  constructor(private library:FaIconLibrary, private service:DonateService)
  {
    library.addIcons(faHandHoldingHeart);
    service.searchText.subscribe(p => this.searchText = p);
  }
  ngOnInit(): void {
    this.service.getAllFamilies().subscribe(families => this.families = families )
  }

  viewFamily()
  {
    this.service.setTrue();
  }
}
