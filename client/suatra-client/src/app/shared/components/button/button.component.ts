import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StateTypes, Sizes } from 'src/app/core/models';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent implements OnInit {
  @Input() type = StateTypes.Primary;
  @Input() isLoading = false;
  @Input() borderRadius = Sizes.Xxl;
  @Input() inverted = false;
  @Input() disabled = false;
  @Input() size = Sizes.Md;
  @Input() buttonType = 'submit';

  @Output() handleClick = new EventEmitter<Event>();

  get buttonClass(): string {
    let currentClass = `button button--radius-${Sizes[
      this.borderRadius
    ].toLocaleLowerCase()} button--sizes-${Sizes[
      this.size
    ].toLocaleLowerCase()}`;

    if (this.inverted) {
      currentClass += ` button--inverse-${StateTypes[this.type].toLowerCase()}`;
    } else {
      currentClass += ` button--state-${StateTypes[this.type].toLowerCase()}`;
    }

    return currentClass;
  }

  constructor() {}

  ngOnInit(): void {}

  onButtonClick(event: Event): void {
    this.handleClick.emit(event);
  }
}
