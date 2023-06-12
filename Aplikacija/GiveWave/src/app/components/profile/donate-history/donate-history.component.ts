import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { DonationHistory } from 'app/Models/DonationsHistory';
import { AuthService } from 'app/services/auth.service';

@Component({
  selector: 'app-donate-history',
  templateUrl: './donate-history.component.html',
  styleUrls: ['./donate-history.component.css']
})
export class DonateHistoryComponent implements OnInit {
  
  donations:DonationHistory[] = [];
  
  constructor(private service:ProfileService, private authService:AuthService){}
  
  ngOnInit(): void {
    this.service.getDonations(this.authService.email).subscribe(donation => {
      this.donations = donation;
    })
  }

  

}
