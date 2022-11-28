import { Action, createReducer, on } from '@ngrx/store';
import { NotificationMessage } from '../../models';
import * as fromUtilActions from '../actions/utils.actions';

export interface UtilState {
  notification: NotificationMessage | null;
}

export const initialState: UtilState = {
  notification: null,
};

const featureReducer = createReducer(
  initialState,

  on(fromUtilActions.DisplayNotification, (state, notification) => ({
    ...state,
    notification,
  })),

  on(fromUtilActions.CloseNotification, (state) => ({
    ...state,
    notification: null,
  }))
);

export function reducer(state: UtilState | undefined, action: Action) {
  return featureReducer(state, action);
}

export const selectNotification = (state: UtilState) => state.notification;
