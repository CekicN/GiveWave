import { Component, Input } from '@angular/core';
@Component({
  selector: 'app-recursive-categories',
  templateUrl: './recursive-categories.component.html',
  styleUrls: ['./recursive-categories.component.css']
})
export class RecursiveCategoriesComponent {
  @Input() recursiveList:any;
}
