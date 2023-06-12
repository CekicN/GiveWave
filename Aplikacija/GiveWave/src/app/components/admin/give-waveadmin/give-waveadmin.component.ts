import { Component } from '@angular/core';

@Component({
  selector: 'app-give-waveadmin',
  templateUrl: './give-waveadmin.component.html',
  styleUrls: ['./give-waveadmin.component.css']
})
export class GiveWaveadminComponent {

  ruta!:string;
  goTo(putanja:string){
    this.ruta=putanja;
  }

}

