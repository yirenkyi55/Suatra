import { createAction, props } from '@ngrx/store';
import { CreateCategoryModel, CategoryResponse } from '../../models';

//Create categories
export const createCategoriesRequest = createAction(
  '[Categories] Create Categories Request',
  props<{ requestModel: CreateCategoryModel }>()
);

export const createCategoriesRequestFailure = createAction(
  '[Categories] Create Categories Request Failure',
  props<any>()
);

export const createCategoriesRequestSuccess = createAction(
  '[Categories] Create Categories Request Success',
  props<{ responseModel: CategoryResponse }>()
);

// Get all categories
export const getAllCategoriesRequest = createAction(
  '[Categories] Get All Categories Request'
);
export const getAllCategoriesRequestSuccess = createAction(
  '[Categories] Get All Categories Request Success',
  props<{ responseModel: CategoryResponse[] }>()
);
export const getAllCategoriesRequestFailure = createAction(
  '[Categories] Get All Categories Request Failure',
  props<any>()
);
