-- drop table if exists notificator.topics cascade;
create table if not exists notificator.topics
(
    topic_id    bigserial primary key not null,
    name        text                  not null,
    description text                  null
);