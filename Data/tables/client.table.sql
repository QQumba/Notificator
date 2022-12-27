-- drop table if exists notificator.client cascade;
create table if not exists notificator.client
(
    client_id bigserial primary key not null,
    name      text                  not null unique
);