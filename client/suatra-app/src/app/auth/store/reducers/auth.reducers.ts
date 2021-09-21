import { Action, createReducer, on } from '@ngrx/store';
import { UserModel } from 'src/app/core/models';
import * as fromAuthActions from '../actions';

export interface AuthenticationState {
  currentUser: UserModel;
  userEmail: string;
  loading: boolean;
  loaded: boolean;
}

export const initialState: AuthenticationState = {
  currentUser: null,
  userEmail: null,
  loaded: false,
  loading: false,
};

const featureReducer = createReducer(
  initialState,
  on(fromAuthActions.CreateAccountRequest, (state) => ({
    ...state,
    loading: true,
  })),

  on(fromAuthActions.CreateAccountRequestSuccess, (state, { email }) => ({
    ...state,
    loading: false,
    loaded: true,
    userEmail: email,
  })),

  on(fromAuthActions.CreateAccountRequestFailure, (state) => ({
    ...state,
    loading: false,
    loaded: false,
    userEmail: null,
  }))
);

export function reducer(
  state: AuthenticationState | undefined,
  action: Action
): AuthenticationState {
  return featureReducer(state, action);
}

export const selectCurrentUserEntity = (state: AuthenticationState) =>
  state.currentUser;
export const selectAuthLoading = (state: AuthenticationState) => state.loading;
export const selectAuthLoaded = (state: AuthenticationState) => state.loaded;
export const selectAuthUserEmail = (state: AuthenticationState) =>
  state.userEmail;
