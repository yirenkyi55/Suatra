import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss'],
})
export class CourseListComponent implements OnInit {
  @Output() createCourse = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}
  onCreateCourse() {
    this.createCourse.emit();
  }
}
