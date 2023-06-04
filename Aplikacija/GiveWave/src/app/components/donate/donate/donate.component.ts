import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { Donate } from 'app/Models/Donate';
import { Porodica } from 'app/Models/Porodica';
import { ChatService } from 'app/services/chat.service';
import { PorodicaService } from 'app/services/porodica.service';
import { Observable , of} from 'rxjs';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})

export class DonateComponent implements OnInit {

  userForm: FormGroup = new FormGroup({}); 
  submitted = false;
  apiErrorMessages: string[] = [];
  openChat =  false;

  /*porodice$: Observable<Porodica[]> = of([]);*/

  constructor(/*private porodicaService: PorodicaService,*/private fromBuilder: FormBuilder, private chatService: ChatService) {

  }

  ngOnInit(): void {
      /*this.porodice$ = this.porodicaService.getAll();*/
      this.initialzeForm();
  }
  initialzeForm() {
    this.userForm = this.fromBuilder.group({
      name: ['',[Validators.required, Validators.minLength(3), Validators.maxLength(15)]]
    })

  }
      
  submitForm(){
    this.submitted = true;
    this.apiErrorMessages = [];

    if(this.userForm.valid)
    {
      this.chatService.registerUser(this.userForm.value).subscribe({
        next: () => {
          this.chatService.myName = this.userForm.get('name')?.value;
          this.openChat = true;
          this.userForm.reset();
          this.submitted = false;
        },
        error: error => {
            if(typeof(error.error) !== 'object'){
              this.apiErrorMessages.push(error.error);
            }
        }

      })
    }
  }

  closeChat(){
    this.openChat = false;
  }
}


