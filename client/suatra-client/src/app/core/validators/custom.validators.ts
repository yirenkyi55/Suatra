import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class CustomValidators {
  static EmailValidator: string = '^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$';

  static MatchValidator(
    source: string,
    target: string
  ): ValidationErrors | null {
    return (control: AbstractControl): ValidationErrors | null => {
      const sourceCtrl = control.get(source);
      const targetCtrl = control.get(target);

      return sourceCtrl && targetCtrl && sourceCtrl.value !== targetCtrl.value
        ? { mismatch: true }
        : null;
    };
  }
}
