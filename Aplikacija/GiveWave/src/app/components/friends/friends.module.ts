import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatComponent } from './chat/chat.component';
import { ChatInputComponent } from './chat-input/chat-input.component';
import { PrivateChatComponent } from './private-chat/private-chat.component';
import { MessagesComponent } from './messages/messages.component';
import { ChatMainComponent } from './chat-main/chat-main.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@microsoft/signalr';



@NgModule({
  declarations: [
    ChatMainComponent,
    ChatComponent,
    ChatInputComponent,
    PrivateChatComponent,
    MessagesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    ChatMainComponent
  ]
})
export class FriendsModule { }
