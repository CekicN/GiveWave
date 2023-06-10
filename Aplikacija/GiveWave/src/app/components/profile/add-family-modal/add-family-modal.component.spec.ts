import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFamilyModalComponent } from './add-family-modal.component';

describe('AddFamilyModalComponent', () => {
  let component: AddFamilyModalComponent;
  let fixture: ComponentFixture<AddFamilyModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddFamilyModalComponent]
    });
    fixture = TestBed.createComponent(AddFamilyModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
