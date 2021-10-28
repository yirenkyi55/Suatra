import { createFeatureSelector, ActionReducerMap } from '@ngrx/store';
import * as fromHelpers from '../reducers/helpers.reducers';
import * as fromCategories from '../reducers/categories.reducers';

export interface ApplicationState {
  helpers: fromHelpers.HelpersState;
  categories: fromCategories.CategoryState;
}

export const reducers: ActionReducerMap<ApplicationState> = {
  helpers: fromHelpers.reducer,
  categories: fromCategories.reducer,
};

export const selectApplicationState =
  createFeatureSelector<ApplicationState>('applicationState');
