import {AfterContentInit, AfterViewInit, Component, DestroyRef, inject, OnInit} from '@angular/core';
import {TableModule} from 'primeng/table';
import {FormsModule} from '@angular/forms';
import {Tag} from 'primeng/tag';
import {InputText} from 'primeng/inputtext';
import {LibraryService} from '../../services/library-service';
import {Book} from '../../interfaces/book';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';
import {delay, distinctUntilChanged, tap} from 'rxjs';
import {LibraryResponse} from '../../interfaces/library-response';

@Component({
  selector: 'app-landing-page',
  imports: [
    TableModule,
    FormsModule,
    Tag,
    InputText,
  ],
  templateUrl: './landing-page.html',
  styleUrl: './landing-page.css',
})
export class LandingPage {
  private readonly _library = inject(LibraryService);
  private destroyRef = inject(DestroyRef);

  /**
   * The library
   */
  public library: LibraryResponse | null = null;

  /**
   *  Get the library
   */
  getLibrary(): void {
    this._library.getLibrary()
      .pipe(takeUntilDestroyed(this.destroyRef), distinctUntilChanged())
      .subscribe({
        next: response => {
          console.log("Fetched", response);
          this.library = response;
        },
        error: err => {
          console.log(err);
        }
      })
  }
}
