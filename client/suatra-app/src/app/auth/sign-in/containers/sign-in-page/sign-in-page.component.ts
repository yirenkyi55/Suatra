import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginRequestModel } from 'src/app/core/models';
import * as fromAuthStore from 'src/app/auth/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.scss'],
})
export class SignInPageComponent implements OnInit {
  loading$: Observable<boolean>;

  constructor(private store: Store<fromAuthStore.AuthenticationState>) {}

  ngOnInit(): void {
    this.loading$ = this.store.select(fromAuthStore.selectAuthLoading);
  }

  onLogin(request: LoginRequestModel): void {
    this.store.dispatch(fromAuthStore.LoginRequest({ request }));
  }
}
