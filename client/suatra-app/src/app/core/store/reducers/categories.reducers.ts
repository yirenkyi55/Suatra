import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import { CategoryResponse } from 'src/app/core/models';
import * as fromCatActions from '../actions/categoies.actions';

export interface CategoryState extends EntityState<CategoryResponse> {
  loading: boolean;
  loaded: boolean;
}

export const adapter: EntityAdapter<CategoryResponse> =
  createEntityAdapter<CategoryResponse>();

export const initialState: CategoryState = adapter.getInitialState({
  loading: false,
  loaded: false,
});

const categoryReducer = createReducer(
  initialState,
  on(fromCatActions.GetCategoriesRequest, (state) => ({
    ...state,
    loading: true,
  })),

  on(fromCatActions.GetCategoriesRequestSuccess, (state, { response }) => {
    return adapter.addMany(response, {
      ...state,
      loading: false,
      loaded: true,
    });
  }),

  on(fromCatActions.GetCategoriesRequestFailure, (state) => ({
    ...state,
    loading: false,
    loaded: false,
  }))
);

export function reducer(state: CategoryState | undefined, action: Action) {
  return categoryReducer(state, action);
}

const { selectIds, selectEntities, selectAll } = adapter.getSelectors();

export const selectCategoryIds = selectIds;
export const selectCategoryEntities = selectEntities;
export const selectAllCategories = selectAll;
export const selectCategoryLoading = (state: CategoryState) => state.loading;
export const SelectCategoryLoaded = (state: CategoryState) => state.loaded;
