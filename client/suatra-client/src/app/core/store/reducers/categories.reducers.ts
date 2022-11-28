import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import { CategoryResponse, LoadingStatus } from '../../models';
import * as fromActions from '../actions/categories.actions';

export interface CategoryState extends EntityState<CategoryResponse> {
  status: LoadingStatus;
}

const adapter: EntityAdapter<CategoryResponse> =
  createEntityAdapter<CategoryResponse>();

const initialState: CategoryState = adapter.getInitialState({
  status: LoadingStatus.Idle,
});

const categoryReducer = createReducer(
  initialState,

  on(
    fromActions.createCategoriesRequest,
    fromActions.getAllCategoriesRequest,
    (state) => ({
      ...state,
      status: LoadingStatus.Loading,
    })
  ),

  on(fromActions.getAllCategoriesRequestSuccess, (state, { responseModel }) => {
    return adapter.addMany(responseModel, {
      ...state,
      status: LoadingStatus.Success,
    });
  }),

  on(fromActions.createCategoriesRequestSuccess, (state, { responseModel }) => {
    return adapter.addOne(responseModel, {
      ...state,
      status: LoadingStatus.Success,
    });
  }),

  on(
    fromActions.createCategoriesRequestFailure,
    fromActions.getAllCategoriesRequestFailure,
    (state) => ({
      ...state,
      status: LoadingStatus.Error,
    })
  )
);

export function reducer(state: CategoryState | undefined, action: Action) {
  return categoryReducer(state, action);
}

const { selectIds, selectEntities, selectAll } = adapter.getSelectors();

export const selectCategoryIds = selectIds;
export const selectCategoryEntities = selectEntities;
export const selectAllCategories = selectAll;
export const selectCategoryStatus = (state: CategoryState) => state.status;
