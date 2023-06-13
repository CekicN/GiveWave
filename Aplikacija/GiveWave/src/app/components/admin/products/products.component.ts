import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { Product } from 'app/Models/Product';
import { ProductInfo } from 'app/Models/ProductInfo';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public productss : Product | any = [];
  constructor(private adminService:AdminService){}
  ngOnInit(): void {
    this.adminService.getProducts()
      .subscribe(res => {
        this.productss = res;
      })
  }
  removeProducta(iden: number){
    this.adminService.removeProducts(iden).subscribe(p=>{this.productss=this.productss.filter((q:Product)=>q.id!=iden)});
  }


}
