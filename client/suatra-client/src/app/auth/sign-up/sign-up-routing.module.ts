import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpPageComponent } from './containers/sign-up-page/sign-up-page.component';
import { SuccessPageComponent } from './containers/success-page/success-page.component';

const routes: Routes = [
  {
    path: '',
    component: SignUpPageComponent,
  },
  {
    path: 'success',
    component: SuccessPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SignUpRoutingModule {}
