import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserModel } from 'src/app/core/models';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Input() isCollapsed = false;
  @Output() handleLogout = new EventEmitter<boolean>();
  @Input() user: UserModel | undefined;

  constructor() {}

  ngOnInit(): void {}

  onLogout(): void {
    this.handleLogout.emit(true);
  }
}
