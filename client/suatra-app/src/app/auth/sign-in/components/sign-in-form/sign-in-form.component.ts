import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { faSignInAlt, faRegistered } from '@fortawesome/free-solid-svg-icons';
import { LoginRequestModel } from 'src/app/core/models';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss'],
})
export class SignInFormComponent implements OnInit {
  signInForm: UntypedFormGroup;
  faSignIn = faSignInAlt;
  faRegister = faRegistered;
  @Input() loading: boolean;
  @Output() login = new EventEmitter<LoginRequestModel>();

  constructor(private fb: UntypedFormBuilder) {}

  ngOnInit(): void {
    this.signInForm = this.fb.group({
      email: [
        '',
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
        ],
      ],
      password: ['', [Validators.required]],
    });
  }

  submitForm(): void {
    if (this.signInForm.valid) {
      this.login.emit(this.signInForm.value);
    }
  }
}
