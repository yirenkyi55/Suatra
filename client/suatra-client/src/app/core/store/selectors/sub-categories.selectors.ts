import { createSelector } from '@ngrx/store';
import * as fromSubCategory from '../reducers/sub-categories.reducers';
import * as fromReducer from '../reducers';
import { SubCategoryFilter, SubCategoryResponse } from '../../models';

export const selectSubCategoryState = createSelector(
  fromReducer.selectAppState,
  (state) => state.subCategories
);

export const selectSubCategoryEntities = createSelector(
  selectSubCategoryState,
  fromSubCategory.selectSubCategoriesEntities
);

export const selectSubCategories = createSelector(
  selectSubCategoryState,
  fromSubCategory.selectAllSubCategories
);

export const selectSubCategoriesStatus = createSelector(
  selectSubCategoryState,
  fromSubCategory.selectSubCategoryStatus
);

export const selectSubCategoriesByCategoryId = (categoryId: string | null) =>
  createSelector(selectSubCategories, (subCategories) => {
    if (!categoryId) {
      return subCategories;
    }
    return subCategories.filter((x) => x.category.id === categoryId);
  });

export const selectSubCategoriesByFilterAndSearching = (
  filters: SubCategoryFilter
) =>
  createSelector(selectSubCategories, (subCategories) => {
    let itemsToReturn: SubCategoryResponse[] = [...subCategories];

    if (filters.category) {
      itemsToReturn = itemsToReturn.filter(
        (item) =>
          item.category.id.toLocaleLowerCase() ===
          filters.category?.toLocaleLowerCase()
      );
    }

    if (filters.query) {
      itemsToReturn = itemsToReturn.filter(
        (item) =>
          item.name
            .toLocaleLowerCase()
            .includes(filters.query!.toLocaleLowerCase()) ||
          item.category.name
            .toLocaleLowerCase()
            .includes(filters.query!.toLocaleLowerCase())
      );
    }
    return itemsToReturn;
  });
