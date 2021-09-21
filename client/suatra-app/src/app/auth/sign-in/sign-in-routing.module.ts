import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInFormComponent } from './components/sign-in-form/sign-in-form.component';
import { SignInPageComponent } from './containers/sign-in-page/sign-in-page.component';

const routes: Routes = [
  {
    path: '',
    component: SignInPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SignInRoutingModule {
  static components = [SignInPageComponent, SignInFormComponent];
}
