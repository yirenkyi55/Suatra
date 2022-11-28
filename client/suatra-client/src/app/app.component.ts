import { Component, OnDestroy, OnInit } from '@angular/core';
import * as data from 'src/assets/files/adminDashboard.json';
import { DashboardMenu, UserModel } from 'src/app/core/models';
import {
  Router,
  NavigationStart,
  NavigationEnd,
  NavigationError,
  NavigationCancel,
} from '@angular/router';
import { SubSink } from 'subsink';
import { Store } from '@ngrx/store';
import { NotificationService } from './core/services';

import * as fromAuthStore from 'src/app/auth/store';
import * as fromAppStore from 'src/app/core/store';
import * as fromStore from 'src/app/store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  dashboardMenuItems: DashboardMenu[] = data.default;
  showLoadingIndicator = true;
  currentUser: UserModel | null;
  subs = new SubSink();

  constructor(
    private router: Router,
    private authStore: Store<fromAuthStore.AuthState>,
    private appStore: Store<fromAppStore.AppState>,
    private store: Store<fromStore.State>,
    private notificationService: NotificationService
  ) {
    this.subs.sink = this.router.events.subscribe((routerEvent) => {
      if (routerEvent instanceof NavigationStart) {
        this.showLoadingIndicator = true;
      }

      if (
        routerEvent instanceof NavigationEnd ||
        routerEvent instanceof NavigationError ||
        routerEvent instanceof NavigationCancel
      ) {
        this.showLoadingIndicator = false;
      }
    });
  }

  ngOnInit(): void {
    this.subs.sink = this.authStore
      .select(fromAuthStore.selectCurrentUser)
      .subscribe((user) => {
        this.currentUser = user;
        // if (!user) {
        //   console.log(user);
        //   this.store.dispatch(fromStore.Go({ path: ['/auth/sign-in'] }));
        // }
      });

    //Create notification
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

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  onLogOut(): void {
    this.authStore.dispatch(fromAuthStore.logoutRequest());
  }
}
