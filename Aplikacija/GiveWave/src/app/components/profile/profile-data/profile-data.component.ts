import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { User } from 'app/Models/User';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { IconName, faFloppyDisk, faPenToSquare } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-profile-data',
  templateUrl: './profile-data.component.html',
  styleUrls: ['./profile-data.component.css']
})
export class ProfileDataComponent implements OnInit {
  
  public user!:User;
  icon:IconName = 'pen-to-square';
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faPenToSquare, faFloppyDisk);
  }
  ngOnInit(): void {
    this.service.getUsersById(1).subscribe(user => {
      this.user = user;
      this.service.email = user.email
    })
  }
  EditData(event:Event)
  {
    const edit = this.icon === 'pen-to-square'?"true" :"false";
    const kliknut = event.target as HTMLElement;
    const input = kliknut.closest('div')?.querySelector('p');
    input!.setAttribute('contenteditable', edit);

    this.icon = this.icon === 'floppy-disk' ? 'pen-to-square' : 'floppy-disk';
    if(this.icon === 'floppy-disk')
    {
      this.SaveChanges(input);
    }
  }
  SaveChanges(input:HTMLElement|undefined|null)
  {
    //metoda koja cuva izmene
  }
}
