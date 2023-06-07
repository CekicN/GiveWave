import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonateFilterComponent } from './donate-filter.component';

describe('DonateFilterComponent', () => {
  let component: DonateFilterComponent;
  let fixture: ComponentFixture<DonateFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DonateFilterComponent]
    });
    fixture = TestBed.createComponent(DonateFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
