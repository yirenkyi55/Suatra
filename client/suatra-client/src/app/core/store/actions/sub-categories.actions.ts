import { createAction, props } from '@ngrx/store';
import { CreateSubCategoryModel, SubCategoryResponse } from '../../models';

//Create sub-categories
export const createSubCategoryRequest = createAction(
  '[SubCategory] Create SubCategory Request',
  props<{ payload: CreateSubCategoryModel }>()
);

export const createSubCategoryRequestFailure = createAction(
  '[SubCategory] Create SubCategory Request Failure',
  props<any>()
);

export const createSubCategoryRequestSuccess = createAction(
  '[SubCategory] Create SubCategory Request Success',
  props<{ responseModel: SubCategoryResponse }>()
);

// Get all SubCategory
export const getAllSubCategoryRequest = createAction(
  '[SubCategory] Get All SubCategory Request'
);
export const getAllSubCategoryRequestSuccess = createAction(
  '[SubCategory] Get All SubCategory Request Success',
  props<{ responseModel: SubCategoryResponse[] }>()
);
export const getAllSubCategoryRequestFailure = createAction(
  '[SubCategory] Get All SubCategory Request Failure',
  props<any>()
);
