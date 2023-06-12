import { AsyncPipe, DecimalPipe, NgFor, NgIf } from '@angular/common';
import { FamilyServiceService } from '../family-service.service'; 
// import { SortableDirective, SortEvent } from '../sortable.directive';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ChangeDetectorRef, Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Observable } from 'rxjs';
import { Porodica } from 'app/Models/Porodica';
@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {
  	families!: Porodica[];
	serviceForm!:FormGroup;
	statusi = ['Less vulnerable', "Moderately vulnerable", "Highly vulnerable"];
	constructor(public service: FamilyServiceService,private fb:FormBuilder, private cdr:ChangeDetectorRef) {
		this.serviceForm = fb.group({
			status:['', Validators.required]
		})
	}
	ngOnInit(): void {
		this.service.getFamilies().subscribe(p => this.families = p);
	}

	overi(id:number)
	{
		if(this.serviceForm.valid)
		{
			this.service.overi(id, this.serviceForm.value['status']).subscribe(p => {
				this.families = this.families.filter(family => family.id !== id);
				this.cdr.detectChanges();
			});
		}
		else	
			this.validateAllFormsFields(this.serviceForm);
	}
	obrisi(id:number, email:string)
	{
		this.service.cancelAdding(id, email).subscribe(msg =>
		{		
			this.families = this.families.filter(family => family.id !== id);
			this.cdr.detectChanges();
		});
	}
	private validateAllFormsFields(formGroup:FormGroup){
		Object.keys(formGroup.controls).forEach(field=>{
		  const control = formGroup.get(field);
		  if(control instanceof FormControl){
			control.markAsDirty({
			  onlySelf:true
			});
		  }else if(control instanceof FormGroup){
			this.validateAllFormsFields(control);
		  }
		})
	
	  }
}
