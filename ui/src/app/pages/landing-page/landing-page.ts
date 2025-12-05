import {Component, input} from '@angular/core';
import {TableModule} from 'primeng/table';
import {FormsModule} from '@angular/forms';
import {Tag} from 'primeng/tag';
import {InputText} from 'primeng/inputtext';
import {Library} from '../../interfaces/library';

@Component({
  selector: 'app-landing-page',
  imports: [
    TableModule,
    FormsModule,
    InputText,
    Tag,
  ],
  templateUrl: './landing-page.html'
})
export class LandingPage {
  library = input.required<Library>();
}
