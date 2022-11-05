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
import * as fromAuthStore from 'src/app/auth/store';
import { Store } from '@ngrx/store';
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
    private store: Store<fromAuthStore.AuthState>
  ) {
    this.router.events.subscribe((routerEvent) => {
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
    this.subs.sink = this.store
      .select(fromAuthStore.selectCurrentUser)
      .subscribe((user) => {
        this.currentUser = user;
      });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
