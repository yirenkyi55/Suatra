import { createAction, props } from '@ngrx/store';
import { RegisterRequestModel } from 'src/app/core/models';

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
