import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { RegisterRequestModel } from 'src/app/core/models';
import * as fromAuthStore from 'src/app/auth/store';
@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss'],
})
export class SignUpPageComponent implements OnInit {
  constructor(private store: Store<fromAuthStore.AuthState>) {}

  ngOnInit(): void {}

  onSignUp(requestModel: RegisterRequestModel): void {
    this.store.dispatch(fromAuthStore.createAccountRequest({ requestModel }));
  }
}
