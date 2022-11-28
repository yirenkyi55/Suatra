import { Action, createReducer, on } from '@ngrx/store';
import { LoadingStatus, UserModel } from 'src/app/core/models';
import * as fromAuthActions from '../actions';

export interface AuthState {
  currentUser: UserModel | null;
  status: LoadingStatus;
}

export const initialState: AuthState = {
  currentUser: null,
  status: LoadingStatus.Idle,
};

const featureReducer = createReducer(
  initialState,

  on(
    fromAuthActions.createAccountRequest,
    fromAuthActions.loginRequest,
    (state) => ({
      ...state,
      status: LoadingStatus.Loading,
    })
  ),

  on(fromAuthActions.loginRequestSuccess, (state, { responseModel }) => ({
    ...state,
    currentUser: responseModel,
    status: LoadingStatus.Success,
  })),

  on(fromAuthActions.createAccountRequestSuccess, (state) => ({
    ...state,
    status: LoadingStatus.Success,
  })),

  on(
    fromAuthActions.createAccountRequestFailure,
    fromAuthActions.loginRequestFailure,
    (state) => ({
      ...state,
      status: LoadingStatus.Error,
    })
  ),

  on(fromAuthActions.logoutRequest, (state) => ({
    ...state,
    // status: LoadingStatus.Idle,
    currentUser: null,
  }))
);

export function reducer(
  state: AuthState | undefined,
  action: Action
): AuthState {
  return featureReducer(state, action);
}

export const selectCurrentUserEntity = (state: AuthState) => state.currentUser;
export const selectStatus = (state: AuthState) => state.status;
