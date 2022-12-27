import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiTestComponent } from './shared/components/api-test/api-test.component';
import { TopicListComponent } from './features/topic/topic-list/topic-list.component';
import { ConsumerListComponent } from './features/consumers/consumer-list/consumer-list.component';

import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';

import { CreateConsumerComponent } from './features/consumers/create-consumer/create-consumer.component';
import { FormsModule } from '@angular/forms';
import { CreateTopicComponent } from './features/topic/create-topic/create-topic.component';
import { TopicDetailsComponent } from './features/topic/topic-details/topic-details.component';
import { CreateMessageComponent } from './features/topic/create-message/create-message.component';

@NgModule({
  declarations: [
    AppComponent,
    ApiTestComponent,
    TopicListComponent,
    ConsumerListComponent,
    CreateConsumerComponent,
    CreateTopicComponent,
    TopicDetailsComponent,
    CreateMessageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatTableModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
