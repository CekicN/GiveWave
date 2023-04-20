import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { User } from 'app/Models/User';

@Component({
  selector: 'app-profile-data',
  templateUrl: './profile-data.component.html',
  styleUrls: ['./profile-data.component.css']
})
export class ProfileDataComponent implements OnInit {
  
  users!:User[];
  constructor(private service:ProfileService){}
  ngOnInit(): void {
    this.service.getAll().subscribe(users => {
      this.users = users;
    })
  }

}
