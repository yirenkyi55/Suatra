import { Injectable } from '@angular/core';
import { SubSink } from 'subsink';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import * as fromAppStore from 'src/app/core/store';
import { Store } from '@ngrx/store';
@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  subs = new SubSink();

  constructor(
    private notification: NzNotificationService,
    private store: Store<fromAppStore.ApplicationState>
  ) {}

  createNotification(type: string, title: string, message: string): void {
    this.subs.sink = this.notification
      .create(type, title, message, {
        nzStyle: this.getNotificationStyle(type),
      })
      .onClose.subscribe(() => {
        //dispatch an action to close the notification
        this.store.dispatch(fromAppStore.CloseNotification());
      });
  }

  getNotificationStyle = (type: string) => {
    return {
      success: {
        color: 'rgba(0, 0, 0, 0.65)',
        border: '3px solid #f0672c',
        backgroundColor: '#f6ffed',
      },
      warning: {
        color: 'rgba(0, 0, 0, 0.65)',
        border: '3px solid #f93170',
        backgroundColor: '#fffbe6',
      },
      error: {
        color: 'rgba(0, 0, 0, 0.65)',
        border: '3px solid #f93170',
        backgroundColor: '#fff1f0',
      },
      info: {
        color: 'rgba(0, 0, 0, 0.65)',
        border: '3px solid #f93170',
        backgroundColor: '#e6f7ff',
      },
    }[type];
  };
}
