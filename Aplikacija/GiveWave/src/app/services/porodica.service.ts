import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Porodica } from 'app/Models/Porodica';
import { environment } from 'environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class PorodicaService {

  constructor(private httpClient: HttpClient){

  }

  getAll(){
    return this.httpClient
        .get<Porodica[]>(environment.api + "/porodice");
  }
}
