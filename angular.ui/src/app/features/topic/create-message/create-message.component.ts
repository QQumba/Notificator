import { Component, EventEmitter, Output } from '@angular/core';
import Message, { EmptyMessage } from '../models/message.model';
import { TopicService } from '../services/topic.service';

@Component({
  selector: 'app-create-message',
  templateUrl: './create-message.component.html',
  styleUrls: ['./create-message.component.scss'],
})
export class CreateMessageComponent {
  @Output() messagePublished = new EventEmitter<Message>();

  message = EmptyMessage;

  constructor(private service: TopicService) {}

  publishMessage() {
    if (!this.message.payload || !this.message.topicId) {
      return;
    }

    this.service.publishMessage(this.message).subscribe((result) => {
      this.message = EmptyMessage;
    });
  }
}
