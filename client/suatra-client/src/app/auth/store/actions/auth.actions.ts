import { createAction, props } from '@ngrx/store';
import {
  LoginRequestModel,
  RegisterRequestModel,
  UserModel,
} from 'src/app/core/models';

// Create Account Actions
export const createAccountRequest = createAction(
  '[Auth] Create Account Request',
  props<{ requestModel: RegisterRequestModel }>()
);

export const createAccountRequestSuccess = createAction(
  '[Auth] Create Account Request Success'
);

export const createAccountRequestFailure = createAction(
  '[Auth] Create Account Request Failure',
  props<any>()
);

//Login Actions
export const loginRequest = createAction(
  '[Auth] Login Request',
  props<{ requestModel: LoginRequestModel }>()
);

export const loginRequestSuccess = createAction(
  '[Auth] Login Request Success',
  props<{ responseModel: UserModel }>()
);

export const loginRequestFailure = createAction(
  '[Auth] Login Request Failure',
  props<any>()
);
