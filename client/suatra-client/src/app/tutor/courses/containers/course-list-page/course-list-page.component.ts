import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromAppStore from 'src/app/store';
@Component({
  selector: 'app-course-list-page',
  templateUrl: './course-list-page.component.html',
  styleUrls: ['./course-list-page.component.scss'],
})
export class CourseListPageComponent implements OnInit {
  constructor(private appStore: Store<fromAppStore.State>) {}

  ngOnInit(): void {}

  onCreateNewCourse(): void {
    this.appStore.dispatch(
      fromAppStore.Go({ path: ['/tutor/courses', 0, 'create'] })
    );
  }
}
