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
  iconsName:IconName[] = ['pen-to-square','pen-to-square','pen-to-square','pen-to-square'];
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faPenToSquare, faFloppyDisk);
  }
  ngOnInit(): void {
    this.service.getUsersById(1).subscribe(user => {
      this.user = user;
      this.service.email = user.email
    })
  }
  isVisible():boolean
  {
    //Email iz profila === email iz prijave
    return this.service.email === localStorage.getItem('email');
  }
  EditData(event:Event, num:number)
  {
    const edit = this.iconsName[num] === 'pen-to-square'?"true" :"false";
    const clicked = event.target as HTMLElement;
    
    const input = clicked.closest('div')?.querySelector('p');
    input!.setAttribute('contenteditable', edit);

    
    if(this.iconsName[num] === 'floppy-disk')
    {
      this.SaveChanges(input, num);
    }
    this.iconsName[num] = this.iconsName[num] === 'floppy-disk' ? 'pen-to-square' : 'floppy-disk';
  }
  SaveChanges(input:HTMLElement|undefined|null, num:number)
  {
    console.log(input?.innerHTML);
    if(input)
    {
      switch(num)
      {
        case 0:
          this.user.ime = input?.innerHTML.substring(0,input.innerHTML.indexOf(" "));
          this.user.prezime = input?.innerHTML.substring(input.innerHTML.indexOf(" ")+1);
        break;
        case 1:
          this.user.email = input?.innerHTML;
        break;
        case 2:
          this.user.brTelefona = input?.innerHTML;
        break;
        case 3:
          this.user.datumRodjenja = new Date(input?.innerHTML);
        break;
        default:
      }
      //poziv apija za update podataka update(user);
      console.log(this.user);
    }
  }
}
