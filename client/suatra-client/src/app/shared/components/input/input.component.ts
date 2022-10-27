import {
  Component,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
  Input,
  ElementRef,
  Self,
} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
})
export class InputComponent implements OnInit, ControlValueAccessor, OnChanges {
  @ViewChild('input', { static: true }) input: ElementRef;
  @Input() type = 'text';
  @Input() label = 'Input Field';
  @Input() placeholder: string;
  @Input() disableValidation = false;
  @Input() invalidMessage = 'Invalid Input';
  @Input() hasFocus = false;
  @Input() min: number;
  @Input() max: number;
  @Input() validityErrorName: string;

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }

  ngOnChanges(changes: SimpleChanges): void {
    const { hasFocus } = changes;
    if (hasFocus && hasFocus.currentValue) {
      this.input.nativeElement.focus();
    }
  }

  ngOnInit(): void {
    const control = this.controlDir?.control;
    const validators = control?.validator ? [control.validator] : [];
    const asyncValidators = control?.asyncValidator
      ? [control.asyncValidator]
      : [];

    control?.setValidators(validators);
    control?.setAsyncValidators(asyncValidators);
    control?.updateValueAndValidity();
  }

  get validationIconStatus() {
    if (this.disableValidation) {
      return '';
    }
    if (this.isInValidState) {
      return 'error';
    } else if (this.pendingStatus) {
      return 'validating';
    } else if (this.controlDir.control?.valid) {
      return 'success';
    }
    return '';
  }

  // Determine whether the state of the control is not valid
  get isInValidState() {
    const invalid =
      this.required || this.inValidPattern || this.minLength || this.minValue;

    if (this.validityErrorName) {
      return invalid || this.notValidControl;
    }

    return invalid;
  }

  // Determines whether the control is busy performing server validation
  get pendingStatus() {
    return this.controlDir.control?.status === 'PENDING';
  }

  get notValidControl() {
    return (
      this.controlDir.control?.errors &&
      this.controlDir.control.errors[this.validityErrorName]
    );
  }

  // Determines whether the control is not valid and has been touched at the same time
  get notValidAndTouched() {
    return this.controlDir.control?.invalid && this.controlDir.control.touched;
  }

  get minLength() {
    return (
      this.notValidAndTouched && this.controlDir.control?.errors?.minlength
    );
  }

  get minValue() {
    return this.notValidAndTouched && this.controlDir.control?.errors?.min;
  }

  get requiredLengthFromMinLength() {
    return this.controlDir.control?.errors?.minlength?.requiredLength;
  }

  get requiredMinValue() {
    return this.controlDir.control?.errors?.min?.min;
  }

  // Determines whether the control input is required
  get required() {
    return this.notValidAndTouched && this.controlDir.control?.errors?.required;
  }

  // Determines whether the control pattern is not satisfied
  get inValidPattern() {
    return this.notValidAndTouched && this.controlDir.control?.errors?.pattern;
  }

  onChange(event: string) {}
  onTouched() {}

  writeValue(obj: any): void {
    this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.input.nativeElement.disabled = isDisabled;
  }
}
