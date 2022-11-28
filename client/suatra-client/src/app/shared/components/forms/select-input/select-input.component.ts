import {
  AfterContentChecked,
  ChangeDetectorRef,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-select-input',
  templateUrl: './select-input.component.html',
  styleUrls: ['./select-input.component.scss'],
})
export class SelectInputComponent implements OnInit, AfterContentChecked {
  form: FormGroup;
  @Input() items: any[] = [];
  @Input() control: FormControl;
  @Input() itemLabel: string;
  @Input() itemValue: string;
  @Input() placeHolderText: string;
  @Input() label: string;
  status: '' | 'warning' | 'error' = '';

  constructor(private ref: ChangeDetectorRef) {}

  ngOnInit(): void {}

  ngAfterContentChecked(): void {
    this.ref.detectChanges();
  }

  get isInvalid() {
    const status = this.control.touched && this.control.errors?.required;

    if (status) {
      this.status = 'error';
    } else {
      this.status = '';
    }

    return status;
  }
}
