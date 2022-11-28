import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss'],
})
export class ModalComponent implements OnInit {
  @Input() visible = false;
  @Input() title = 'Modal Title';
  @Input() okText = 'Ok';
  @Input() cancelText = 'Cancel';
  @Input() okDisabled = false;
  @Input() cancelDisabled = false;
  @Input() width: number | string;
  @Input() okLoading = false;

  @Output() okClick = new EventEmitter<boolean>();
  @Output() cancelledClick = new EventEmitter<boolean>();

  constructor() {}

  handleOk(): void {
    this.okClick.emit(true);
  }

  handleCancel(): void {
    console.log('cancelling');
    this.cancelledClick.emit(true);
  }

  ngOnInit(): void {}
}
