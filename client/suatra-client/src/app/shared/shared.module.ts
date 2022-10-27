import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { InputComponent } from './components/input/input.component';
import { ButtonComponent } from './components/button/button.component';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { AntModule } from './ant.module';

const declarations = [InputComponent, ButtonComponent, DropDownComponent];
const modules = [
  FormsModule,
  ReactiveFormsModule,
  AntModule,
  CommonModule,
  FontAwesomeModule,
];

@NgModule({
  declarations: [...declarations],
  imports: [...modules],
  exports: [...modules, ...declarations],
})
export class SharedModule {}
