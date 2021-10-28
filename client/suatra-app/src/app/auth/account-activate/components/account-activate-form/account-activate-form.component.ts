import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-account-activate-form',
  templateUrl: './account-activate-form.component.html',
  styleUrls: ['./account-activate-form.component.scss'],
})
export class AccountActivateFormComponent implements OnInit {
  @Output() activate = new EventEmitter();
  @Input() loading: boolean;

  constructor() {}

  ngOnInit(): void {}

  onActivateAccount(): void {
    this.activate.emit();
  }
}
