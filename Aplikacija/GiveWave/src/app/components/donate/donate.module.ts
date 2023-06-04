import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonateComponent } from './donate/donate.component';
import { PorodiceComponent } from './porodice/porodice.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { ChatComponent } from '../chat/chat.component';
import { ChatInputComponent } from '../chat-input/chat-input.component';
import { MessagesComponent } from '../messages/messages.component';
import { PrivateChatComponent } from '../private-chat/private-chat.component';



@NgModule({
  declarations: [
    DonateComponent,
    PorodiceComponent,
    ChatComponent,
    ChatInputComponent,
    MessagesComponent,
    PrivateChatComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class DonateModule {
  

}

