import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourseRoutingModule } from './course-routing.module';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseListPageComponent } from './containers/course-list-page/course-list-page.component';


@NgModule({
  declarations: [
    CourseListComponent,
    CourseListPageComponent
  ],
  imports: [
    CommonModule,
    CourseRoutingModule
  ]
})
export class CourseModule { }
