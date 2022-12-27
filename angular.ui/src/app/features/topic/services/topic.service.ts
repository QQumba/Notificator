import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Message from '../models/message.model';
import Topic from '../models/topic.model';

@Injectable({
  providedIn: 'root',
})
export class TopicService {
  constructor(private client: HttpClient) {}

  public getTopics(): Observable<Topic[]> {
    const url = 'api/topic';
    return this.client.get<Topic[]>(url);
  }

  public createTopic(topic: Topic): Observable<Topic> {
    const url = 'api/topic';
    return this.client.post<Topic>(url, topic);
  }

  public publishMessage(message: Message): Observable<void> {
    const url = 'api/topic/publish';
    return this.client.post<void>(url, message);
  }

  public getMessages(topicId: number): Observable<Message[]> {
    const url = `api/topic/${topicId}/messages`;
    return this.client.get<Message[]>(url);
  }
}
