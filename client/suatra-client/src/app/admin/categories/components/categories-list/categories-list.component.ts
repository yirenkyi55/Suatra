import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import {
  ActionButton,
  ActionButtonData,
  ActionButtonTypes,
  CategoryResponse,
  SearchQuery,
  TableHeaders,
} from 'src/app/core/models';
import {
  faArrowAltCircleUp,
  faEdit,
  faTrash,
} from '@fortawesome/free-solid-svg-icons';
import { SubSink } from 'subsink/dist/subsink';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.scss'],
})
export class CategoriesListComponent implements OnInit {
  headerData: TableHeaders[] = [
    {
      key: 'name',
      label: 'Category Name',
    },
  ];
  actionButtons: ActionButton[] = [
    {
      type: ActionButtonTypes.Create,
      icon: faArrowAltCircleUp,
      toolTipMessage: 'Sub Categories',
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
  subs = new SubSink();
  searchQuery: SearchQuery;

  @Input() categories: CategoryResponse[] | null = [];

  @Output() handleNewCategory = new EventEmitter();
  @Output() handleNavigateToSubCategories = new EventEmitter<{
    category: string;
  }>();
  @Output() handleCategoryQuery = new EventEmitter<SearchQuery>();

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.subs.sink = this.route.queryParams.subscribe((params) => {
      const { query } = params;
      if (query) {
        this.initializeSearchQuery(query);
      } else {
        this.resetSearchQuery();
      }
      //   //Filter subCategories Contents by emitting event to parent
      this.handleCategoryQuery.emit(this.searchQuery);
    });
  }

  private initializeSearchQuery(query: any) {
    this.searchQuery = {
      query,
    };
  }

  private navigateWithQueryParams() {
    this.router.navigate(['.'], {
      relativeTo: this.route,
      queryParams: this.searchQuery,
    });
  }

  private resetSearchQuery() {
    this.searchQuery = {
      query: null,
    };
  }

  onNewButtonClick() {
    this.handleNewCategory.emit();
  }

  onHandleActionButtonClick(data: ActionButtonData): void {
    if (data.actionButton.type === ActionButtonTypes.Create) {
      const tableData = data.tableData as CategoryResponse;
      this.handleNavigateToSubCategories.emit({ category: tableData.id });
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  onSearchQuery(params: SearchQuery): void {
    this.searchQuery = params;
    this.navigateWithQueryParams();
  }
}
