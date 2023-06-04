import { Component,OnInit,Input,OnDestroy} from '@angular/core';
import { ChatService } from 'app/services/chat.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-private-chat',
  templateUrl: './private-chat.component.html',
  styleUrls: ['./private-chat.component.css']
})
export class PrivateChatComponent implements OnInit,OnDestroy {
  @Input() toUser = '';

  constructor(public activeModal: NgbActiveModal,public cahtService: ChatService) {}

  ngOnDestroy(): void {
      this.cahtService.closePrivateChatMessage(this.toUser);
  }

  ngOnInit(): void {
      
  }

  sendMessage(content: string){
    this.cahtService.sendPrivateMessage(this.toUser,content);

  }
}
