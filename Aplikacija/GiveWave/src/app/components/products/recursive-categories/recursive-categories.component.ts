import { Component, Input, OnInit } from '@angular/core';
@Component({
  selector: 'app-recursive-categories',
  templateUrl: './recursive-categories.component.html',
  styleUrls: ['./recursive-categories.component.css']
})
export class RecursiveCategoriesComponent {
  
  @Input() recursiveList!:any;
  opened:boolean = false;

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
  navigate(routerLink: any) {
    //metoda za vracanje proizvoda po nazivu kategorije
    console.log(routerLink);
  }
}
