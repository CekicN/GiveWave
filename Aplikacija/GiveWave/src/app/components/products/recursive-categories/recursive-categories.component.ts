import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
@Component({
  selector: 'app-recursive-categories',
  templateUrl: './recursive-categories.component.html',
  styleUrls: ['./recursive-categories.component.css']
})
export class RecursiveCategoriesComponent {
  
  @Input() recursiveList!:any;
  opened:boolean = false;

  constructor(private service:ProductService)
  {

  }
  toggleSubmenu() {
    this.opened = !this.opened;
  }
  open()
  {
    this.opened = true;
  }
  close()
  {
    this.opened = false;
  }
  navigate(routerLink: string) {
    this.service.setCategory(routerLink);
  }
}
