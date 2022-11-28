import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  Output,
  EventEmitter,
  OnDestroy,
} from '@angular/core';
import {
  CategoryResponse,
  CreateCategoryModel,
  LoadingStatus,
  SearchQuery,
} from 'src/app/core/models';
import * as fromAppStore from 'src/app/core/store';
import { ActivatedRoute, Router } from '@angular/router';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-categories-page',
  templateUrl: './categories-page.component.html',
  styleUrls: ['./categories-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoriesPageComponent implements OnInit {
  showCreateForm = false;
  status$: Observable<LoadingStatus>;
  categories$: Observable<CategoryResponse[]>;

  constructor(
    private store: Store<fromAppStore.AppState>,
    private router: Router
  ) {
    this.status$ = this.store.select(fromAppStore.selectCategoriesStatus);
  }

  ngOnInit(): void {}

  handleCreateNewCategory() {
    this.showCreateForm = true;
  }

  hideCreateForm() {
    this.showCreateForm = false;
  }

  fetchCategoriesByName(searchQuery: SearchQuery) {
    this.categories$ = this.store.select(
      fromAppStore.selectCategoriesByName(searchQuery)
    );
  }

  handleCreateUpdateForm(requestModel: CreateCategoryModel): void {
    this.store.dispatch(fromAppStore.createCategoriesRequest({ requestModel }));
  }

  navigateToSubCategories(data: { category: string }): void {
    this.router.navigate(['/admin/sub-categories'], {
      queryParams: { category: data.category },
    });
  }
}
