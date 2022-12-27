export default interface Topic {
  topicId: number;
  name: string;
  description: string;
}

export const EmptyTopic: Topic = {
  topicId: 0,
  name: '',
  description: '',
};
