Create table user_interests (
    user_interest_id integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name text not null,
    usercard_id bigint null
);