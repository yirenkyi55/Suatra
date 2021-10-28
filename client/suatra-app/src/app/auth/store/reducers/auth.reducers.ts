import { Action, createReducer, on } from '@ngrx/store';
import { DashboardTypes } from 'src/app/core/enums';
import { UserModel } from 'src/app/core/models';
import * as fromAuthActions from '../actions';

export interface AuthenticationState {
  currentUser: UserModel;
  userEmail: string;
  loading: boolean;
  loaded: boolean;
  dashboard: DashboardTypes;
}

export const initialState: AuthenticationState = {
  currentUser: null,
  userEmail: null,
  loaded: false,
  loading: false,
  dashboard: DashboardTypes.User,
};

const featureReducer = createReducer(
  initialState,
  on(
    fromAuthActions.CreateAccountRequest,
    fromAuthActions.ActivateAccountRequest,
    fromAuthActions.LoginRequest,
    (state) => ({
      ...state,
      loading: true,
    })
  ),

  on(fromAuthActions.CreateAccountRequestSuccess, (state, { email }) => ({
    ...state,
    loading: false,
    loaded: true,
    userEmail: email,
  })),

  on(fromAuthActions.ActivateAccountSuccess, (state) => ({
    ...state,
    loading: false,
    loaded: true,
  })),

  on(fromAuthActions.LoginRequestSuccess, (state, { response }) => {
    return {
      ...state,
      currentUser: response,
      loading: false,
      loaded: true,
      dashboard: DashboardTypes.Admin, // Dashboard type to be recalculated when roles are introduced
    };
  }),

  on(fromAuthActions.Logout, (state) => ({
    ...state,
    currentUser: null,
  })),

  on(
    fromAuthActions.CreateAccountRequestFailure,
    fromAuthActions.ActivateAccountFailure,
    fromAuthActions.LoginRequestFailure,
    (state) => ({
      ...state,
      loading: false,
      loaded: false,
      userEmail: null,
    })
  )
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
