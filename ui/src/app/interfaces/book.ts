/**
 * A book in the library.
 */
export interface Book {
  title: string,
  author: string,
  shelfLocation: string | null,
  isReadByJay: boolean,
  isReadByGemma: boolean
}
