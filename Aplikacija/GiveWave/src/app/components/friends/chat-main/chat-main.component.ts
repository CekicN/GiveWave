import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChatService } from '../chat.service'; 
import { HttpClient } from '@angular/common/http';
import { User } from 'app/Models/User';
import { ProfileService } from 'app/components/profile/profile.service';

@Component({
  selector: 'app-chat-main',
  templateUrl: './chat-main.component.html',
  styleUrls: ['./chat-main.component.css']
})
export class ChatMainComponent {
  userForm: FormGroup = new FormGroup({}); 
  submitted = false;
  apiErrorMessages: string[] = [];
  openChat =  false;


  constructor(private fromBuilder: FormBuilder, private chatService: ChatService) {

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
  closeCanvas()
  {
    const offCanvas = document.getElementById('offcanvasRight');
    if(offCanvas)
      offCanvas.classList.toggle('show');
  }

  getUserName(){
    var username = localStorage.getItem('username'); 
    if(username!== null)
    {
      this.chatService.myName = username;
    }   
   }

  submitForm(){
    this.submitted = true;
    this.apiErrorMessages = [];
    this.openChat = true;

    this.chatService.registerUser().subscribe({
      next: () => {
        this.getUserName();
        this.openChat = true;
        this.userForm.reset();
      }
    })
   /* if(this.userForm.valid)
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
    }*/
  }

  closeChat(){
    this.openChat = false;
  }
}
