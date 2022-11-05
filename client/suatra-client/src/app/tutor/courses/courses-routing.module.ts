import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseFormPageComponent } from './containers/course-form-page/course-form-page.component';
import { CourseListPageComponent } from './containers/course-list-page/course-list-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: 'list',
    component: CourseListPageComponent,
  },
  {
    path: ':courseId/create',
    component: CourseFormPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoursesRoutingModule {}
