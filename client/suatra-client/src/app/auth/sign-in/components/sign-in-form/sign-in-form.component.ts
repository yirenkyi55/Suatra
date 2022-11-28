import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { faRegistered, faSignInAlt } from '@fortawesome/free-solid-svg-icons';
import { LoadingStatus, LoginRequestModel } from 'src/app/core/models';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss'],
})
export class SignInFormComponent implements OnInit {
  faRegister = faRegistered;
  faSignIn = faSignInAlt;

  @Input() loadingStatus: LoadingStatus | null;
  @Output() handleLogin = new EventEmitter<LoginRequestModel>();

  signInForm = this.fb.group({
    email: [
      '',
      [
        Validators.required,
        Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
      ],
    ],
    password: ['', [Validators.required]],
  });

  constructor(private fb: FormBuilder) {}

  get isFormLoading(): boolean {
    return this.loadingStatus === LoadingStatus.Loading;
  }

  ngOnInit(): void {}

  submit(): void {
    if (this.signInForm.valid) {
      this.handleLogin.emit(this.signInForm.value as LoginRequestModel);
    } else {
      this.signInForm.markAllAsTouched();
    }
  }
}
