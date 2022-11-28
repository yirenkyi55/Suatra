import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoadingStatus, LoginRequestModel } from 'src/app/core/models';
import * as fromAuthStore from 'src/app/auth/store';
@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.scss'],
})
export class SignInPageComponent implements OnInit {
  loadingStatus$: Observable<LoadingStatus>;
  constructor(private store: Store<fromAuthStore.AuthState>) {}

  ngOnInit(): void {
    this.loadingStatus$ = this.store.select(fromAuthStore.selectAuthStatus);
  }

  onLogin(requestModel: LoginRequestModel): void {
    this.store.dispatch(fromAuthStore.loginRequest({ requestModel }));
  }
}
