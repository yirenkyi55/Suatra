import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

import { AuthRoutingModule } from './auth-routing.module';
import { effects, reducers } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AuthRoutingModule,
    StoreModule.forFeature('authState', reducers),
    EffectsModule.forFeature(effects),
  ],
})
export class AuthModule {}
