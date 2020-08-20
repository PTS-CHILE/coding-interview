import { TestBed } from '@angular/core/testing';

import { LoaderHelperService } from './loader-helper.service';

describe('LoaderHelperService', () => {
  let service: LoaderHelperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoaderHelperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
