import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';

import * as fromRoot from 'src/app/store';
import * as fromApp from 'src/app/core/store';
import { AuthService } from 'src/app/auth/services';
import * as fromAuthActions from '../actions';
import { NotificationType } from 'src/app/core/models';

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

  activateAccount$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.ActivateAccountRequest),
      switchMap(({ request }) =>
        this.authService.activate(request).pipe(
          switchMap(() => [
            fromRoot.Go({ path: ['/auth/sign-in'] }),
            fromApp.DisplayNotification({
              title: 'Account Activation',
              message: 'You successfully activated your account',
              notificationType: NotificationType.success,
            }),
            fromAuthActions.ActivateAccountSuccess(),
          ]),
          catchError((error) =>
            of(fromAuthActions.ActivateAccountFailure(error))
          )
        )
      )
    )
  );

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.LoginRequest),
      switchMap(({ request }) =>
        this.authService.login(request).pipe(
          map((response) => fromAuthActions.LoginRequestSuccess({ response })),
          catchError((error) => of(fromAuthActions.LoginRequestFailure(error)))
        )
      )
    )
  );

  loginSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.LoginRequestSuccess),
      switchMap(({ response }) => [fromRoot.Go({ path: ['/tutor'] })])
    )
  );

  logOut$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.Logout),
      tap(() => this.authService.logOut()),
      map(() => fromRoot.Go({ path: ['/'] }))
    )
  );
}
