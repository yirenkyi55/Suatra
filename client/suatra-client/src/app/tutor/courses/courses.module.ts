import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseFormComponent } from './components/course-form/course-form.component';
import { CourseListPageComponent } from './containers/course-list-page/course-list-page.component';
import { CourseFormPageComponent } from './containers/course-form-page/course-form-page.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    CourseListComponent,
    CourseFormComponent,
    CourseListPageComponent,
    CourseFormPageComponent,
  ],
  imports: [CommonModule, CoursesRoutingModule, SharedModule],
})
export class CoursesModule {}
