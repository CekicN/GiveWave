import { TestBed } from '@angular/core/testing';

import { LastActiveService } from './last-active.service';

describe('LastActiveService', () => {
  let service: LastActiveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LastActiveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
