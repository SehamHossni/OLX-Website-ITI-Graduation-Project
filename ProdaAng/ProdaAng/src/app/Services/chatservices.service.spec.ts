import { TestBed } from '@angular/core/testing';

import { ChatservicesService } from './chatservices.service';

describe('ChatservicesService', () => {
  let service: ChatservicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChatservicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
