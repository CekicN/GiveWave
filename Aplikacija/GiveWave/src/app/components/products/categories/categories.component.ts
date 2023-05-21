import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Categories, category } from 'app/Models/Categories';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  
  categories!:any;
  constructor(private service:ProductService){}
  ngOnInit(): void {
    this.service.getCategories().subscribe(kategorije => {
      this.categories = kategorije
      // console.log(this.categories[0].category.podkategorije);
    });
  }

}
