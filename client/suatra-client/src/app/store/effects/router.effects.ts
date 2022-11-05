import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { tap } from 'rxjs/operators';
import * as fromRouterActions from 'src/app/store/actions';

@Injectable()
export class RouterEffects {
  constructor(
    private action$: Actions,
    private router: Router,
    private location: Location
  ) {}

  navigate$ = createEffect(
    () =>
      this.action$.pipe(
        ofType(fromRouterActions.Go),
        tap(({ path, query: queryParams, extras }) => {
          this.router.navigate(path, { queryParams, ...extras });
        })
      ),
    { dispatch: false }
  );

  navigateForward$ = createEffect(
    () =>
      this.action$.pipe(
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
      this.action$.pipe(
        ofType(fromRouterActions.Back),
        tap(() => {
          this.location.back();
        })
      ),
    { dispatch: false }
  );
}
