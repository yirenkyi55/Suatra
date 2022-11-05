import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { InputComponent } from './components/input/input.component';
import { ButtonComponent } from './components/button/button.component';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { AntModule } from './ant.module';
import { RouterModule } from '@angular/router';
import { AuthFormComponent } from './components/auth-form/auth-form.component';
import { SvgComponent } from './components/svg/svg.component';
import { EditPageComponent } from './containers/edit-page/edit-page.component';
import { ListPageComponent } from './containers/list-page/list-page.component';
import { SearchItemComponent } from './components/search-item/search-item.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { TableComponent } from './components/table/table.component';

const declarations = [
  InputComponent,
  ButtonComponent,
  DropDownComponent,
  AuthFormComponent,
  SvgComponent,
  EditPageComponent,
  ListPageComponent,
  PageHeaderComponent,
];
const modules = [
  FormsModule,
  ReactiveFormsModule,
  AntModule,
  CommonModule,
  FontAwesomeModule,
  RouterModule,
  HttpClientModule,
];

@NgModule({
  declarations: [...declarations, SearchItemComponent, TableComponent],
  imports: [...modules],
  exports: [...modules, ...declarations],
})
export class SharedModule {}
