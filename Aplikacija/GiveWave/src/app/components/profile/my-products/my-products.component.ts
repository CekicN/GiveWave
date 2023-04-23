import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { MyProducts } from 'app/Models/MyProducts';

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.css']
})
export class MyProductsComponent implements OnInit {

  naslov:string[] = ["Name", "Category"]
  products:MyProducts[] = [];
  constructor(private services:ProfileService) {}
  ngOnInit(): void {
    this.services.getMyProducts().subscribe(p => {
      this.products = p;
      console.log(this.products);
    })
  }

  
}
