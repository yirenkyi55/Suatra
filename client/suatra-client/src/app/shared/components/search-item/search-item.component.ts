import {
  Component,
  OnInit,
  OnDestroy,
  Output,
  Input,
  EventEmitter,
} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { SearchQuery } from 'src/app/core/models';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-search-item',
  templateUrl: './search-item.component.html',
  styleUrls: ['./search-item.component.scss'],
})
export class SearchItemComponent implements OnInit, OnDestroy {
  searchForm = this.fb.group({
    query: [''],
  });
  subSink = new SubSink();

  @Input() searchQuery: SearchQuery;

  @Output() handleSearchQuery = new EventEmitter<SearchQuery>();

  constructor(private fb: FormBuilder) {
    this.subSink.sink = this.searchForm.controls.query?.valueChanges.subscribe(
      (item) => {
        if (!item) {
          this.handleSearchQuery.emit({ query: null });
        }
      }
    );
  }

  ngOnInit(): void {
    if (this.searchQuery) {
      this.searchForm.patchValue({ query: this.searchQuery.query });
    }
  }

  emitSearchEvent(): void {
    this.handleSearchQuery.emit(this.searchForm.value as SearchQuery);
  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }
}
