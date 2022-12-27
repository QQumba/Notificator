import { Component, EventEmitter, Output } from '@angular/core';
import {
  ConsumerType,
  ConsumerTypeAddress,
  ConsumerTypeValues,
} from '../models/consumer-type';
import { Consumer, EmptyConsumer } from '../models/consumer.model';
import { ConsumerService } from '../services/consumer.service';

@Component({
  selector: 'app-create-consumer',
  templateUrl: './create-consumer.component.html',
  styleUrls: ['./create-consumer.component.scss'],
})
export class CreateConsumerComponent {
  consumerTypes: ConsumerType[] = ConsumerTypeValues;
  @Output() consumerCreated = new EventEmitter<Consumer>();

  consumer = EmptyConsumer;

  constructor(private service: ConsumerService) {}

  getAddressType = () => ConsumerTypeAddress.get(this.consumer.consumerType);

  submitForm() {
    if (!this.consumer.address || !this.consumer.topicId) {
      return;
    }

    console.log(this.consumer);

    this.service.createConsumer(this.consumer).subscribe((result) => {
      this.consumerCreated.emit(result);
      this.consumer = EmptyConsumer;
    });
  }
}
