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
import { FormControl } from '@angular/forms';
import { CategoryResponse, SubCategoryResponse } from 'src/app/core/models';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-topic-filter-form',
  templateUrl: './topic-filter-form.component.html',
  styleUrls: ['./topic-filter-form.component.scss'],
})
export class TopicFilterFormComponent implements OnInit, OnDestroy, OnChanges {
  subs = new SubSink();

  @Input() subCategories: SubCategoryResponse[] | null = [];
  @Input() categories: CategoryResponse[] | null = [];
  @Input() subCategoryControl: FormControl;
  @Input() categoryControl: FormControl;

  @Output() handleGetSubCategory = new EventEmitter<string | null>();

  constructor() {}

  ngOnInit(): void {
    this.handleGetSubCategory.emit(null);
    this.selectSubCategoryOnCategoryChanges();
    this.resetDesiredCategoryOnSubCategoryChanges();
  }

  ngOnChanges(changes: SimpleChanges): void {}

  private resetDesiredCategoryOnSubCategoryChanges() {
    this.subs.sink = this.subCategoryControl.valueChanges.subscribe((id) => {
      if (id) {
        const subCategory = this.subCategories?.find((x) => x.id === id);
        // const selectedCategory = this.topicsForm.value.categoryId;
        const selectedCategory = this.categoryControl.value as string;
        //if the selected subCategory does not belongs to the category, we need to reselect the
        //corresponding category.
        if (subCategory && subCategory.category.id !== selectedCategory) {
          this.categoryControl.setValue(subCategory.category.id);
        }
      }
    });
  }

  private selectSubCategoryOnCategoryChanges() {
    this.subs.sink = this.categoryControl.valueChanges.subscribe((id) => {
      //We need to emit based on certain conditions->
      //When subcategory does not belongs to the category.
      const selectedSubCategoryId = this.subCategoryControl.value as string;
      if (!selectedSubCategoryId) {
        this.handleGetSubCategory.emit(id);
      } else {
        const subCategory = this.subCategories?.find(
          (x) => x.id === selectedSubCategoryId
        );
        if (subCategory && subCategory.category.id !== id) {
          //we know the selectedSubCategory does not belongs to the selected category
          //We need to reset the selectedSubCategory and fetch the right data.
          this.subCategoryControl.reset();
          this.handleGetSubCategory.emit(id);
        }
      }
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
