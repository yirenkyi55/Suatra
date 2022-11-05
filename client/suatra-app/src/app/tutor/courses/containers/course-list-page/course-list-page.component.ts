import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as fromAppStore from 'src/app/core/store';

@Component({
  selector: 'app-course-list-page',
  templateUrl: './course-list-page.component.html',
  styleUrls: ['./course-list-page.component.scss'],
})
export class CourseListPageComponent implements OnInit {
  constructor(
    private store: Store<fromAppStore.ApplicationState>,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.store.dispatch(fromAppStore.GetCategoriesRequest());
  }

  onCreateCourse() {
    this.router.navigate(['0', 'create'], { relativeTo: this.route });
  }
}
