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
import { LayoutPageComponent } from './containers/layout-page/layout-page.component';
import { ModalComponent } from './components/modal/modal.component';
import { CategoryFormComponent } from './components/forms/category-form/category-form.component';
import { SelectInputComponent } from './components/forms/select-input/select-input.component';
import { FormButtonsComponent } from './components/forms/form-buttons/form-buttons.component';
import { ObjectAccessorPipe } from './pipes/object-accessor.pipe';
import { StatusLoadingPipe } from './pipes/status-loading.pipe';
import { SwitchDisplayPipe } from './pipes/switch-display.pipe';
import { StepsWrapperComponent } from './components/steps-wrapper/steps-wrapper.component';

const declarations = [
  InputComponent,
  ButtonComponent,
  DropDownComponent,
  AuthFormComponent,
  SvgComponent,
  EditPageComponent,
  ListPageComponent,
  PageHeaderComponent,
  ModalComponent,
  CategoryFormComponent,
  SelectInputComponent,
  FormButtonsComponent,
  ObjectAccessorPipe,
  StatusLoadingPipe,
  SwitchDisplayPipe,
  StepsWrapperComponent,
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
  declarations: [
    ...declarations,
    SearchItemComponent,
    TableComponent,
    LayoutPageComponent,
  ],
  imports: [...modules],
  exports: [...modules, ...declarations],
})
export class SharedModule {}
