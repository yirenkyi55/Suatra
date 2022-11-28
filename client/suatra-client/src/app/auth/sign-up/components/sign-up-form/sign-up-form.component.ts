import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import {
  AbstractControlOptions,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { faRegistered, faSignInAlt } from '@fortawesome/free-solid-svg-icons';
import { RegisterRequestModel } from 'src/app/core/models';
import { CustomValidators } from 'src/app/core/validators';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss'],
})
export class SignUpFormComponent implements OnInit {
  faSignIn = faSignInAlt;
  faRegistered = faRegistered;
  @Input() loading: boolean;
  @Output() handleSignUp = new EventEmitter<RegisterRequestModel>();

  signUpForm = this.fb.group(
    {
      firstName: ['', [Validators.required]],
      otherName: '',
      lastName: ['', [Validators.required]],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern(CustomValidators.EmailValidator),
        ],
      ],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    },
    {
      validators: [
        CustomValidators.MatchValidator('password', 'confirmPassword'),
      ],
    } as AbstractControlOptions
  );

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {}

  submitForm(): void {
    if (this.signUpForm.valid) {
      this.handleSignUp.emit(this.signUpForm.value as RegisterRequestModel);
    } else {
      this.signUpForm.markAllAsTouched();
    }
  }
}
