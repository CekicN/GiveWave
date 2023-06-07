import { Component } from '@angular/core';

@Component({
  selector: 'app-lucky-gallery',
  templateUrl: './lucky-gallery.component.html',
  styleUrls: ['./lucky-gallery.component.css']
})
export class LuckyGalleryComponent {

  stories:any = [
    {
      user:"Ceka",
      text:"Hvala svima sto ste pomogli" 
    },
    {
      user:"Steva",
      text:"Hvala svima sto ste pomogli" 
    },
    {
      user:"Dusan",
      text:"Hvala svima sto ste pomogli" 
    },
    {
      user:"Marta",
      text:"Hvala svima sto ste pomogli" 
    }]
}
