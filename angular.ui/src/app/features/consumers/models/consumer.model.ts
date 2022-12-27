import { ConsumerType } from './consumer-type';

export interface Consumer {
  consumerId: number;
  address: string;
  topicId: number;
  consumerType: ConsumerType;
}

export const EmptyConsumer: Consumer = {
  consumerId: 0,
  address: '',
  topicId: 0,
  consumerType: 'Webhook',
};
