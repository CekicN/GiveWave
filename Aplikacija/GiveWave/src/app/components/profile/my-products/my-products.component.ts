import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { MyProducts } from 'app/Models/MyProducts';
import { MyProductsFilterPipe } from 'app/pipes/my-products-filter.pipe';
import { ProfileDataComponent } from '../profile-data/profile-data.component';
import { User } from 'app/Models/User';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'app/components/products/product.service';
import { ProductInfo } from 'app/Models/ProductInfo';
import { AuthService } from 'app/services/auth.service';
import { Subscription } from 'rxjs';
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
  constructor(private services:ProfileService,
              private authService:AuthService,
              private route:ActivatedRoute,
              private productService:ProductService,
              private cdr:ChangeDetectorRef) 
  {    
    services.getClickEvent().subscribe(() => {this.getMyProducts();});
  }
  ngOnInit(): void {
    this.getMyProducts();
  }
  getMyProducts()
  {
    this.email = this.route.snapshot.paramMap.get('email');
    this.services.getMyProducts(this.email).subscribe(p => {
      this.products = p;
      this.cdr.detectChanges();
    })
  }
  isVisible():boolean
  {
    //Email iz profila === email iz prijave
    return this.services.email === this.authService.email;
  }
  deleteProduct(id:number)
  {
    this.services.cancelAdding(id,this.email).subscribe(() => {
      this.products = this.products.filter(product => product.id !== id);
      this.cdr.detectChanges();
    });
  }

  viewDetails(id:number)
  {
    this.productService.getMoreInfo(id).subscribe((p:ProductInfo) => {
      let product:ProductInfo = p;
      this.productService.setProduct(product);
      this.productService.openModal();
    })
  }
}
