import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { User } from 'app/Models/User';
import { ProfileService } from '../profile.service';
import { faHeart, faPen } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css']
})
export class ProfileImageComponent implements OnInit {
  
  public user!:User;
  public isLiked:boolean = localStorage.getItem('like') === 'true';
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faHeart, faPen);
  }
   ngOnInit(): void {
    this.service.getUser(localStorage.getItem('email')).subscribe(user => {
      this.user = user;
    })
   }
  isVisible():boolean
  {
    //Email iz profila === email iz prijave
    return this.service.email === localStorage.getItem('email');
  }
  onFileSelected(event:Event)//uzimanje slike sa racunara
  {
    const f = (<HTMLInputElement>event.target)?.files?.[0];
    if(f)
    {
      this.service.updateProfilePicture(f,localStorage.getItem('email')).subscribe((imageUrl) => {
        this.user.imageUrl = imageUrl.imageUrl;
      })
    }
    
  }
  HeartColor():string
  {
    if(this.isLiked)
    {
      return "color:red;";
    }
    return "color:grey;";
  }
  like()
  {
    
    if(!this.isLiked)
    {
      this.service.Like(this.user.email).subscribe(lajk => this.user.lajkovi = lajk);
      localStorage.setItem('like', 'true');
      this.isLiked = true;
    }
    else
    {
      this.service.Dislike(this.user.email).subscribe(dislajk => this.user.lajkovi = dislajk);
      localStorage.removeItem('like');
      this.isLiked = false;
    }
  }

}
