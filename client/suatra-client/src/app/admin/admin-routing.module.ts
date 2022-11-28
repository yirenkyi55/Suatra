import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  AuthGuard,
  CategoriesGuard,
  SubCategoriesGuard,
  TopicsGuard,
} from '../core/guards';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard, CategoriesGuard, SubCategoriesGuard, TopicsGuard],
    children: [
      {
        path: '',
        redirectTo: 'categories',
        pathMatch: 'full',
      },
      {
        path: 'categories',
        loadChildren: () =>
          import('./categories/categories.module').then(
            (m) => m.CategoriesModule
          ),
      },
      {
        path: 'sub-categories',
        loadChildren: () =>
          import('./sub-categories/sub-categories.module').then(
            (m) => m.SubCategoriesModule
          ),
      },
      {
        path: 'topics',
        loadChildren: () =>
          import('./topics/topics.module').then((m) => m.TopicsModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
