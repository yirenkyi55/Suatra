import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { tap } from 'rxjs/operators';

import * as fromRouterActions from 'src/app/store/actions/router.actions';

@Injectable()
export class RouterEffects {
  constructor(
    private actions$: Actions,
    private router: Router,
    private location: Location
  ) {}

  navigate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(fromRouterActions.Go),
        tap(({ path, query: queryParams, extras }) => {
          this.router.navigate(path, { queryParams, ...extras });
        })
      ),
    { dispatch: false }
  );

  navigateForward$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(fromRouterActions.Forward),
        tap(() => {
          this.location.forward();
        })
      ),
    {
      dispatch: false,
    }
  );

  navigateBack$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(fromRouterActions.Back),
        tap(() => {
          this.location.back();
        })
      ),
    {
      dispatch: false,
    }
  );
}
