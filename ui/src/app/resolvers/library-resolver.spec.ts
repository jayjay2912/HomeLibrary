import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { libraryResolver } from './library-resolver';

describe('libraryResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => libraryResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
