-- drop table if exists notificator.consumers cascade;
create table if not exists notificator.consumers
(
    consumer_id   bigserial primary key not null,
    address       text                  not null,
    consumer_type int                   not null,
    topic_id      bigint                not null,

    constraint fk_consumer_topic_id
        foreign key (topic_id)
            references notificator.topics (topic_id)
            on delete cascade
);