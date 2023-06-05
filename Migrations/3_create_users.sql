Create table users (
    user_id bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    password_hash varchar(128) not null,
    is_test_account boolean,
    is_blocked boolean
);