import { Component, OnInit } from '@angular/core';
import { DonateService } from '../donate.service';


@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})

export class DonateComponent{

  prikaz!:boolean;
  constructor(private service:DonateService)
  {
    service.view.subscribe(p => this.prikaz = p);
  }
 
}


