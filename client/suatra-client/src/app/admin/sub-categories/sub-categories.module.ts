import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SubCategoriesRoutingModule } from './sub-categories-routing.module';
import { SubCategoriesListComponent } from './components/sub-categories-list/sub-categories-list.component';
import { SubCategoriesPageComponent } from './containers/sub-categories-page/sub-categories-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SubCategoriesFormComponent } from './components/sub-categories-form/sub-categories-form.component';

@NgModule({
  declarations: [SubCategoriesListComponent, SubCategoriesPageComponent, SubCategoriesFormComponent],
  imports: [CommonModule, SubCategoriesRoutingModule, SharedModule],
})
export class SubCategoriesModule {}
