import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignUpRoutingModule } from './sign-up-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthSharedModule } from '../auth-shared/auth-shared.module';

@NgModule({
  declarations: [SignUpRoutingModule.components],
  imports: [CommonModule, SignUpRoutingModule, SharedModule, AuthSharedModule],
})
export class SignUpModule {}
