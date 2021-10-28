import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import * as fromAuthStore from 'src/app/auth/store';

@Injectable({
  providedIn: 'root',
})
export class UserGuard implements CanActivate {
  constructor(
    private store: Store<fromAuthStore.AuthenticationState>,
    private router: Router
  ) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.authenticate(state);
  }

  authenticate(state: RouterStateSnapshot): Observable<boolean> {
    return this.store.select(fromAuthStore.selectCurrentUser).pipe(
      map((user) => {
        if (!user) {
          return true;
        }

        // TODO : check the user role and navigate him to the appropriate page
        if (state) {
          console.log(state.url);
          console.log(state.root);
          this.router.navigate(['/tutor']);
        } else {
          this.router.navigate(['/tutor']);
        }

        return false;
      })
    );
  }
}
