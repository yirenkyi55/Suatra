import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import {
  ActionButton,
  ActionButtonData,
  TableHeaders,
} from 'src/app/core/models';
import { faCircleQuestion } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  listOfCurrentPageData: readonly any[] = [];
  questionIcon = faCircleQuestion;

  @Input() tableData: any[] = [];
  @Input() tableHeaders: TableHeaders[] = [];
  @Input() showActionButtons = false;
  @Input() actionButtons: ActionButton[] = [];
  @Input() hasClientSidePagination = true;

  @Output() handleActionButtonClick = new EventEmitter<ActionButtonData>();

  constructor() {}

  ngOnInit(): void {}

  onHandleActionButtonClick(tableItem: any, actionButton: ActionButton) {
    this.handleActionButtonClick.emit(
      new ActionButtonData(tableItem, actionButton)
    );
  }

  onCurrentPageDataChange(listOfCurrentPageData: readonly any[]): void {
    this.listOfCurrentPageData = listOfCurrentPageData;
  }
}
