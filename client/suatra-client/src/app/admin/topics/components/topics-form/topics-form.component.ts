import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  OnDestroy,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {
  CategoryResponse,
  CreateTopicRequestModel,
  FieldSize,
  LoadingStatus,
  SubCategoryResponse,
} from 'src/app/core/models';
import { HelperService } from 'src/app/core/services';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-topics-form',
  templateUrl: './topics-form.component.html',
  styleUrls: ['./topics-form.component.scss'],
})
export class TopicsFormComponent implements OnInit, OnChanges, OnDestroy {
  subs = new SubSink();
  submitting = false;
  topicsForm = this.fb.group({
    name: [
      '',
      [Validators.required, Validators.maxLength(FieldSize.MaxSizeOf128)],
    ],
    subCategoryId: ['', [Validators.required]],
    categoryId: ['', [Validators.required]],
  });

  @Input() subCategories: SubCategoryResponse[] | null = [];
  @Input() categories: CategoryResponse[] | null = [];
  @Input() loadingStatus: LoadingStatus | null;

  @Output() handleGetSubCategory = new EventEmitter<string | null>();
  @Output() handleCreateTopic = new EventEmitter<CreateTopicRequestModel>();

  constructor(private fb: FormBuilder, private helperService: HelperService) {}

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges): void {
    const { loadingStatus } = changes;
    if (
      loadingStatus &&
      loadingStatus.currentValue !== loadingStatus?.previousValue
    ) {
      this.helperService.resetFormAfterLoading(
        this.loadingStatus,
        this.submitting,
        this.topicsForm
      );
    }
  }

  handleCreateForm(): void {
    if (this.topicsForm.valid) {
      this.submitting = true;
      this.handleCreateTopic.emit({
        subCategoryId: this.topicsForm.value.subCategoryId!,
        name: this.topicsForm.value.name!,
      });
    } else {
      this.topicsForm.markAllAsTouched();
    }
  }

  handleResetForm(): void {
    this.topicsForm.reset();
  }

  onRetrieveSubCategory(categoryId: string | null): void {
    this.handleGetSubCategory.emit(categoryId);
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
