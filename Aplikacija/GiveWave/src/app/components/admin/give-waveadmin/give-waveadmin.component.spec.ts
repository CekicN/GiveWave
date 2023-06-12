import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiveWaveadminComponent } from './give-waveadmin.component';

describe('GiveWaveadminComponent', () => {
  let component: GiveWaveadminComponent;
  let fixture: ComponentFixture<GiveWaveadminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GiveWaveadminComponent]
    });
    fixture = TestBed.createComponent(GiveWaveadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
