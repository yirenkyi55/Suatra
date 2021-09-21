import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { RegisterRequestModel } from 'src/app/core/models';

import * as fromAuthStore from 'src/app/auth/store';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss'],
})
export class SignUpPageComponent implements OnInit {
  loading$: Observable<boolean>;
  constructor(private store: Store<fromAuthStore.AuthenticationState>) {}

  ngOnInit(): void {
    this.loading$ = this.store.select(fromAuthStore.selectAuthLoading);
  }

  onSignUp(request: RegisterRequestModel): void {
    this.store.dispatch(fromAuthStore.CreateAccountRequest({ request }));
  }
}
