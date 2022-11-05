import { Component, OnInit } from '@angular/core';
import { Sizes, TableHeaders } from 'src/app/core/models';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrls: ['./list-page.component.scss'],
})
export class ListPageComponent implements OnInit {
  buttonSizes: typeof Sizes = Sizes;
  headers: TableHeaders[] = [
    {
      key: 'id',
      label: 'Id',
    },
    {
      key: 'name',
      label: 'Name',
    },
    {
      key: 'department',
      label: 'Department',
    },
  ];

  get students(): Student[] {
    return Array.from({ length: 20 }, (x, i) => ({
      name: `Student ${i}`,
      id: i,
      department: `Department - ${i}`,
    }));
  }
  constructor() {}

  ngOnInit(): void {}
}

interface Student {
  id: number;
  name: string;
  department: string;
}
