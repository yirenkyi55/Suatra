import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountActivateRoutingModule } from './account-activate-routing.module';
import { AuthSharedModule } from '../auth-shared/auth-shared.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [AccountActivateRoutingModule.components],
  imports: [
    CommonModule,
    AccountActivateRoutingModule,
    AuthSharedModule,
    SharedModule,
  ],
})
export class AccountActivateModule {}
