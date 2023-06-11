import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/user-auth/login/login.component';
import { SignupComponent } from './components/user-auth/signup/signup.component';
import { DonateComponent } from './components/donate/donate/donate.component';
import { ProductsComponent } from './components/products/products/products.component';
import { ProfileComponent } from './components/profile/profile/profile.component';
import { AuthGuard } from './Guards/auth.guard';
import { AboutComponent } from './components/about-us/about/about.component';
import { UserAuthModule } from './components/user-auth/user-auth.module';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ChatMainComponent } from './components/friends/chat-main/chat-main.component';
import { CartComponent } from './components/products/cart/cart.component';
import { GiveWaveadminComponent } from './components/admin/give-waveadmin/give-waveadmin.component';


const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'about', component:AboutComponent},
  {path: 'login', component:LoginComponent},
  {path: 'signup', component:SignupComponent},
  {path: 'donate', component:DonateComponent},
  {path: 'products', component:ProductsComponent},
  {path: 'profile/:email', component:ProfileComponent,canActivate:[AuthGuard]},
  {path: 'friends', component:ChatMainComponent},
  {path: 'reset', component:ResetPasswordComponent},
  {path: 'cart', component: CartComponent},
  {path: 'admin', component:GiveWaveadminComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
