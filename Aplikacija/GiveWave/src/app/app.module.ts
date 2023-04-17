import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD

=======
>>>>>>> e73a1557ff337c603b4164c7c9d51ff3c0c47e4f
import { AppRoutingModule } from './app-routing.module';
import {UserAuthModule} from './components/user-auth/user-auth.module';

import { AppComponent } from './components/app/app.component';
import { NavigationBarComponent } from './components/core/navigation-bar/navigation-bar.component';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { FooterBarComponent } from './components/core/footer-bar/footer-bar.component';
<<<<<<< HEAD
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ReactiveFormsModule } from '@angular/forms';
=======
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import { ProductsModule } from './components/products/products.module';
import { DonateModule } from './components/donate/donate.module';
>>>>>>> e73a1557ff337c603b4164c7c9d51ff3c0c47e4f

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutUsComponent,
    NavigationBarComponent,
    FooterBarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
<<<<<<< HEAD
    ReactiveFormsModule
=======
    UserAuthModule,
    FontAwesomeModule,
    ProductsModule,
    DonateModule
>>>>>>> e73a1557ff337c603b4164c7c9d51ff3c0c47e4f
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
