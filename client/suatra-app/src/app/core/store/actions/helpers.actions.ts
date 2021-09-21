import { createAction, props } from '@ngrx/store';
import { NotificationMessage } from 'src/app/core/models';

export const DisplayNotification = createAction(
  '[Notification] Display Notification',
  props<NotificationMessage>()
);

export const CloseNotification = createAction(
  '[Notification] Close Notification'
);
