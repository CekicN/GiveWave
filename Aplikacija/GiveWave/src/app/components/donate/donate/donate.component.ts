import { Component, OnInit } from '@angular/core';
import { Donate } from 'app/Models/Donate';
import { Porodica } from 'app/Models/Porodica';
import { PorodicaService } from 'app/services/porodica.service';
import { Observable , of} from 'rxjs';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})

export class DonateComponent implements OnInit {

  porodice$: Observable<Porodica[]> = of([]);

  constructor(private porodicaService: PorodicaService) {

  
  }

  ngOnInit(): void {
      this.porodice$ = this.porodicaService.getAll();
  }
      
}


