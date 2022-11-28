import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  CategoryResponse,
  CreateSubCategoryModel,
  LoadingStatus,
  SubCategoryFilter,
  SubCategoryResponse,
} from 'src/app/core/models';
import * as fromAppStore from 'src/app/core/store';

@Component({
  selector: 'app-sub-categories-page',
  templateUrl: './sub-categories-page.component.html',
  styleUrls: ['./sub-categories-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SubCategoriesPageComponent implements OnInit {
  categories$: Observable<CategoryResponse[]>;
  subCategories$: Observable<SubCategoryResponse[]>;
  formStatus$: Observable<LoadingStatus>;
  subCategoryFilter: SubCategoryFilter = {};

  showCreateForm = false;

  constructor(private appStore: Store<fromAppStore.AppState>) {}

  ngOnInit(): void {
    this.categories$ = this.appStore.select(fromAppStore.selectCategories);
    this.formStatus$ = this.appStore.select(
      fromAppStore.selectSubCategoriesStatus
    );
    // this.subCategories$ = this.appStore.select(
    //   fromAppStore.selectSubCategories
    // );
  }

  hideCreateForm(): void {
    this.showCreateForm = false;
  }

  onShowCreateForm(): void {
    this.showCreateForm = true;
  }

  onCreateNewSubCategory(payload: CreateSubCategoryModel): void {
    this.appStore.dispatch(fromAppStore.createSubCategoryRequest({ payload }));
  }

  onFilterForm(payload: SubCategoryFilter): void {
    this.subCategoryFilter = payload;
    this.subCategories$ = this.appStore.select(
      fromAppStore.selectSubCategoriesByFilterAndSearching(
        this.subCategoryFilter
      )
    );
  }
}
