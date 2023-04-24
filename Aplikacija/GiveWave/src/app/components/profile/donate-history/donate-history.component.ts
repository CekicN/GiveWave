import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { DonationHistory } from 'app/Models/DonationsHistory';

@Component({
  selector: 'app-donate-history',
  templateUrl: './donate-history.component.html',
  styleUrls: ['./donate-history.component.css']
})
export class DonateHistoryComponent implements OnInit {
  
  donations:DonationHistory[] = [];
  
  constructor(private service:ProfileService){}
  
  ngOnInit(): void {
    this.service.getDonations().subscribe(donation => {
      this.donations = donation;
    })
  }

  

}
