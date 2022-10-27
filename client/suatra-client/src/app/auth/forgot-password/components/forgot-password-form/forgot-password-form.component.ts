import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { faSignInAlt } from '@fortawesome/free-solid-svg-icons';
import { CustomValidators } from 'src/app/core/validators';

@Component({
  selector: 'app-forgot-password-form',
  templateUrl: './forgot-password-form.component.html',
  styleUrls: ['./forgot-password-form.component.scss'],
})
export class ForgotPasswordFormComponent implements OnInit {
  @Input() loading = false;
  faSignIn = faSignInAlt;
  forgotPasswordForm = this.fb.group({
    email: [
      '',
      [
        Validators.required,
        Validators.pattern(CustomValidators.EmailValidator),
      ],
    ],
  });

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {}

  submit(): void {}
}
