import { TestBed } from '@angular/core/testing';

import { ActiveguradService } from './activegurad.service';

describe('ActiveguradService', () => {
  let service: ActiveguradService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActiveguradService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
