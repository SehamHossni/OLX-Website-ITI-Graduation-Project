import { TestBed } from '@angular/core/testing';

import { GetallprodsService } from './getallprods.service';

describe('GetallprodsService', () => {
  let service: GetallprodsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetallprodsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
