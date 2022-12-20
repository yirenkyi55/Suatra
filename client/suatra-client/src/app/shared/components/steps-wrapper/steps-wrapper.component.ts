import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-steps-wrapper',
  templateUrl: './steps-wrapper.component.html',
  styleUrls: ['./steps-wrapper.component.scss'],
})
export class StepsWrapperComponent implements OnInit {
  @Input() title: string;
  @Input() nextButtonText: string = 'Next';
  @Input() previousButtonText: string = 'Previous';
  @Input() doneButtonText: string = 'Done';
  @Input() headers: string[] = ['Step 1', 'Step 2', 'Step 3'];
  @Input() currentIndex: number = 0;

  @Output() handlePreviousButtonClick = new EventEmitter();
  @Output() handleNextButtonClick = new EventEmitter();
  @Output() handleDoneButtonClick = new EventEmitter();

  pre(): void {
    this.handlePreviousButtonClick.emit();
  }

  next(): void {
    this.handleNextButtonClick.emit();
  }

  done(): void {
    this.handleDoneButtonClick.emit();
  }

  get isInLastStep(): boolean {
    return this.currentIndex === this.headers.length - 1;
  }

  constructor() {}

  ngOnInit(): void {}
}
