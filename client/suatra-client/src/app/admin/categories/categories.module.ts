import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoriesFormComponent } from './components/categories-form/categories-form.component';
import { CategoriesPageComponent } from './containers/categories-page/categories-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CategoriesListComponent } from './components/categories-list/categories-list.component';

@NgModule({
  declarations: [CategoriesFormComponent, CategoriesPageComponent, CategoriesListComponent],
  imports: [CommonModule, CategoriesRoutingModule, SharedModule],
})
export class CategoriesModule {}
