import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import * as fromRoot from 'src/app/store';
import { AuthService } from 'src/app/auth/services';
import * as fromAuthActions from '../actions';

@Injectable()
export class AuthEffects {
  constructor(private actions$: Actions, private authService: AuthService) {}

  createAccount$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.CreateAccountRequest),
      switchMap(({ request }) =>
        this.authService.createAccount(request).pipe(
          switchMap(() => [
            fromRoot.Go({ path: ['/auth/sign-up/success'] }),
            fromAuthActions.CreateAccountRequestSuccess({
              email: request.email,
            }),
          ]),
          catchError((error) =>
            of(fromAuthActions.CreateAccountRequestFailure(error))
          )
        )
      )
    )
  );
}
