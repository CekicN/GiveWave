import { Component } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products = ['Majca 2XL NOVO!!!','Farmerice 2XL NOVO!!!','Jakna 2XL NOVO!!!', 'Majca 2XL NOVO!!!' , 'Trenerka 2XL NOVO!!!']
  constructor(library:FaIconLibrary)
  {
    library.addIcons(faShoppingCart);
  }

  addToCart(event:Event)
  {
    console.log(event.target);
  }
}
