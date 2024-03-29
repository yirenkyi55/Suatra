import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { reducers, effects } from './store';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeaderComponent } from './components/dashboard/header/header.component';
import { SidebarComponent } from './components/dashboard/sidebar/sidebar.component';
import { SharedModule } from '../shared/shared.module';
import { EffectsModule } from '@ngrx/effects';
import { NotFoundComponent } from './components/not-found/not-found.component';

const modules = [
  CommonModule,
  RouterModule,
  HttpClientModule,
  FormsModule,
  ReactiveFormsModule,
];

@NgModule({
  declarations: [DashboardComponent, HeaderComponent, SidebarComponent, NotFoundComponent],
  imports: [
    ...modules,
    SharedModule,
    StoreModule.forFeature('applicationState', reducers),
    EffectsModule.forFeature(effects),
  ],
  exports: [...modules, DashboardComponent, HeaderComponent, SidebarComponent],
})
export class CoreModule {}
