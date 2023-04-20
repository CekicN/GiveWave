import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { ProfileDataComponent } from './profile-data/profile-data.component';



@NgModule({
  declarations: [
    ProfileComponent,
    ProfileDataComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[]
})
export class ProfileModule { }
