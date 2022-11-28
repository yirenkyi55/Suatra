import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopicsRoutingModule } from './topics-routing.module';
import { TopicsListComponent } from './components/topics-list/topics-list.component';
import { TopicsFormComponent } from './components/topics-form/topics-form.component';
import { TopicsListPageComponent } from './containers/topics-list-page/topics-list-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TopicFilterFormComponent } from './components/topic-filter-form/topic-filter-form.component';

@NgModule({
  declarations: [
    TopicsListComponent,
    TopicsFormComponent,
    TopicsListPageComponent,
    TopicFilterFormComponent,
  ],
  imports: [CommonModule, TopicsRoutingModule, SharedModule],
})
export class TopicsModule {}
