import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss'],
})
export class SignInFormComponent implements OnInit {
  signInForm: FormGroup;

  constructor(private fb: FormBuilder) {}

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
}
