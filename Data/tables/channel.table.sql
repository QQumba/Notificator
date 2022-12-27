-- drop table if exists notificator.channel cascade;
create table if not exists notificator.channel
(
    channel_id  bigserial primary key not null,
    name        text                  not null,
    description text                  null,
    client_id   bigint                not null,

    constraint fk_channel_client_id
        foreign key (client_id)
            references notificator.client (client_id)
            on delete cascade
);