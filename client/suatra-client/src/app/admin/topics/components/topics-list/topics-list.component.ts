import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  OnDestroy,
} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import {
  ActionButton,
  ActionButtonTypes,
  CategoryResponse,
  SearchQuery,
  SubCategoryResponse,
  TableHeaders,
  TopicResponse,
  TopicsFilter,
} from 'src/app/core/models';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-topics-list',
  templateUrl: './topics-list.component.html',
  styleUrls: ['./topics-list.component.scss'],
})
export class TopicsListComponent implements OnInit, OnDestroy {
  filterParams: TopicsFilter;
  searchQuery: SearchQuery;
  subs = new SubSink();

  tableHeaders: TableHeaders[] = [
    {
      key: 'name',
      label: 'Topic',
    },
    {
      key: 'subCategory.name',
      label: 'Sub Category',
    },
    {
      key: 'subCategory.category.name',
      label: 'Category',
    },
  ];
  actionButtons: ActionButton[] = [
    {
      type: ActionButtonTypes.Update,
      icon: faEdit,
      toolTipMessage: 'Update',
    },
    {
      type: ActionButtonTypes.Delete,
      icon: faTrash,
      toolTipMessage: 'Delete',
      confirmMessage: 'Are you sure you want to delete this record?',
    },
  ];
  filterForm = this.fb.group({
    category: [''],
    subcategory: [''],
  });

  @Input() topics: TopicResponse[] | null = [];
  @Input() categories: CategoryResponse[] | null = [];
  @Input() subCategories: SubCategoryResponse[] | null = [];

  @Output() handleGetSubCategory = new EventEmitter<string | null>();
  @Output() handleCreateNewTopic = new EventEmitter();
  @Output() handleFilterList = new EventEmitter<TopicsFilter>();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.subs.sink = this.activatedRoute.queryParams.subscribe((params) => {
      const { category, subcategory, query } = params;
      this.filterParams = { category, subcategory, query };

      if (category) {
        this.initializeCategoryFilter(category);
      } else {
        this.resetCategoryFilter();
      }

      if (subcategory) {
        this.initializeSubCategoryFilter(subcategory);
      } else {
        this.resetSubCategoryFilter();
      }

      if (query) {
        this.initializeSearchQuery(query);
      } else {
        this.resetSearchQuery();
      }

      this.handleFilterList.emit(this.filterParams);
    });
  }

  //Initialize Filters and Queries.
  private initializeCategoryFilter(category: any) {
    this.filterForm.patchValue({
      category,
    });

    this.filterParams = {
      ...this.filterParams,
      category,
    };
  }

  private initializeSubCategoryFilter(subcategory: any) {
    this.filterForm.patchValue({
      subcategory,
    });

    this.filterParams = {
      ...this.filterParams,
      subcategory,
    };
  }

  private initializeSearchQuery(query: any) {
    this.searchQuery = {
      query,
    };
    this.filterParams = {
      ...this.filterParams,
      query,
    };
  }

  //Reset Queries and Filters
  private resetSearchQuery() {
    this.searchQuery = {
      query: null,
    };
  }

  private resetCategoryFilter() {
    this.filterForm.patchValue({
      category: null,
    });
  }

  private resetSubCategoryFilter() {
    this.filterForm.patchValue({
      subcategory: null,
    });
  }

  private navigateWithQueryParams() {
    this.router.navigate(['.'], {
      relativeTo: this.activatedRoute,
      queryParams: this.filterParams,
    });
  }

  onCreateNewTopic(): void {
    this.handleCreateNewTopic.emit();
  }

  onRetrieveSubCategory(categoryId: string | null): void {
    this.handleGetSubCategory.emit(categoryId);
  }

  onSearchQuery(params: SearchQuery): void {
    this.searchQuery = params;
    this.filterParams = {
      ...this.filterParams,
      query: params.query,
    };
    this.navigateWithQueryParams();
  }

  onApplyFilter(): void {
    if (this.filterForm.valid) {
      const { category, subcategory } = this.filterForm.value;
      if (category) {
        this.filterParams = {
          ...this.filterParams,
          category,
        };
      }
      if (subcategory) {
        this.filterParams = {
          ...this.filterParams,
          subcategory,
        };
      }

      this.navigateWithQueryParams();
    }
  }

  onClearFilter(): void {
    this.filterForm.reset();
    this.filterParams = {
      ...this.filterParams,
      category: null,
      subcategory: null,
    };
    this.router.navigate(['.'], {
      relativeTo: this.activatedRoute,
      queryParams: this.filterParams,
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
