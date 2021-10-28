import { createSelector } from '@ngrx/store';
import * as fromCategory from '../reducers/categories.reducers';
import * as fromReducer from '../reducers';

export const selectCategoryState = createSelector(
  fromReducer.selectApplicationState,
  (state) => state.categories
);

export const selectCategoryEntities = createSelector(
  selectCategoryState,
  fromCategory.selectCategoryEntities
);

export const selectCategories = createSelector(
  selectCategoryState,
  fromCategory.selectAllCategories
);

export const selectCategoriesLoading = createSelector(
  selectCategoryState,
  fromCategory.selectCategoryLoading
);

export const selectCategoriesLoaded = createSelector(
  selectCategoryState,
  fromCategory.SelectCategoryLoaded
);
