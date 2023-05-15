import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about/about.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { StatisticsComponent } from './statistics/statistics.component';
import { WhatWeDoComponent } from './what-we-do/what-we-do.component';
import { ContactComponent } from './contact/contact.component';


@NgModule({
  declarations: [
    AboutComponent,
    StatisticsComponent,
    WhatWeDoComponent,
    ContactComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule
  ]
})
export class AboutUsModule { }
