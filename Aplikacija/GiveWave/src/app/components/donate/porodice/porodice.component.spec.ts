import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PorodiceComponent } from './porodice.component';

describe('PorodiceComponent', () => {
  let component: PorodiceComponent;
  let fixture: ComponentFixture<PorodiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PorodiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PorodiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
