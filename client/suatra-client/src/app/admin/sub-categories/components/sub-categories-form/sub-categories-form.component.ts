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
  CategoryResponse,
  CreateSubCategoryModel,
  FieldSize,
  LoadingStatus,
  SubCategoryFilter,
} from 'src/app/core/models';
import { HelperService } from 'src/app/core/services';

@Component({
  selector: 'app-sub-categories-form',
  templateUrl: './sub-categories-form.component.html',
  styleUrls: ['./sub-categories-form.component.scss'],
})
export class SubCategoriesFormComponent implements OnInit, OnChanges {
  @Input() loadingStatus: LoadingStatus | null;
  @Input() categories: CategoryResponse[] | null = [];
  @Input() filteredItems: SubCategoryFilter | null = null;

  @Output() handleCreateNewSubCategory =
    new EventEmitter<CreateSubCategoryModel>();

  subCategoriesForm = this.fb.group({
    categoryId: ['', [Validators.required]],
    name: [
      '',
      [Validators.required, Validators.maxLength(FieldSize.MaxSizeOf128)],
    ],
  });
  submitting = false;

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
        this.subCategoriesForm
      );
    }

    this.patchFormWithFilters();
  }

  private patchFormWithFilters() {
    if (this.filteredItems) {
      if (this.filteredItems.category) {
        this.subCategoriesForm.patchValue({
          categoryId: this.filteredItems.category,
        });
      }
    }
  }

  ngOnInit(): void {}

  handleResetForm(): void {
    this.subCategoriesForm.reset();
    this.patchFormWithFilters();
  }

  handleCreateForm(): void {
    if (this.subCategoriesForm.valid) {
      this.submitting = true;
      this.handleCreateNewSubCategory.emit(
        this.subCategoriesForm.value as CreateSubCategoryModel
      );
    } else {
      this.subCategoriesForm.markAllAsTouched();
    }
  }
}
