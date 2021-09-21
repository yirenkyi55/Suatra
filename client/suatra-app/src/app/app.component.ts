import { DashboardMenu } from 'src/app/core/models';
import { Component, OnDestroy } from '@angular/core';
import * as data from 'src/files/adminDashboard.json';
import { Store } from '@ngrx/store';
import { SubSink } from 'subsink';
import { NotificationService } from './core/services';

import * as fromAuthStore from 'src/app/auth/store';
import * as fromAppStore from './core/store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnDestroy {
  dashboardMenuItems: DashboardMenu[] = data.default;
  subs = new SubSink();

  constructor(
    private store: Store<fromAuthStore.AuthenticationState>,
    private notificationService: NotificationService,
    private appStore: Store<fromAppStore.ApplicationState>
  ) {}

  ngOnInit() {
    this.subs.sink = this.appStore
      .select(fromAppStore.selectNotification)
      .subscribe((response) => {
        response &&
          this.notificationService.createNotification(
            response.notificationType,
            response.title,
            response.message
          );
      });
  }

  onLogOut(): void {}

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
