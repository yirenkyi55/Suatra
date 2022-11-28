import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';
import * as fromAppStore from 'src/app/core/store';
import { LoadingStatus } from '../models';

@Injectable({
  providedIn: 'root',
})
export class SubCategoriesGuard implements CanActivate {
  constructor(private store: Store<fromAppStore.AppState>) {}

  canActivate(): Observable<boolean> {
    return this.checkStore().pipe(
      switchMap(() => of(true)),
      catchError(() => of(false))
    );
  }
  checkStore() {
    this.store.dispatch(fromAppStore.getAllSubCategoryRequest());

    return this.store.select(fromAppStore.selectSubCategoriesStatus).pipe(
      tap((status) => {
        if (status === LoadingStatus.Loading) {
          //Show loading indicator.
        } else {
          //Stop loading indicator
        }
      }),
      filter((status) => !!status),
      take(1)
    );
  }
}
