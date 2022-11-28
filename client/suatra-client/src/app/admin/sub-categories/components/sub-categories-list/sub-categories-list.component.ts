import {
  Component,
  Input,
  OnInit,
  EventEmitter,
  Output,
  AfterViewInit,
  OnDestroy,
} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  faArrowAltCircleUp,
  faEdit,
  faTrash,
} from '@fortawesome/free-solid-svg-icons';
import {
  ActionButton,
  ActionButtonTypes,
  CategoryResponse,
  SearchQuery,
  SubCategoryFilter,
  SubCategoryResponse,
  TableHeaders,
} from 'src/app/core/models';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-sub-categories-list',
  templateUrl: './sub-categories-list.component.html',
  styleUrls: ['./sub-categories-list.component.scss'],
})
export class SubCategoriesListComponent implements OnInit, OnDestroy {
  searchQuery: SearchQuery;
  subs = new SubSink();
  filterParams: SubCategoryFilter = { category: null, query: null };
  tableHeaders: TableHeaders[] = [
    {
      key: 'name',
      label: 'Name',
    },
    {
      key: 'category.name',
      label: 'Category',
    },
  ];
  actionButtons: ActionButton[] = [
    {
      type: ActionButtonTypes.Create,
      icon: faArrowAltCircleUp,
      toolTipMessage: 'Topics',
    },
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
    category: [],
  });

  @Input() categories: CategoryResponse[] | null = [];
  @Input() subCategories: SubCategoryResponse[] | null = [];

  @Output() handleShowCreateForm = new EventEmitter();
  @Output() handleFilteredForm = new EventEmitter<SubCategoryFilter>();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.subs.sink = this.route.queryParams.subscribe((params) => {
      const { category, query } = params;
      this.filterParams = { category: null, query: null };
      if (category) {
        this.initializeCategoryFilter(category);
      } else {
        this.resetCategoryFilter();
      }
      if (query) {
        this.initializeSearchQuery(query);
      } else {
        this.resetSearchQuery();
      }
      //   //Filter subCategories Contents by emitting event to parent
      this.handleFilteredForm.emit(this.filterParams);
    });
  }

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

  private initializeSearchQuery(query: any) {
    this.searchQuery = {
      query,
    };
    this.filterParams = {
      ...this.filterParams,
      query,
    };
  }

  private initializeCategoryFilter(category: any) {
    this.filterForm.patchValue({
      category,
    });

    this.filterParams = {
      ...this.filterParams,
      category,
    };
  }

  private navigateWithQueryParams() {
    this.router.navigate(['.'], {
      relativeTo: this.route,
      queryParams: this.filterParams,
    });
  }

  onShowCreateForm(): void {
    this.handleShowCreateForm.emit();
  }

  onClearFilter(): void {
    this.filterForm.reset();
    this.filterParams = {
      ...this.filterParams,
      category: null,
    };
    this.router.navigate(['.'], {
      relativeTo: this.route,
      queryParams: this.filterParams,
    });
  }

  onApplyFilter(): void {
    if (this.filterForm.valid) {
      if (this.filterForm.value.category) {
        this.filterParams = {
          ...this.filterParams,
          category: this.filterForm.value.category,
        };
      }

      this.navigateWithQueryParams();
    }
  }

  onSearchQuery(params: SearchQuery): void {
    this.searchQuery = params;
    this.filterParams = {
      ...this.filterParams,
      query: params.query,
    };
    this.navigateWithQueryParams();
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
