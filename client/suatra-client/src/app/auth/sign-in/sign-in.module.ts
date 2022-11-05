import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignInRoutingModule } from './sign-in-routing.module';
import { SignInFormComponent } from './components/sign-in-form/sign-in-form.component';
import { SignInPageComponent } from './containers/sign-in-page/sign-in-page.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [SignInFormComponent, SignInPageComponent],
  imports: [CommonModule, SignInRoutingModule, SharedModule],
  exports: [SignInPageComponent],
})
export class SignInModule {}
