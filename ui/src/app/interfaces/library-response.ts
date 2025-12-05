import {Book} from './book';

/**
 * LibraryResponse response.
 */
export interface LibraryResponse {
  message: string,
  books: Book[]
}
