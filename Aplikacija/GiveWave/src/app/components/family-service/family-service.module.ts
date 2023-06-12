import { CommonModule} from '@angular/common';
import { NgModule } from '@angular/core';
import { FamilyServiceService } from './family-service.service';
import { ServiceComponent } from './service/service.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    ServiceComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
	],
  providers: [FamilyServiceService],
})
export class FamilyServiceModule { }
