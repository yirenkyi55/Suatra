import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {
  CreateCategoryModel,
  FieldSize,
  LoadingStatus,
} from 'src/app/core/models';
import { HelperService } from 'src/app/core/services';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.scss'],
})
export class CategoriesFormComponent implements OnInit, OnChanges {
  @Input() loadingStatus: LoadingStatus | null;
  submitting = false;

  categoryForm = this.fb.group({
    name: [
      '',
      [Validators.required, Validators.maxLength(FieldSize.MaxSizeOf128)],
    ],
  });

  @Output() submitCategory = new EventEmitter<CreateCategoryModel>();

  constructor(private fb: FormBuilder, private helperService: HelperService) {}
  ngOnChanges(changes: SimpleChanges): void {
    const { loadingStatus } = changes;
    if (
      loadingStatus &&
      loadingStatus.currentValue !== loadingStatus?.previousValue
    ) {
      this.helperService.resetFormAfterLoading(
        this.loadingStatus,
        this.submitting,
        this.categoryForm
      );
    }
  }

  ngOnInit(): void {}

  handleResetForm() {
    this.categoryForm.reset();
  }

  handleCreateForm(): void {
    if (this.categoryForm.valid) {
      this.submitting = true;
      this.submitCategory.emit(this.categoryForm.value as CreateCategoryModel);
    } else {
      this.categoryForm.markAllAsTouched();
    }
  }
}
