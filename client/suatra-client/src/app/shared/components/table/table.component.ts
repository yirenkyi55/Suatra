import { Component, Input, OnInit } from '@angular/core';
import { TableHeaders } from 'src/app/core/models';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  @Input() data: any[] = [];
  @Input() headers: TableHeaders[] = [];
  constructor() {}

  ngOnInit(): void {}
}
