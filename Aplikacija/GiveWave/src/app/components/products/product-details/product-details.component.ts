import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faShoppingCart, faXmark } from '@fortawesome/free-solid-svg-icons';
import { ProductInfo } from 'app/Models/ProductInfo';
import { AuthService } from 'app/services/auth.service';
import { ProfileService } from 'app/components/profile/profile.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  displayStyle:string = 'none';
  imageUrl:string[] = ["https://localhost:7200//uploads/common/noimage.png"];
  product!:ProductInfo;
  constructor(private service:ProductService, library:FaIconLibrary, private authService:AuthService, private profileService:ProfileService)
  {
    service.productDetails.subscribe(p => this.displayStyle = p);
    service.product.subscribe((p:ProductInfo) => this.product = p);
    library.addIcons(faXmark, faShoppingCart);
  }

  closeModal()
  {
    this.service.closeModal();
  }

  isVisible():boolean
  {
    //Email iz profila === email iz prijave
    return this.profileService.email === this.authService.email;
  }

}
