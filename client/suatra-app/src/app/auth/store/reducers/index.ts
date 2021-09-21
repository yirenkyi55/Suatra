import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import * as fromAuthReducer from './auth.reducers';

export interface AuthenticationState {
  auth: fromAuthReducer.AuthenticationState;
}

export const reducers: ActionReducerMap<AuthenticationState> = {
  auth: fromAuthReducer.reducer,
};

export const selectAuthenticationState = createFeatureSelector('authState');
