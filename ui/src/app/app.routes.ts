import {Routes} from '@angular/router';
import {LandingPage} from './pages/landing-page/landing-page';
import {libraryResolver} from './resolvers/library-resolver';

export const routes: Routes = [
  {
    path: '',
    component: LandingPage,
    resolve: {
      library: libraryResolver
    }
  }
];
