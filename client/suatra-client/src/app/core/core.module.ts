import { StoreModule } from '@ngrx/store';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreLoadedOnceGuard } from './core-loaded-once.guard';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeaderComponent } from './components/dashboard/header/header.component';
import { SharedModule } from '../shared/shared.module';
import { SidebarComponent } from './components/dashboard/sidebar/sidebar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

import { reducers, effects } from './store';
import { EffectsModule } from '@ngrx/effects';

const components = [DashboardComponent, HeaderComponent, NotFoundComponent];

@NgModule({
  declarations: [...components, SidebarComponent],
  imports: [
    CommonModule,
    SharedModule,
    StoreModule.forFeature('appState', reducers),
    EffectsModule.forFeature(effects),
  ],
  exports: [...components],
})
export class CoreModule extends CoreLoadedOnceGuard {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    super(parentModule); // calls the coreLoadedOnceGuard constructor to validate this module.
  }
}
