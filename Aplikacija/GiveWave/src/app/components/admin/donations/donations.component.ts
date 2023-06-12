import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.css']
})
export class DonationsComponent implements OnInit {
  constructor(private adminService:AdminService){}

  public donationsData : any[] = [];

  ngOnInit(): void {
    this.adminService.getDonations()
      .subscribe(res => {
        this.donationsData = res;
      })
  }
}


