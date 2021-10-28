import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { CategoriesService } from 'src/app/core/services';
import * as fromCatActions from '../actions/categoies.actions';

@Injectable()
export class CategoryEffect {
  constructor(
    private actions$: Actions,
    private catService: CategoriesService
  ) {}

  getAllCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromCatActions.GetCategoriesRequest),
      switchMap(() =>
        this.catService.getCategories().pipe(
          map((response) =>
            fromCatActions.GetCategoriesRequestSuccess({ response })
          ),
          catchError((error) =>
            of(fromCatActions.GetCategoriesRequestFailure(error))
          )
        )
      )
    )
  );
}
