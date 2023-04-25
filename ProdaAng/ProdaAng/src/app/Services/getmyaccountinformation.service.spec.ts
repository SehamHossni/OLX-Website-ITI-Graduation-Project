import { TestBed } from '@angular/core/testing';

import { GetmyaccountinformationService } from './getmyaccountinformation.service';

describe('GetmyaccountinformationService', () => {
  let service: GetmyaccountinformationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetmyaccountinformationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
