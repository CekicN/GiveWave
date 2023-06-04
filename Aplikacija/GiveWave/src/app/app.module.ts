import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient,HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import {UserAuthModule} from './components/user-auth/user-auth.module';

import { AppComponent } from './components/app/app.component';
import { NavigationBarComponent } from './components/core/navigation-bar/navigation-bar.component';
import { HomeComponent } from './components/home/home.component';
import { FooterBarComponent } from './components/core/footer-bar/footer-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsModule } from './components/products/products.module';
import { DonateModule } from './components/donate/donate.module';

import { ProfileModule } from './components/profile/profile.module';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AboutUsModule } from './components/about-us/about-us.module';
import { DonateComponent } from './components/donate/donate/donate.component';
<<<<<<< HEAD
import { ChatComponent } from './components/chat/chat.component';
import { ChatInputComponent } from './components/chat-input/chat-input.component';
import { MessagesComponent } from './components/messages/messages.component';
import { PrivateChatComponent } from './components/private-chat/private-chat.component';
=======
import { SearchProductsPipe } from './pipes/search-products.pipe';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { AuthService } from './services/auth.service';
>>>>>>> 0693e4a1c11776dca4e7dfb98d4ec6d5b7e5db49

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
    FormsModule,
    AppRoutingModule,
    ProductsModule,
    UserAuthModule,
    ReactiveFormsModule,
    HttpClientModule,
    ProfileModule,
    DonateModule,
    FontAwesomeModule,
    AboutUsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
