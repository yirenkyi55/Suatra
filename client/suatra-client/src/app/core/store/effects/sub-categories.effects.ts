import { catchError, map, of, switchMap } from 'rxjs';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { SubCategoriesService } from '../../services';
import * as fromSubCategoryActions from '../actions/sub-categories.actions';

@Injectable()
export class SubCategoryEffects {
  constructor(
    private actions$: Actions,
    private subCategoryService: SubCategoriesService
  ) {}

  getSubCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromSubCategoryActions.getAllSubCategoryRequest),
      switchMap(() =>
        this.subCategoryService.getSubCategories().pipe(
          map((responseModel) =>
            fromSubCategoryActions.getAllSubCategoryRequestSuccess({
              responseModel,
            })
          ),
          catchError((error) =>
            of(fromSubCategoryActions.getAllSubCategoryRequestFailure(error))
          )
        )
      )
    )
  );

  createSubCategory$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromSubCategoryActions.createSubCategoryRequest),
      switchMap(({ payload }) =>
        this.subCategoryService.createSubCategory(payload).pipe(
          map((responseModel) =>
            fromSubCategoryActions.createSubCategoryRequestSuccess({
              responseModel,
            })
          ),
          catchError((error) =>
            of(fromSubCategoryActions.createSubCategoryRequestFailure(error))
          )
        )
      )
    )
  );
}
