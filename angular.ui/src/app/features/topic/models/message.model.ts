export default interface Message {
  messageId: number;
  payload: string;
  topicId: number;
}

export const EmptyMessage: Message = {
  messageId: 0,
  payload: '',
  topicId: 0,
};
