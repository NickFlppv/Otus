Create table usercards (
    userCardId bigint not null PRIMARY KEY GENERATED ALWAYS AS IDENTITY, 
    userId bigint not null, 
    name varchar(100) not null, 
    surname varchar(100) null,
    city varchar(100) null,
    genderId integer null,
    birthday date,
    biography text null,
    CONSTRAINT fk_user
      FOREIGN KEY(userId) 
	      REFERENCES users(userId),
    CONSTRAINT fk_gender
      FOREIGN KEY(genderId)
        REFERENCES genders(genderId)
);