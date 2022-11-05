import { createSelector } from '@ngrx/store';
import * as fromReducers from '../reducers';
import * as fromAuth from '../reducers/auth.reducers';

export const selectAuthState = createSelector(
  fromReducers.selectAuthenticationState,
  (state) => state.auth
);

export const selectCurrentUser = createSelector(
  selectAuthState,
  fromAuth.selectCurrentUserEntity
);

export const selectAuthStatus = createSelector(
  selectAuthState,
  fromAuth.selectStatus
);
