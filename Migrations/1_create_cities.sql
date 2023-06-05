Create table cities (
    city_id integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name varchar(100) not null
);