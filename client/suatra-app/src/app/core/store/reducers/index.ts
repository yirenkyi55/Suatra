import { createFeatureSelector, ActionReducerMap } from '@ngrx/store';
import * as fromHelpers from '../reducers/helpers.reducers';

export interface ApplicationState {
  helpers: fromHelpers.HelpersState;
}

export const reducers: ActionReducerMap<ApplicationState> = {
  helpers: fromHelpers.reducer,
};

export const selectApplicationState =
  createFeatureSelector<ApplicationState>('applicationState');
