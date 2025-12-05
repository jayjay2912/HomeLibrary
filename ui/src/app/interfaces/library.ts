import {Book} from './book';

/**
 * LibraryResponse response.
 */
export interface Library {
  message: string,
  books: Book[]
}
