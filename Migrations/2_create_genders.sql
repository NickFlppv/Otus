Create table genders (
    gender_id integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name text not null
);