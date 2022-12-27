import { Component } from '@angular/core';
import { EmptyTopic } from '../models/topic.model';
import { TopicService } from '../services/topic.service';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.scss'],
})
export class CreateTopicComponent {
  topic = EmptyTopic;

  constructor(private service: TopicService) {}

  createTopic() {
    if (!this.topic.name) {
      return;
    }

    this.service.createTopic(this.topic).subscribe((result) => {
      this.topic = EmptyTopic;
    });
  }
}
