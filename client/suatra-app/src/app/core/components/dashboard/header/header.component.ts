import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserModel } from 'src/app/core/models';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Input() isCollapsed = false;
  @Output() collapse = new EventEmitter<boolean>();
  @Output() logout = new EventEmitter<boolean>();
  @Input() user: UserModel | undefined;

  constructor() {}

  ngOnInit(): void {}

  onCollapse(): void {
    this.collapse.emit(!this.isCollapsed);
  }

  onLogout(): void {
    this.logout.emit(true);
  }
}
