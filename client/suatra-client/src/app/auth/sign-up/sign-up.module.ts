import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignUpRoutingModule } from './sign-up-routing.module';
import { SignUpFormComponent } from './components/sign-up-form/sign-up-form.component';
import { SignUpPageComponent } from './containers/sign-up-page/sign-up-page.component';
import { AuthModule } from '../auth.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [SignUpFormComponent, SignUpPageComponent],
  imports: [CommonModule, SignUpRoutingModule, AuthModule, SharedModule],
})
export class SignUpModule {}
