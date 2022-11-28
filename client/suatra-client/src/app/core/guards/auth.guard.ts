import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Store } from '@ngrx/store';
import { map, Observable, take } from 'rxjs';

import * as fromAuthStore from 'src/app/auth/store';
import * as fromAppStore from 'src/app/store';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authStore: Store<fromAuthStore.AuthState>,
    private appStore: Store<fromAppStore.State>
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    console.log('Auth Guard');
    return this.authenticate(state);
  }

  authenticate(state: RouterStateSnapshot): Observable<boolean> {
    return this.authStore.select(fromAuthStore.selectCurrentUser).pipe(
      take(1), // to prevent ongoing subscription, we take the latest value
      map((currentUser) => {
        if (currentUser) {
          return true;
        }

        if (state) {
          this.appStore.dispatch(
            fromAppStore.Go({
              path: ['/auth/sign-in'],
              extras: { queryParams: { returnUrl: state.url } },
            })
          );
        } else {
          this.appStore.dispatch(fromAppStore.Go({ path: ['/auth/sign-in'] }));
        }
        return false;
      })
    );
  }
}
