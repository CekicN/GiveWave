import { Component,OnInit,Input,OnDestroy} from '@angular/core';
import { ChatService } from '../chat.service'; 
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-private-chat',
  templateUrl: './private-chat.component.html',
  styleUrls: ['./private-chat.component.css']
})
export class PrivateChatComponent implements OnInit,OnDestroy {
  @Input() toUser = '';

  constructor(public activeModal: NgbActiveModal,public chatService: ChatService) {}

  ngOnDestroy(): void {
      this.chatService.closePrivateChatMessage(this.toUser);
  }

  ngOnInit(): void {
      
  }

  sendMessage(content: string){
    this.chatService.sendPrivateMessage(this.toUser,content);

  }
}
