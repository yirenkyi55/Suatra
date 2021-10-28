import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountActivateFormComponent } from './components/account-activate-form/account-activate-form.component';
import { AccountActivatePageComponent } from './containers/account-activate-page/account-activate-page.component';

const routes: Routes = [{ path: '', component: AccountActivatePageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountActivateRoutingModule {
  static components = [
    AccountActivatePageComponent,
    AccountActivateFormComponent,
  ];
}
