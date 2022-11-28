import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Store } from '@ngrx/store';
import {
  BehaviorSubject,
  Observable,
  catchError,
  throwError,
  switchMap,
  filter,
  take,
} from 'rxjs';
import * as fromAuthStore from 'src/app/auth/store';
import { AuthService } from 'src/app/auth/services';
import { UserModel } from '../models';
import { Injectable } from '@angular/core';

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {
  private refreshTokenInProgress = false;
  //refreshTokenSubject tracks the current token, also set to null if no token is currently available(eg. pending refresh)
  private refreshTokenSubject = new BehaviorSubject<UserModel | null>(null);

  constructor(
    private store: Store<fromAuthStore.AuthState>,
    private authService: AuthService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const accessToken = this.authService.getToken();

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error && error.status === 401 && accessToken) {
          const protectedAuthRequests: string[] = [];

          const isProtectedAuthRequest =
            protectedAuthRequests.filter((url) => req.url.includes(url))
              .length > 0;

          if (req.url.includes('auth') && !isProtectedAuthRequest) {
            //We don't refresh token, since request allows anonymous
            if (req.url.includes('refresh')) {
              console.log('Logging Out');
              this.store.dispatch(fromAuthStore.logoutRequest());
            }

            return throwError(() => error);
          }

          if (!this.refreshTokenInProgress) {
            this.refreshTokenInProgress = true;
            this.refreshTokenSubject.next(null);
            console.log('Refreshing token');
            return this.authService.refreshToken({ token: accessToken }).pipe(
              switchMap((user) => {
                this.refreshTokenInProgress = false;
                this.refreshTokenSubject.next(user);
                this.store.dispatch(
                  fromAuthStore.loginRequestSuccess({ responseModel: user })
                );
                return next.handle(
                  this.addAuthenticationToken(req, accessToken)
                );
              })
            );
          } else {
            // Refresh token is in progress.
            //retry request again
            console.log('Wating for refresh token and retrying...');
            return this.refreshTokenSubject.pipe(
              filter((result) => result !== null),
              take(1),
              switchMap((userModel) =>
                next.handle(
                  this.addAuthenticationToken(req, userModel?.accessToken!)
                )
              )
            );
          }
        }

        return throwError(() => error);
      })
    );
  }

  addAuthenticationToken(request: HttpRequest<any>, accessToken: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`,
      },
    });
  }
}
