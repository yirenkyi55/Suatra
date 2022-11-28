import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faPlus, faRefresh } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-form-buttons',
  templateUrl: './form-buttons.component.html',
  styleUrls: ['./form-buttons.component.scss'],
})
export class FormButtonsComponent implements OnInit {
  plusIcon = faPlus;
  resetIcon = faRefresh;
  @Output() handleResetForm = new EventEmitter();
  @Input() isLoading = false;

  constructor() {}

  ngOnInit(): void {}

  onHandleResetForm(): void {
    this.handleResetForm.emit();
  }
}
