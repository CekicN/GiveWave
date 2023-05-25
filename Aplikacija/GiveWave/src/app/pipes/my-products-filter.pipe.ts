import { Pipe, PipeTransform } from '@angular/core';
import { MyProducts } from 'app/Models/MyProducts';

@Pipe({
  name: 'myProductsFilter'
})
export class MyProductsFilterPipe implements PipeTransform {

  transform(items: MyProducts[], searchText: string): MyProducts[] {
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
