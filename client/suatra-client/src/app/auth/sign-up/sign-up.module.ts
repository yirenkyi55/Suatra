import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignUpRoutingModule } from './sign-up-routing.module';
import { SignUpFormComponent } from './components/sign-up-form/sign-up-form.component';
import { SignUpPageComponent } from './containers/sign-up-page/sign-up-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SuccessPageComponent } from './containers/success-page/success-page.component';

@NgModule({
  declarations: [
    SignUpFormComponent,
    SignUpPageComponent,
    SuccessPageComponent,
  ],
  imports: [CommonModule, SignUpRoutingModule, SharedModule],
})
export class SignUpModule {}
