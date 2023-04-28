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
  editRadio = false;
  iconsName:IconName[] = ['pen-to-square','pen-to-square','pen-to-square','pen-to-square', 'pen-to-square','pen-to-square'];
  constructor(private service:ProfileService, library:FaIconLibrary){
    library.addIcons(faPenToSquare, faFloppyDisk);
  }
  ngOnInit(): void {
    this.service.getUser(localStorage.getItem('email')).subscribe(user => {
      this.user = user;
      console.log(this.user)
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
    
    let input:HTMLElement|null|undefined;
    
    if(num != 5)
    {
      input = clicked.closest('div')?.querySelector('p');
      input!.setAttribute('contenteditable', edit);
    }
    else
    {
      input = clicked.closest('div')?.querySelector('input:checked');
      this.editRadio= edit === "true"? true : false;
    }
    if(this.iconsName[num] === 'floppy-disk')
    {
      this.SaveChanges(input, num);
    }
    this.iconsName[num] = this.iconsName[num] === 'floppy-disk' ? 'pen-to-square' : 'floppy-disk';
  }
  SaveChanges(input:HTMLElement|undefined|null, num:number)
  {
    console.log(input?.innerHTML);
    if(input && this.user)
    {
      switch(num)
      {
        case 0:
          this.user.username = input?.innerHTML.substring(input.innerHTML.indexOf(" ")+1);
        break;
        case 1:
          this.user.email = input?.innerHTML;
        break;
        case 2:
          this.user.brojTelefona = input?.innerHTML;
        break;
        case 3:
          this.user.datumRodjenja = new Date(input?.innerHTML);
        break;
        case 4:
          this.user.adresa = input.innerText;
        break;
        case 5:
          let labela = input.closest('div')?.querySelector('label');
          if(labela)
            this.user.pol = labela?.innerText;
        break;
        default:
      }
      console.log(this.user);
      //poziv apija za update podataka update(user);
      this.service.updateUser(this.user).subscribe({
        next:(res) => {
          console.log(res);
        },
        error:(err)=> {
          console.log(err);
        }
      }) 
    }
  }
}
