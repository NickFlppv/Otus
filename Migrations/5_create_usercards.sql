Create table usercards (
    usercard_id bigint not null PRIMARY KEY GENERATED ALWAYS AS IDENTITY, 
    user_id bigint not null, 
    email varchar(100) not null, 
    name varchar(100) not null, 
    surname varchar(100) not null,
    city_id integer,
    gender_id integer,
    user_interest_id integer,
    age smallint,
    is_deleted boolean,
    CONSTRAINT fk_user
      FOREIGN KEY(user_id) 
	  REFERENCES users(user_id)
);