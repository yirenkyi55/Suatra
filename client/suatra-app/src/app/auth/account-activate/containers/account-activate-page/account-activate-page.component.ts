import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubSink } from 'subsink';
import * as fromAuthStore from 'src/app/auth/store';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-account-activate-page',
  templateUrl: './account-activate-page.component.html',
  styleUrls: ['./account-activate-page.component.scss'],
})
export class AccountActivatePageComponent implements OnInit, OnDestroy {
  token: string;
  email: string;
  subSink = new SubSink();
  loading$: Observable<boolean>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private store: Store<fromAuthStore.AuthenticationState>
  ) {}

  ngOnInit(): void {
    this.subSink.sink = this.route.queryParams.subscribe((query) => {
      if (!(query.token && query.email)) {
        this.router.navigate(['/auth/sign-up']);
      }

      this.token = query.token;
      this.email = query.email;
    });

    this.loading$ = this.store.select(fromAuthStore.selectAuthLoading);
  }

  activateAccount() {
    const request = {
      token: this.token,
      email: this.email,
    };
    this.store.dispatch(fromAuthStore.ActivateAccountRequest({ request }));
  }

  ngOnDestroy() {
    this.subSink.unsubscribe();
  }
}
