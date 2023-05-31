import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faShoppingCart, faXmark } from '@fortawesome/free-solid-svg-icons';
import { ProductInfo } from 'app/Models/ProductInfo';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  displayStyle:string = 'none';
  imageUrl:string[] = ["https://localhost:7200//uploads/common/noimage.png"];
  product!:ProductInfo;
  constructor(private service:ProductService, library:FaIconLibrary)
  {
    service.productDetails.subscribe(p => this.displayStyle = p);
    service.product.subscribe((p:ProductInfo) => this.product = p);
    library.addIcons(faXmark, faShoppingCart);
  }

  closeModal()
  {
    this.service.closeModal();
  }

}
