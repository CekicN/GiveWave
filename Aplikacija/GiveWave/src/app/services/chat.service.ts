import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserChat } from 'app/Models/UserChat';
import { environment } from 'environments/environment.prod';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Message } from 'app/Models/Message';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap/modal/modal';
import { PrivateChatComponent } from 'app/components/private-chat/private-chat.component';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  myName: string = "";
  private chatConnection?: HubConnection;
  onlineUsers: string[] = [];
  messages: Message[] = [];
  privateMessages: Message[] = [];
  privateMessageInitiated = false;


  constructor(private httpClient: HttpClient, private modalService: NgbModal ) { }

  registerUser(user: UserChat){
    const formData = new FormData();
    formData.append("ime",user.name);
    return this.httpClient.post(`https://localhost:7200/api/Chat/register-user`, formData );
  }

  createChatConnection() {
    this.chatConnection = new HubConnectionBuilder()
         .withUrl(`https://localhost:7200/hubs/chat`).withAutomaticReconnect().build();

         this.chatConnection.start().catch(error => {
          console.log(error);
         });

         this.chatConnection.on('UserConnected', () => {
          this.addUserConnectionId();
         });

         this.chatConnection.on('OnlineUsers', (onlineUsers) => {
          this.onlineUsers = [...onlineUsers];
         });

         this.chatConnection.on('NewMessage', (newMessage: Message) => {
          this.messages = [...this.messages, newMessage];
         });

         this.chatConnection.on('OpenPrivateChat', (newMessage: Message) => {
          this.privateMessages = [...this.privateMessages, newMessage];
          this.privateMessageInitiated = true;
          const modalRef = this.modalService.open(PrivateChatComponent);
          modalRef.componentInstance.toUser = newMessage.from;
         });

         this.chatConnection.on('NewPrivateMessage', (newMessage: Message) => {
          this.privateMessages = [...this.privateMessages, newMessage];
         });

         this.chatConnection.on('ClosePrivateChat', () => {
          this.privateMessageInitiated = false;
          this.privateMessages = [];
          this.modalService.dismissAll();
         })
  }

  stopConnection(){
    this.chatConnection?.stop().catch(error => console.log(error));
  }

  async addUserConnectionId(){
    return this.chatConnection?.invoke('AddUserConnectionId', this.myName)
    .catch(error => console.log(error));
  }

  async sendMessage(content: string)
  {
    const message: Message = {
      from: this.myName,
      content
    };

    return this.chatConnection?.invoke('ReceiveMessage', message)
      .catch(error => console.log(error));
  }

  async sendPrivateMessage(to: string,content: string){
    const message: Message = {
      from: this.myName,
      to,
      content
    };

    if(!this.privateMessageInitiated){
      this.privateMessageInitiated = true;
      return this.chatConnection?.invoke('CreatePrivateChat', message).then(() => {
        this.privateMessages = [...this.privateMessages, message];
      })
      .catch(error => console.log(error));          
    }else{
      return this.chatConnection?.invoke('ReceivePrivateMessage', message)
      .catch(error => console.log(error));
    }
  }

  async closePrivateChatMessage(otherUser: string) {
    return this.chatConnection?.invoke('RemovePrivateChat', this.myName, otherUser)
    .catch(error => console.log(error));
  }
}
