import { TestBed } from '@angular/core/testing';

import { GetvendorinfoService } from './getvendorinfo.service';

describe('GetvendorinfoService', () => {
  let service: GetvendorinfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetvendorinfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
