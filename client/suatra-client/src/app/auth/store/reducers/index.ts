import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import * as fromAuthReducer from './auth.reducers';

export interface AuthState {
  auth: fromAuthReducer.AuthState;
}

export const reducers: ActionReducerMap<AuthState> = {
  auth: fromAuthReducer.reducer,
};

export const selectAuthenticationState =
  createFeatureSelector<AuthState>('authState');
