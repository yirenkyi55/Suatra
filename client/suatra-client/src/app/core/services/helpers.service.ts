import { Injectable, SimpleChanges } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { LoadingStatus } from '../models';

@Injectable({
  providedIn: 'root',
})
export class HelperService {
  constructor() {}

  resetFormAfterLoading(
    loadingStatus: LoadingStatus | null,
    submitting: boolean,
    ...formGroup: FormGroup[]
  ): void {
    if (
      loadingStatus &&
      loadingStatus === LoadingStatus.Success &&
      submitting
    ) {
      submitting = false;
      formGroup && formGroup.map((form) => form.reset());
    }
  }
}
