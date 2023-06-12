import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { User } from 'app/Models/User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit{
  public data: User[] | any=[];
  constructor(private adminService:AdminService){}
  ngOnInit(): void {
    this.adminService.getData()
      .subscribe(res => {
        this.data = res;
      })
  }
  removeUsera(item: string){
    this.adminService.removeUser(item);
  }
  changeRole(item:string){
    this.adminService.changeRoles(item);
  }
}


