import { Pipe, PipeTransform } from '@angular/core';
import { Product } from 'app/Models/Product';

@Pipe({
  name: 'searchProducts'
})
export class SearchProductsPipe implements PipeTransform {

  transform(items:Product[], searchText: string): Product[] {
    if(!items)
    {
      return [];
    }
    if(!searchText)
    {
      return items;
    }

    searchText = searchText.toLocaleLowerCase();
    return items.filter(it => {
      return it.naziv.toLocaleLowerCase().includes(searchText);
    });
  }

}
