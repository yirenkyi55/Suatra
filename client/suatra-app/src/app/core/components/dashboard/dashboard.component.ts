import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserModel, DashboardMenu } from '../../models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  isCollapsed = false;
  @Input() dashboardMenus: DashboardMenu[] = [];
  @Input() user: UserModel | undefined;
  collapsedClass = 'expanded';

  @Output() logout = new EventEmitter<boolean>();

  constructor() {}

  ngOnInit(): void {}

  onCollapse(collapse: boolean): void {
    this.isCollapsed = collapse;
  }

  onLogout(): void {
    this.logout.emit(true);
  }

  onSidebarCollapse(value: boolean) {
    this.collapsedClass = value ? 'collapse' : 'expanded';
  }
}
