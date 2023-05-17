import { Component, OnInit } from '@angular/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { IconName, faBox, faUser, faPeopleGroup } from '@fortawesome/free-solid-svg-icons';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  naziv = ['Users', 'Products', 'Families'];
  iconsName:IconName[] = ['user', 'box','people-group'];
  vrednosti:number[] = [0, 0, 0];
  constructor(library:FaIconLibrary, private service:ServiceService)
  {
    library.addIcons(faUser,faBox,faPeopleGroup);
  }
  ngOnInit(): void {
    this.service.countUsers().subscribe(count => this.vrednosti[0] = count);
    this.service.countProducts().subscribe(count => this.vrednosti[1] = count);
  }

  

}
