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
<<<<<<< HEAD
import { UserAuthModule } from './components/user-auth/user-auth.module';
=======
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
>>>>>>> 0693e4a1c11776dca4e7dfb98d4ec6d5b7e5db49

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'about', component:AboutComponent},
  {path: 'login', component:LoginComponent},
  {path: 'signup', component:SignupComponent},
  {path: 'donate', component:DonateComponent},
  {path: 'products', component:ProductsComponent},
<<<<<<< HEAD
  {path: 'profile', component:ProfileComponent,canActivate:[AuthGuard]}
 
=======
  {path: 'profile/:email', component:ProfileComponent,canActivate:[AuthGuard]},
  {path: 'reset', component:ResetPasswordComponent}
>>>>>>> 0693e4a1c11776dca4e7dfb98d4ec6d5b7e5db49
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
