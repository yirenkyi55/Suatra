import { createSelector } from '@ngrx/store';
import * as fromReducers from '../reducers';
import * as fromAuth from '../reducers/auth.reducers';

export const selectAuthState = createSelector(
  fromReducers.selectAuthenticationState,
  (state: fromReducers.AuthenticationState) => state.auth
);

export const selectCurrentUser = createSelector(
  selectAuthState,
  fromAuth.selectCurrentUserEntity
);

export const selectAuthLoading = createSelector(
  selectAuthState,
  fromAuth.selectAuthLoading
);

export const selectAuthLoaded = createSelector(
  selectAuthState,
  fromAuth.selectAuthLoaded
);

export const selectAuthUserEmail = createSelector(
  selectAuthState,
  fromAuth.selectAuthUserEmail
);
