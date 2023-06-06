import { Component } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faTrash, faTrashAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {

  constructor(private library: FaIconLibrary) {
    library.addIcons(faTrashAlt);
  }

}
