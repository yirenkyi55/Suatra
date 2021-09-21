import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromAuthStore from 'src/app/auth/store';
@Component({
  selector: 'app-success-page',
  templateUrl: './success-page.component.html',
  styleUrls: ['./success-page.component.scss'],
})
export class SuccessPageComponent implements OnInit {
  email$: Observable<string>;

  constructor(private store: Store<fromAuthStore.AuthenticationState>) {}

  ngOnInit(): void {
    this.email$ = this.store.select(fromAuthStore.selectAuthUserEmail);
  }
}
