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
export class AuthGuard implements CanActivate {
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
        if (user) {
          return true;
        }

        if (state) {
          this.router.navigate(['/auth/sign-in'], {
            queryParams: { returnUrl: state?.url },
          });
        } else {
          this.router.navigate(['/auth/sign-in']);
        }

        return false;
      })
    );
  }
}
