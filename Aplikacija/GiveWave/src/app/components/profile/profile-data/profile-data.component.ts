import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { User } from 'app/Models/User';
import {faInstagram, faFacebook, faTwitter, faGithub} from '@fortawesome/free-brands-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-profile-data',
  templateUrl: './profile-data.component.html',
  styleUrls: ['./profile-data.component.css']
})
export class ProfileDataComponent implements OnInit {
  
  public user!:User;
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faInstagram, faFacebook, faTwitter, faGithub);
  }
  ngOnInit(): void {
    this.service.getUsersById(1).subscribe(user => {
      this.user = user;
    })
  }


}
