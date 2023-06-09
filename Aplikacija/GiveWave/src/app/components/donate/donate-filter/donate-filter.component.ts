import { Component, OnInit } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import { ProductService } from 'app/components/products/product.service';

@Component({
  selector: 'app-donate-filter',
  templateUrl: './donate-filter.component.html',
  styleUrls: ['./donate-filter.component.css']
})
export class DonateFilterComponent implements OnInit {

  cities!:any;
  searchText:string = '';
  status = ['Bas ugrozeni', 'srednje ugrozeni', 'malo ugrozeni'];
  constructor(private service:ProductService, private library:FaIconLibrary)
  {
    library.addIcons(faMagnifyingGlass)
  }
  ngOnInit(): void {
    this.service.getCities().subscribe(p => this.cities = p);
  }
}
