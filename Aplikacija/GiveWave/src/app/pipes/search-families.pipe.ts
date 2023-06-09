import { Pipe, PipeTransform } from '@angular/core';
import { Porodica } from 'app/Models/Porodica';

@Pipe({
  name: 'searchFamilies'
})
export class SearchFamiliesPipe implements PipeTransform {

  transform(items:Porodica[], searchText: string): Porodica[] {
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
