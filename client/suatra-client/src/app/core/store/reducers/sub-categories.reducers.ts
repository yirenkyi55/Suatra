import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import { SubCategoryResponse, LoadingStatus } from '../../models';
import * as fromActions from '../actions/sub-categories.actions';

export interface SubCategoryState extends EntityState<SubCategoryResponse> {
  status: LoadingStatus;
}

const adapter: EntityAdapter<SubCategoryResponse> =
  createEntityAdapter<SubCategoryResponse>();

const initialState: SubCategoryState = adapter.getInitialState({
  status: LoadingStatus.Idle,
});

const categoryReducer = createReducer(
  initialState,

  on(
    fromActions.createSubCategoryRequest,
    fromActions.getAllSubCategoryRequest,
    (state) => ({
      ...state,
      status: LoadingStatus.Loading,
    })
  ),

  on(
    fromActions.getAllSubCategoryRequestSuccess,
    (state, { responseModel }) => {
      return adapter.addMany(responseModel, {
        ...state,
        status: LoadingStatus.Success,
      });
    }
  ),

  on(
    fromActions.createSubCategoryRequestSuccess,
    (state, { responseModel }) => {
      return adapter.addOne(responseModel, {
        ...state,
        status: LoadingStatus.Success,
      });
    }
  ),

  on(
    fromActions.createSubCategoryRequestFailure,
    fromActions.getAllSubCategoryRequestFailure,
    (state) => ({
      ...state,
      status: LoadingStatus.Error,
    })
  )
);

export function reducer(state: SubCategoryState | undefined, action: Action) {
  return categoryReducer(state, action);
}

const { selectIds, selectEntities, selectAll } = adapter.getSelectors();

export const selectSubCategoryIds = selectIds;
export const selectSubCategoriesEntities = selectEntities;
export const selectAllSubCategories = selectAll;
export const selectSubCategoryStatus = (state: SubCategoryState) =>
  state.status;
