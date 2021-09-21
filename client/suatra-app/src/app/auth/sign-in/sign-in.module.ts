import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignInRoutingModule } from './sign-in-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthSharedModule } from '../auth-shared/auth-shared.module';

@NgModule({
  declarations: [SignInRoutingModule.components],
  imports: [CommonModule, SignInRoutingModule, SharedModule, AuthSharedModule],
})
export class SignInModule {}
