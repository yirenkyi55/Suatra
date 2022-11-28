import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import * as fromAppStore from 'src/app/core/store';
import { NotificationType } from '../models';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private appStore: Store<fromAppStore.AppState>) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log(error);
        const errorResult = error.error?.errors;

        if (error.status === 500) {
          this.displayError(
            'Internal Server Error',
            'An error occured on the server while making request'
          );
        } else if (error.status === 400) {
          this.displayError('Request Failed', errorResult?.message);
        } else if (error.status === 401) {
          this.displayError('Unauthorized', errorResult?.message);
        } else if (error.status === 422) {
          // Loop through error and display appropriate
          errorResult?.map((message: string) => {
            this.displayError('Validation Error', message);
          });
        }

        return throwError(() => error);
      })
    );
  }

  displayError(title: string, message: string) {
    this.appStore.dispatch(
      fromAppStore.DisplayNotification({
        notificationType: NotificationType.Error,
        title,
        message,
      })
    );
  }
}
