import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsumerListComponent } from './features/consumers/consumer-list/consumer-list.component';
import { TopicDetailsComponent } from './features/topic/topic-details/topic-details.component';
import { TopicListComponent } from './features/topic/topic-list/topic-list.component';
import { ApiTestComponent } from './shared/components/api-test/api-test.component';

const routes: Routes = [
  { path: '', redirectTo: 'test', pathMatch: 'full' },
  { path: 'topic/:id', component: TopicDetailsComponent },
  { path: 'topics', component: TopicListComponent },
  { path: 'consumers', component: ConsumerListComponent },
  { path: 'test', component: ApiTestComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
