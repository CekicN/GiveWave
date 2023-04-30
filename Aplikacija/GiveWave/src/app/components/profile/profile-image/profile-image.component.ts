import { Component, OnInit } from '@angular/core';
import { User } from 'app/Models/User';
import { ProfileService } from '../profile.service';
import { faHeart, faPen } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { Picture } from 'app/Models/UserAvatar';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css']
})
export class ProfileImageComponent implements OnInit {
  public user!:User;
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
      this.service.updateProfilePicture(f,localStorage.getItem('email')).subscribe((imageUrl:string) => {
        console.log(imageUrl);
        this.user.imageUrl = imageUrl;
      })
    }
    
  }
  
  // like()
  // {
    
  //   const icon = document.querySelector('.srce');
  //   if(icon!.getAttribute('style') === null)
  //   {
  //     this.user.lajkovi++;
  //     icon?.setAttribute('style', 'color:red;');
  //   }
  //   else
  //   {
  //     this.user.lajkovi--;
  //     icon?.removeAttribute('style');
  //   }
  // }

}
