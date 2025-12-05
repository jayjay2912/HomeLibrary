import { ResolveFn } from '@angular/router';
import {Library} from '../interfaces/library';
import {inject} from '@angular/core';
import {LibraryService} from '../services/library-service';
import {catchError, of} from 'rxjs';

export const libraryResolver: ResolveFn<Library | null> = (route, state) => {
  const _library = inject(LibraryService);
  return _library.getLibrary()
    .pipe(catchError((error) => {
      return of(null)
    }))
};
