import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient,HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import {UserAuthModule} from './components/user-auth/user-auth.module';

import { AppComponent } from './components/app/app.component';
import { NavigationBarComponent } from './components/core/navigation-bar/navigation-bar.component';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { FooterBarComponent } from './components/core/footer-bar/footer-bar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsModule } from './components/products/products.module';
import { DonateModule } from './components/donate/donate.module';
<<<<<<< HEAD
import { AuthService } from 'app/services/auth.service';

=======
import { ProfileModule } from './components/profile/profile.module';
import { HttpClientModule } from '@angular/common/http';
>>>>>>> 6400b6ec6e186fc93adf523113794f6a400988b4

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
    UserAuthModule,
    ProductsModule,
    DonateModule,
    ReactiveFormsModule,
<<<<<<< HEAD
    HttpClientModule

=======
    ProfileModule,
    HttpClientModule
>>>>>>> 6400b6ec6e186fc93adf523113794f6a400988b4
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
