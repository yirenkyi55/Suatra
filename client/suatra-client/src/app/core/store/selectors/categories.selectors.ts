import { createSelector } from '@ngrx/store';
import * as fromCategory from '../reducers/categories.reducers';
import * as fromReducer from '../reducers';
import { CategoryResponse, SearchQuery } from '../../models';

export const selectCategoryState = createSelector(
  fromReducer.selectAppState,
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

export const selectCategoriesStatus = createSelector(
  selectCategoryState,
  fromCategory.selectCategoryStatus
);

export const selectCategoriesByName = (searchQuery: SearchQuery) =>
  createSelector(selectCategories, (categories) => {
    let itemsToReturn: CategoryResponse[] = [...categories];

    if (searchQuery && searchQuery.query) {
      itemsToReturn = itemsToReturn.filter((item) =>
        item.name
          .toLocaleLowerCase()
          .includes(searchQuery.query!.toLocaleLowerCase())
      );
    }

    return itemsToReturn;
  });
