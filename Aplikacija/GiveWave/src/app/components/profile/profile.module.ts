import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { ProfileDataComponent } from './profile-data/profile-data.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProfileImageComponent } from './profile-image/profile-image.component';
import { SocialMediaComponent } from './social-media/social-media.component';
import { MyProductsComponent } from './my-products/my-products.component';



@NgModule({
  declarations: [
    ProfileComponent,
    ProfileDataComponent,
    ProfileImageComponent,
    SocialMediaComponent,
    MyProductsComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule
  ],
  exports:[]
})
export class ProfileModule { }
