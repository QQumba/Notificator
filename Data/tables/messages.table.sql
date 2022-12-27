-- drop table if exists notificator.messages cascade;
create table if not exists notificator.messages
(
    message_id bigserial primary key not null,
    payload    text                  not null,
    topic_id   bigint                not null,

    constraint fk_message_topic_id
        foreign key (topic_id)
            references notificator.topics (topic_id)
            on delete cascade
);