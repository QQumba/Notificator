import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Message from '../models/message.model';
import { TopicService } from '../services/topic.service';

@Component({
  selector: 'app-topic-details',
  templateUrl: './topic-details.component.html',
  styleUrls: ['./topic-details.component.scss'],
})
export class TopicDetailsComponent implements OnInit {
  displayedColumns: string[] = ['messageId', 'payload', 'topicId'];
  topicId = 0;
  messages: Message[] = [];

  constructor(private service: TopicService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.topicId = +params['id'];

      console.log(this.topicId);
      this.service.getMessages(this.topicId).subscribe((result) => {
        this.messages = result;
      });
    });
  }
}
