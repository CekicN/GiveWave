import { Component, OnInit } from '@angular/core';
import { User } from 'app/Models/User';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css']
})
export class ProfileImageComponent implements OnInit {
  public user!:User;
  constructor(private service:ProfileService){
  }
  ngOnInit(): void {
    this.service.getUsersById(1).subscribe(user => {
      this.user = user;
    })
  }
}
