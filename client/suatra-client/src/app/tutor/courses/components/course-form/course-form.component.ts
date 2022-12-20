import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.scss'],
})
export class CourseFormComponent implements OnInit {
  currentIndex = 0;
  headers: string[] = ['About', 'Description', 'Audience'];
  constructor() {}
  ngOnInit(): void {}

  onPreviousButtonClick() {
    this.currentIndex -= 1;
  }

  onNextButtonClick() {
    this.currentIndex += 1;
  }

  onDoneButtonClick() {
    console.log('Process is done');
  }
}
