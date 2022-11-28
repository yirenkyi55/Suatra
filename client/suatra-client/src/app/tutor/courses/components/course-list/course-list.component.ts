import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss'],
})
export class CourseListComponent implements OnInit {
  @Output() handleCreateNewCourse = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  onNewButtonClick(): void {
    this.handleCreateNewCourse.emit();
  }
}
