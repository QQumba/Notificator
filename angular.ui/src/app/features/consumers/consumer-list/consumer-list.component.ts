import { Component, OnInit } from '@angular/core';
import { Consumer } from '../models/consumer.model';
import { ConsumerService } from '../services/consumer.service';

@Component({
  selector: 'app-consumer-list',
  templateUrl: './consumer-list.component.html',
  styleUrls: ['./consumer-list.component.scss'],
})
export class ConsumerListComponent implements OnInit {
  displayedColumns: string[] = [
    'consumerId',
    'consumerType',
    'address',
    'topicId',
  ];
  consumers: Consumer[] = [];

  constructor(private service: ConsumerService) {}

  ngOnInit(): void {
    this.service.getAllConsumers().subscribe((c) => {
      this.consumers = c;
    });
  }
}
