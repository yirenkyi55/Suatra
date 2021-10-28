import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseCreateComponent } from './components/course-create/course-create.component';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseCreatePageComponent } from './containers/course-create-page/course-create-page.component';
import { CourseListPageComponent } from './containers/course-list-page/course-list-page.component';
const routes: Routes = [
  { path: '', component: CourseListPageComponent },
  { path: ':courseId/create', component: CourseCreatePageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoursesRoutingModule {
  static components = [
    CourseListComponent,
    CourseListPageComponent,
    CourseCreatePageComponent,
    CourseCreateComponent,
  ];
}
