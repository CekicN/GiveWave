import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
import { ProfileModule } from './components/profile/profile.module';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LastActiveService } from './components/services/last-active.service';

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
    ProductsModule,
    UserAuthModule,
    DonateModule,
    ReactiveFormsModule,   
    ProfileModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  providers: [
    {
      provide:APP_INITIALIZER,
      multi:true,
      deps:[LastActiveService],
      useFactory:(LastActiveService:LastActiveService) => () =>
      LastActiveService.setUp(),
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
