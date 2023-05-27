import { Component } from '@angular/core';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  displayStyle:string = "none";
  constructor(service:ProfileService)
  {
    service.displayStyle.subscribe(d => {
      this.displayStyle = d
      console.log(this.displayStyle);
    });
  }
}
