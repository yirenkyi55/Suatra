import { createSelector } from '@ngrx/store';
import * as fromReducer from '../reducers';
import * as fromUtils from '../reducers/utils.reducers';

const selectHelpersState = createSelector(
  fromReducer.selectAppState,
  (state) => state.utils
);

export const selectNotification = createSelector(
  selectHelpersState,
  fromUtils.selectNotification
);
