import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import { AuthService } from '../../services';
import * as fromAuthActions from '../actions';
import * as fromRoot from 'src/app/store';
import { Store } from '@ngrx/store';

@Injectable()
export class AuthEffects {
  returnUrl: string;

  constructor(
    private actions$: Actions,
    private authService: AuthService,
    private store: Store<fromRoot.State>
  ) {
    this.store.select(fromRoot.getQueryParams).subscribe((params) => {
      if (params?.returnUrl) {
        this.returnUrl = params.returnUrl;
      }
    });
  }

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
            this.returnUrl
              ? fromRoot.Go({ path: [this.returnUrl] })
              : fromRoot.Go({
                  path: ['/tutor'],
                }),
          ]),
          catchError((error) => of(fromAuthActions.loginRequestFailure(error)))
        )
      )
    )
  );

  // logOut$ = createEffect(() =>
  //   this.actions$.pipe(
  //     ofType(fromAuthActions.logoutRequest),
  //     tap(() => this.authService.logOut()),
  //     map(() => fromRoot.Go({ path: ['/'] }))
  //   )
  // );

  logOut$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromAuthActions.logoutRequest),
      switchMap(() =>
        this.authService.logOut().pipe(
          switchMap((response) => [
            fromAuthActions.logoutRequestSuccess(response),
            fromRoot.Go({ path: ['/auth/sign-in'] }),
          ]),
          catchError((error) => {
            console.log('An error occured');
            console.log(error);
            return of(fromAuthActions.logOutRequestFailure(error));
          })
        )
      )
    )
  );

  // logOutSuccess$ = createEffect(
  //   () =>
  //     this.actions$.pipe(
  //       ofType(fromAuthActions.logoutRequestSuccess),
  //       map(() => {
  //         console.log('Login success');
  //         fromRoot.Go({ path: ['/auth/sign-in'] });
  //       })
  //     ),
  //   { dispatch: false }
  // );
}
