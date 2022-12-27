import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Consumer } from '../models/consumer.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerService {
  constructor(private client: HttpClient) {}

  public getAllConsumers(): Observable<Consumer[]> {
    const url = 'api/consumer/all';
    return this.client.get<Consumer[]>(url);
  }

  public getConsumersByTopicId(topicId: number): Observable<Consumer[]> {
    const url = 'api/consumer';
    const params = { topicId };
    return this.client.get<Consumer[]>(url, { params });
  }

  public createConsumer(consumer: Consumer): Observable<Consumer> {
    const url = 'api/consumer/subscribe';
    return this.client.post<Consumer>(url, consumer);
  }
}
