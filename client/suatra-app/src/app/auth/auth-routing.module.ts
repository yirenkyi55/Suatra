import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserGuard } from '../core/guards';

const routes: Routes = [
  {
    path: 'auth',
    canActivate: [UserGuard],
    children: [
      {
        path: '',
        redirectTo: 'sign-in',
        pathMatch: 'full',
      },
      {
        path: 'sign-in',
        loadChildren: () =>
          import('./sign-in/sign-in.module').then((m) => m.SignInModule),
      },
      {
        path: 'sign-up',
        loadChildren: () =>
          import('./sign-up/sign-up.module').then((m) => m.SignUpModule),
      },
      {
        path: 'forgot-password',
        loadChildren: () =>
          import('./forgot-password/forgot-password.module').then(
            (m) => m.ForgotPasswordModule
          ),
      },
      {
        path: 'activate',
        loadChildren: () =>
          import('./account-activate/account-activate.module').then(
            (m) => m.AccountActivateModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
