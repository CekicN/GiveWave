import { ChangeDetectorRef, Component , OnInit} from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faTrash, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { CartService } from '../cart.service';
import { Product } from 'app/Models/Product';
import { Router } from '@angular/router';
import { ProfileService } from 'app/components/profile/profile.service';
import { MyProducts } from 'app/Models/MyProducts';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  email!:string|null;
  //products:MyProducts[] = [];
  public productss: Product[] | any = [];
  
  constructor(private library: FaIconLibrary, private cartService: CartService, private router: Router,
    private profileService: ProfileService,private cdr:ChangeDetectorRef, private httpClient: HttpClient) {
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

  removeProductFromUserEmail(){
    this.productss.forEach( (element: Product) => {
      this.profileService.cancelAdding(element.id,this.email).subscribe(() => {
        this.productss = this.productss.filter( (ab: Product) => ab.id !== element.id);
        this.cdr.detectChanges();
    });

    
     this.productss.forEach((element: Product) => {

        this.cartService.sendEmailProducts(element.email).subscribe(p => console.log(p));
      
     });
     

      


    });
  }
}
