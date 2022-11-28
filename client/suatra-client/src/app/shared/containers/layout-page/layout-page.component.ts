import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styleUrls: ['./layout-page.component.scss'],
})
export class LayoutPageComponent implements OnInit {
  @Input() sidebarHeader: string;
  @Input() hasSidebar: boolean = true;

  constructor() {}

  ngOnInit(): void {}
}
