import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { User } from 'app/Models/User';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-profile-data',
  templateUrl: './profile-data.component.html',
  styleUrls: ['./profile-data.component.css']
})
export class ProfileDataComponent implements OnInit {
  
  public user!:User;
  constructor(private service:ProfileService, private sanitizer: DomSanitizer){}
  ngOnInit(): void {
    this.service.getById(1).subscribe(user => {
      this.user = user;
    })
  }


}
