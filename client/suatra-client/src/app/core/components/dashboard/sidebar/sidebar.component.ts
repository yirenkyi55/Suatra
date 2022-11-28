import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DashboardMenu, UserModel } from 'src/app/core/models';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  @Input() isCollapsed = true;
  @Input() dashboardMenus: DashboardMenu[] = [];
  @Output() sidebarCollapse = new EventEmitter<boolean>();
  @Input() user: UserModel | null;

  constructor() {}

  ngOnInit(): void {}

  onCollapseChange(isCollapsed: boolean) {
    this.sidebarCollapse.emit(isCollapsed);
  }
}
