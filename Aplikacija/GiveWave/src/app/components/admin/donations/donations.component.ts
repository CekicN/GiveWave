import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { Donations } from 'app/Models/Donations';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.css']
})
export class DonationsComponent implements OnInit {
  constructor(private adminService:AdminService){}

  public donationsData : Donations[] | any = [];

  ngOnInit(): void {
    this.adminService.getDonations()
      .subscribe(res => {
        this.donationsData = res;
      })
  }
  removeDonacije(identifikator:any){
    this.adminService.removeDonations(identifikator).subscribe(p=>{this.donationsData=this.donationsData.filter((q:Donations)=>q.id!=identifikator)});
  }
}


