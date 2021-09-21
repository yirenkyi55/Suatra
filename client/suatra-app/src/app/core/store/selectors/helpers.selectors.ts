import { createSelector } from '@ngrx/store';
import * as fromReducer from '../reducers';
import * as fromHelpers from '../reducers/helpers.reducers';

const selectHelpersState = createSelector(
  fromReducer.selectApplicationState,
  (state) => state.helpers
);

export const selectNotification = createSelector(
  selectHelpersState,
  fromHelpers.getNotification
);
