import { TestBed } from '@angular/core/testing';

import { GetallcatigoriesService } from './getallcatigories.service';

describe('GetallcatigoriesService', () => {
  let service: GetallcatigoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetallcatigoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
