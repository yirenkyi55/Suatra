import { createAction, props } from '@ngrx/store';
import {
  ActivateAccountModel,
  LoginRequestModel,
  RegisterRequestModel,
  UserModel,
} from 'src/app/core/models';

// Account Creation
export const CreateAccountRequest = createAction(
  '[Auth] Create Account Request',
  props<{ request: RegisterRequestModel }>()
);

export const CreateAccountRequestSuccess = createAction(
  '[Auth] Create Account Request Success',
  props<{ email: string }>()
);

export const CreateAccountRequestFailure = createAction(
  '[Auth] Create Account Request Failure',
  props<any>()
);

// Account Activation
export const ActivateAccountRequest = createAction(
  '[Auth] Activate Account Request',
  props<{ request: ActivateAccountModel }>()
);

export const ActivateAccountSuccess = createAction(
  '[Auth] Activate Account Success'
);

export const ActivateAccountFailure = createAction(
  '[Auth] Activate Account Failure',
  props<any>()
);

// Account Login
export const LoginRequest = createAction(
  '[Auth] Login Request',
  props<{ request: LoginRequestModel }>()
);

export const LoginRequestSuccess = createAction(
  '[Auth] Login Request Success',
  props<{ response: UserModel }>()
);

export const LoginRequestFailure = createAction(
  '[Auth] Login Request Failure',
  props<any>()
);

// Account Logout
export const Logout = createAction('[Authentication] Log out');
