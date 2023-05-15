import { Component } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { IconName, faBox, faUser, faPeopleGroup } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent {

  naziv = ['Users', 'Products', 'Families'];
  iconsName:IconName[] = ['user', 'box','people-group'];
  vrednosti = [1561, 15615, 486];
  constructor(library:FaIconLibrary)
  {
    library.addIcons(faUser,faBox,faPeopleGroup);
  }
}
