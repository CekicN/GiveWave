import { TestBed } from '@angular/core/testing';

import { PorodicaService } from './porodica.service';

describe('PorodicaService', () => {
  let service: PorodicaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PorodicaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
