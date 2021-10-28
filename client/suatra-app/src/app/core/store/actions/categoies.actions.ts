import { createAction, props } from '@ngrx/store';
import { CategoryResponse } from '../../models';

export const GetCategoriesRequest = createAction(
  '[Categories] Get All Categories Request'
);

export const GetCategoriesRequestSuccess = createAction(
  '[Categories] Get All Categories Request Success',
  props<{ response: CategoryResponse[] }>()
);

export const GetCategoriesRequestFailure = createAction(
  '[Categories] Get All Categories Request Failure',
  props<any>()
);
