Create table genders (
    genderId integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name text not null
);