import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TopicsListPageComponent } from './containers/topics-list-page/topics-list-page.component';

const routes: Routes = [{ path: '', component: TopicsListPageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TopicsRoutingModule {}
