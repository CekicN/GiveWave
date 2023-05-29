import { Component, Input, OnInit, Output } from '@angular/core';
import { Porodica } from 'app/Models/Porodica';

@Component({
  selector: 'app-porodice',
  templateUrl: './porodice.component.html',
  styleUrls: ['./porodice.component.css']
})
export class PorodiceComponent implements OnInit{
  
  @Input() porodica: Porodica | null = null;
  
  constructor() {}

  ngOnInit(): void {
      
  }
  
}
