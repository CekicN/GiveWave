import { Component, OnInit } from '@angular/core';
import { User } from 'app/Models/User';
import { ProfileService } from '../profile.service';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css']
})
export class ProfileImageComponent implements OnInit {
  public user!:User;
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faHeart);
  }
  ngOnInit(): void {
    this.service.getUsersById(1).subscribe(user => {
      this.user = user;
    })
  }
  like()
  {
    
    const icon = document.querySelector('.srce');
    if(icon!.getAttribute('style') === null)
    {
      this.user.lajkovi++;
      icon?.setAttribute('style', 'color:red;');
    }
    else
    {
      this.user.lajkovi--;
      icon?.removeAttribute('style');
    }
  }
}
