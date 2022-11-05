import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Store } from '@ngrx/store';
import { map, Observable } from 'rxjs';

import * as fromAuthStore from 'src/app/auth/store';
import * as fromAppStore from 'src/app/store';

@Injectable({
  providedIn: 'root',
})
export class GuestGuard implements CanActivate {
  constructor(
    private authStore: Store<fromAuthStore.AuthState>,
    private appStore: Store<fromAppStore.State>
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.authenticateGuest(state);
  }

  authenticateGuest(state: RouterStateSnapshot): Observable<boolean> {
    return this.authStore.select(fromAuthStore.selectCurrentUser).pipe(
      map((currentUser) => {
        if (!currentUser) {
          return true;
        }

        this.appStore.dispatch(
          fromAppStore.Go({
            path: ['tutor'],
          })
        );

        return false;
      })
    );
  }
}
