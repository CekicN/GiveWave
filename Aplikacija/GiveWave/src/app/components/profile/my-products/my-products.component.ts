import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { MyProducts } from 'app/Models/MyProducts';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProfileDataComponent } from '../profile-data/profile-data.component';
@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.css']
})
export class MyProductsComponent implements OnInit {

  naslov:string[] = ["Name", "Description"]
  searchText = '';
  ownEmail = localStorage.getItem('email');
  products:MyProducts[] = [];
  constructor(private services:ProfileService) {
  }
  ngOnInit(): void {
    this.services.getMyProducts().subscribe(p => {
      this.products = p;
      console.log(this.products);
    })
    console.log(localStorage);
  }
  
  isVisible():boolean
  {
    if(this.services.user.email === this.ownEmail)
    {
      return true;
    }
    return false;
  }
}
