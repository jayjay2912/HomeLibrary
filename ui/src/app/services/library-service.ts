import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LibraryResponse} from '../interfaces/library-response';

@Injectable({
  providedIn: 'root',
})
/**
 * This service is responsible for interfacing with the API to manage the library.
 */
export class LibraryService {
  private http = inject(HttpClient);

  /**
   * Fetch books from the library.
   */
  public getLibrary() {
    return this.http.get<LibraryResponse>('/api/GetBooks');
  }
}
