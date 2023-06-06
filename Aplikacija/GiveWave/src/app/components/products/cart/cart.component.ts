import { Component , OnInit} from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faTrash, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { CartService } from '../cart.service';
import { Product } from 'app/Models/Product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public productss: Product[] | any = [];
  
  constructor(private library: FaIconLibrary, private cartService: CartService, private router: Router) {
    library.addIcons(faTrashAlt);
  }

  ngOnInit(): void {
    this.cartService.getProducts()
      .subscribe(res => {
        this.productss = res;
      })
  }

  removeItem(item: any){
    this.cartService.removeCartItem(item);
  }

  emptyCart(){
    this.cartService.removeAllCart();
  }

  goToProducts(){
    this.router.navigate(['/products']);
  }

}
