import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ForgotPasswordRoutingModule } from './forgot-password-routing.module';
import { ForgotPasswordPageComponent } from './containers/forgot-password-page/forgot-password-page.component';
import { ForgotPasswordFormComponent } from './components/forgot-password-form/forgot-password-form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthModule } from '../auth.module';

@NgModule({
  declarations: [ForgotPasswordPageComponent, ForgotPasswordFormComponent],
  imports: [
    CommonModule,
    ForgotPasswordRoutingModule,
    SharedModule,
    AuthModule,
  ],
})
export class ForgotPasswordModule {}
