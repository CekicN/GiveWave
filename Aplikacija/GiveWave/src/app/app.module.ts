import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient,HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import {UserAuthModule} from './components/user-auth/user-auth.module';

import { AppComponent } from './components/app/app.component';
import { NavigationBarComponent } from './components/core/navigation-bar/navigation-bar.component';
import { HomeComponent } from './components/home/home.component';
import { FooterBarComponent } from './components/core/footer-bar/footer-bar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsModule } from './components/products/products.module';
import { DonateModule } from './components/donate/donate.module';

import { ProfileModule } from './components/profile/profile.module';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AboutUsModule } from './components/about-us/about-us.module';
import { DonateComponent } from './components/donate/donate/donate.component';
import { SearchProductsPipe } from './pipes/search-products.pipe';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationBarComponent,
    FooterBarComponent,
    ResetPasswordComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProductsModule,
    UserAuthModule,
    DonateModule,
    ReactiveFormsModule,
    HttpClientModule,
    ProfileModule,
    FontAwesomeModule,
    AboutUsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
