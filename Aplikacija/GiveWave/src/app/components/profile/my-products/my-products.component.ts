import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { MyProducts } from 'app/Models/MyProducts';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProfileDataComponent } from '../profile-data/profile-data.component';
import { User } from 'app/Models/User';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.css']
})
export class MyProductsComponent implements OnInit {

  naslov:string[] = ["Name", "Description"]
  searchText = '';
  email!:string|null;
  products:MyProducts[] = [];
  constructor(private services:ProfileService, private route:ActivatedRoute) {
  }
  ngOnInit(): void {
    this.email = this.route.snapshot.paramMap.get('email');
    this.services.getMyProducts(this.email).subscribe(p => {
      this.products = p;
      console.log(this.products);
    })
    console.log(localStorage);
  }
  isVisible():boolean
  {
    //Email iz profila === email iz prijave
    return this.services.email === localStorage.getItem('email');
  }
  deleteProduct(id:number)
  {
    this.services.cancelAdding(id,this.email).subscribe(msg => {
      console.log(msg)
    });
  }
}
