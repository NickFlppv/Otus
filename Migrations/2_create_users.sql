Create table users (
    "userId" bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    email varchar(100) not null, 
    password text not null,
    "registeredAt" date not null,
    "isTestAccount" boolean,
    "isBlocked" boolean
);