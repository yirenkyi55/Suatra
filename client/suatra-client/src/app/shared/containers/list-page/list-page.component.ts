import {
  Component,
  Input,
  OnInit,
  Output,
  EventEmitter,
  ContentChild,
} from '@angular/core';
import {
  ActionButton,
  ActionButtonData,
  SearchQuery,
  Sizes,
  TableHeaders,
} from 'src/app/core/models';
import { faPlusCircle, faFilter } from '@fortawesome/free-solid-svg-icons';
import { CategoriesPageComponent } from 'src/app/admin/categories/containers/categories-page/categories-page.component';
import { CategoriesListComponent } from 'src/app/admin/categories/components/categories-list/categories-list.component';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrls: ['./list-page.component.scss'],
})
export class ListPageComponent implements OnInit {
  plusIcon = faPlusCircle;
  filterIcon = faFilter;
  buttonSizes: typeof Sizes = Sizes;

  @Input() tableHeaders: TableHeaders[] = [];
  @Input() tableData: any[] = [];
  @Input() pageHeading: string;
  @Input() hasSideBar: boolean = true;
  @Input() showActionButtons = false;
  @Input() actionButtons: ActionButton[] = [];
  @Input() searchQuery: SearchQuery;
  @Input() filterParams: SearchQuery;

  @Output() handleNewButtonClick = new EventEmitter();
  @Output() handleClearFilter = new EventEmitter();
  @Output() handleApplyFilter = new EventEmitter();
  @Output() handleActionButtonClick = new EventEmitter<ActionButtonData>();
  @Output() handleSearchQuery = new EventEmitter<SearchQuery>();

  constructor() {}

  ngOnInit(): void {}

  onNewButtonClick(): void {
    this.handleNewButtonClick.emit();
  }

  onApplyFilter(): void {
    this.handleApplyFilter.emit();
  }

  onClearFilter(): void {
    this.handleClearFilter.emit();
  }

  onHandleactionButtonClick(data: ActionButtonData): void {
    this.handleActionButtonClick.emit(data);
  }

  onHandleSearchQuery(query: SearchQuery): void {
    this.handleSearchQuery.emit(query);
  }

  get filteredItemsCount(): number {
    let numberOfFilters = 0;
    if (this.filterParams) {
      Object.keys(this.filterParams).map((item) => {
        let key = item as keyof typeof this.filterParams;
        if (this.filterParams[key] && key !== 'query') {
          numberOfFilters++;
        }
      });
    }

    return numberOfFilters;
  }
}
