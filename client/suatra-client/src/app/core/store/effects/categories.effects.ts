import { catchError, map, of, switchMap } from 'rxjs';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType, OnInitEffects } from '@ngrx/effects';
import { CategoriesService } from '../../services';
import * as fromCategoryActions from '../actions/categories.actions';

@Injectable()
export class CategoryEffects {
  constructor(
    private actions$: Actions,
    private categoryService: CategoriesService
  ) {}

  // ngrxOnInitEffects(): Action {
  //   return fromCategoryActions.getAllCategoriesRequest();
  // }

  getCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromCategoryActions.getAllCategoriesRequest),
      switchMap(() =>
        this.categoryService.getCategories().pipe(
          map((responseModel) =>
            fromCategoryActions.getAllCategoriesRequestSuccess({
              responseModel,
            })
          ),
          catchError((error) =>
            of(fromCategoryActions.getAllCategoriesRequestFailure(error))
          )
        )
      )
    )
  );

  createCategory$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromCategoryActions.createCategoriesRequest),
      switchMap(({ requestModel }) =>
        this.categoryService.createCategory(requestModel).pipe(
          map((responseModel) =>
            fromCategoryActions.createCategoriesRequestSuccess({
              responseModel,
            })
          ),
          catchError((error) =>
            of(fromCategoryActions.createCategoriesRequestFailure(error))
          )
        )
      )
    )
  );
}
