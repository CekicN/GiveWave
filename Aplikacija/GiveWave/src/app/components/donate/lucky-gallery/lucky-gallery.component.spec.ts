import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LuckyGalleryComponent } from './lucky-gallery.component';

describe('LuckyGalleryComponent', () => {
  let component: LuckyGalleryComponent;
  let fixture: ComponentFixture<LuckyGalleryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LuckyGalleryComponent]
    });
    fixture = TestBed.createComponent(LuckyGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
