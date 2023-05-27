import { Component, Input, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { ProductService } from 'app/components/products/product.service';

@Component({
  selector: 'app-add-product-modal',
  templateUrl: './add-product-modal.component.html',
  styleUrls: ['./add-product-modal.component.css']
})
export class AddProductModalComponent implements OnInit{
  displayStyle:string = "none";
  other = false;
  categories!:Category[];
  cities!:any;

  status = ["New", "SecondHand"]
  constructor(private service:ProfileService, private productService:ProductService)
  {
    service.displayStyle.subscribe(d => this.displayStyle = d);
  }
  ngOnInit(): void {
    this.productService.getCategories().subscribe(p => {
      this.categories = extractCategories(p)
    });
    this.productService.getCities().subscribe(c => this.cities = c);
  }

  isOther(event:Event)
  {
    const select = <HTMLSelectElement>event.target;
    if(select.value == "others")
      this.other = true;
    else
      this.other = false;
  }
  closeModal()
  {
    this.service.closeModal();
  }
}

interface Category {
  id: number;
  name: string;
}

function extractCategories(data: any[]): Category[] {
  const categories: Category[] = [];

  data.forEach((item) => {
    const category: Category = {
      id: item.id,
      name: item.name,
    };
    categories.push(category);

    if (item.subcategories && item.subcategories.length > 0) {
      const subcategories = extractCategories(item.subcategories);
      categories.push(...subcategories);
    }
  });
  return categories;
}
