import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Topic from '../models/topic.model';
import { TopicService } from '../services/topic.service';

@Component({
  selector: 'app-topic-list',
  templateUrl: './topic-list.component.html',
  styleUrls: ['./topic-list.component.scss'],
})
export class TopicListComponent implements OnInit {
  displayedColumns: string[] = ['topicId', 'name', 'description'];
  topics: Topic[] = [];

  constructor(private service: TopicService, private router: Router) {}

  ngOnInit(): void {
    this.service.getTopics().subscribe((x) => {
      this.topics = x;
    });
  }

  openTopic(topic: Topic) {
    this.router.navigate(['topic', topic.topicId]);
  }
}
