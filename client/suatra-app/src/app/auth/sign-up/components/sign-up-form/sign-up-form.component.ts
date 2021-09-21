import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterRequestModel } from 'src/app/core/models';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss'],
})
export class SignUpFormComponent implements OnInit {
  signUpForm: FormGroup;
  @Input() loading: boolean;
  @Output() signUp = new EventEmitter<RegisterRequestModel>();

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.signUpForm = this.fb.group(
      {
        firstName: ['', [Validators.required]],
        otherName: '',
        lastName: ['', [Validators.required]],
        email: [
          '',
          [
            Validators.required,
            Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
          ],
        ],
        password: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]],
      },
      { validators: this.checkPasswords }
    );
  }

  checkPasswords(group: FormGroup) {
    const password = group.get('password').value;
    const confirmPassword = group.get('confirmPassword').value;
    return password === confirmPassword ? null : { notEqual: true };
  }

  submitForm(): void {
    if (this.signUpForm.valid) {
      const { confirmPassword, ...signupForms } = this.signUpForm.value;
      this.signUp.emit(signupForms);
    }
  }
}
