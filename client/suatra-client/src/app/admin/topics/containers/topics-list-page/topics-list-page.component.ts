import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  CategoryResponse,
  CreateTopicRequestModel,
  LoadingStatus,
  SubCategoryResponse,
  TopicResponse,
  TopicsFilter,
} from 'src/app/core/models';
import * as fromStore from 'src/app/core/store';

@Component({
  selector: 'app-topics-list-page',
  templateUrl: './topics-list-page.component.html',
  styleUrls: ['./topics-list-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TopicsListPageComponent implements OnInit {
  showCreateForm = false;
  categories$: Observable<CategoryResponse[]>;
  subCategories$: Observable<SubCategoryResponse[]>;
  subCategoriesForFilter$: Observable<SubCategoryResponse[]>;
  topics$: Observable<TopicResponse[]>;
  topicStatus$: Observable<LoadingStatus>;

  constructor(private store: Store<fromStore.AppState>) {
    this.categories$ = this.store.select(fromStore.selectCategories);
    this.topicStatus$ = this.store.select(fromStore.selectTopicStatus);
  }

  getSubCategoriesByCategory(categoryId: string | null): void {
    this.subCategories$ = this.store.select(
      fromStore.selectSubCategoriesByCategoryId(categoryId)
    );
  }

  getSubCategoriesForFilter(categoryId: string | null): void {
    this.subCategoriesForFilter$ = this.store.select(
      fromStore.selectSubCategoriesByCategoryId(categoryId)
    );
  }

  ngOnInit(): void {}

  onCreateNewTopic(): void {
    this.showCreateForm = true;
  }

  onHideCreateForm(): void {
    this.showCreateForm = false;
  }

  onCreateTopic(payload: CreateTopicRequestModel): void {
    this.store.dispatch(fromStore.createTopicRequest({ payload }));
  }

  onFilterItem(filterParams: TopicsFilter): void {
    this.topics$ = this.store.select(
      fromStore.selectSubTopicsByFilterAndSearching(filterParams)
    );
  }
}
