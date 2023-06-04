import { Component, EventEmitter, OnInit, Output , OnDestroy} from '@angular/core';
import { ChatService } from 'app/services/chat.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap/modal/modal.module';
import { PrivateChatComponent } from '../private-chat/private-chat.component';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit, OnDestroy{

  @Output() closeChatEmitter = new EventEmitter();

  constructor(public chatService: ChatService,private modalService: NgbModal) {
    
  }

  ngOnDestroy(): void {
      this.chatService.stopConnection();
  }

  ngOnInit(): void {
      this.chatService.createChatConnection();
  }

  backToHome(){
    this.closeChatEmitter.emit();
  }

  sendMessage(content: string){
    this.chatService.sendMessage(content);
  }

  openPrivateChat(toUser: string){
    const modalRef = this.modalService.open(PrivateChatComponent);
    modalRef.componentInstance,toUser = toUser;
  }

}
