const CONSUMER_TYPE = [
  ['Webhook', 'Url'],
  // ['Telegram', 'Chat Id'],
  ['Email', 'Email'],
] as const;

export type ConsumerType = typeof CONSUMER_TYPE[number][0];
// export type ConsumerAddress = typeof CONSUMER_TYPE[number][1];
export const ConsumerTypeValues = CONSUMER_TYPE.map((t) => t[0]);
export const ConsumerTypeAddress = getConsumerTypeAddress();

function getConsumerTypeAddress(): Map<ConsumerType, string> {
  const map = new Map<ConsumerType, string>();
  CONSUMER_TYPE.forEach((type) => {
    map.set(type[0], type[1]);
  });
  return map;
}
