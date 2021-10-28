import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [CoursesRoutingModule.components],
  imports: [CommonModule, CoursesRoutingModule, SharedModule],
})
export class CoursesModule {}
