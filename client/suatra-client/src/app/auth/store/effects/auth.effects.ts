import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap } from 'rxjs';
import { AuthService } from '../../services';
import * as fromAuthActions from '../actions';
import * as fromRoot from 'src/app/store';

@Injectable()
export class AuthEffects {
  constructor(private actions$: Actions, private authService: AuthService) {}

  createAccount$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.createAccountRequest),
      switchMap(({ requestModel }) =>
        this.authService.createAccount(requestModel).pipe(
          switchMap(() => [
            fromRoot.Go({
              path: ['/auth/sign-up/success'],
              extras: { queryParams: { email: requestModel.email } },
            }),
            fromAuthActions.createAccountRequestSuccess(),
          ]),
          catchError((error) =>
            of(fromAuthActions.createAccountRequestFailure(error))
          )
        )
      )
    )
  );

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.loginRequest),
      switchMap(({ requestModel }) =>
        this.authService.login(requestModel).pipe(
          switchMap((responseModel) => [
            fromAuthActions.loginRequestSuccess({ responseModel }),
            fromRoot.Go({
              path: ['/tutor'],
            }),
          ]),
          catchError((error) => of(fromAuthActions.loginRequestFailure(error)))
        )
      )
    )
  );
}
