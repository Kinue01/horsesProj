create table tb_role
(
	role_id smallserial primary key,
	role_name varchar(25) not null
);

create table tb_user
(
	user_login varchar(50) primary key,
	user_password text not null,
	user_role_id smallint not null,
	foreign key (user_role_id) references tb_role (role_id)
);

create table tb_judge
(
	judge_id serial primary key,
	user_fio varchar(50) not null,
	user_town varchar(50) not null,
	judge_user_login varchar(50) not null,
	foreign key (judge_user_login) references tb_user (user_login)
);

create table tb_jokey
(
	jokey_id serial primary key,
	jokey_fio varchar(50) not null,
	jokey_birth timestamp not null,
	jokey_weight int not null,
	jokey_user_login varchar(50) not null,
	foreign key (jokey_user_login) references tb_user (user_login)
);

create table tb_restricment_type
(
	type_id serial primary key,
	type_gender varchar(50) not null,
	type_age_lower int not null,
	type_age_upper int not null,
	type_horse_birthplace varchar(50) not null
);

create table tb_horse_breed_type
(
	type_id smallserial primary key,
	type_name varchar(50) not null
);

create table tb_horse_breed
(
	breed_id smallserial primary key,
	breed_name varchar(50) not null,
	breed_type_id smallint not null,
	foreign key (breed_type_id) references tb_horse_breed_type (type_id)
);

create table tb_restricment_breeds
(
	type_id int not null,
	breed_id smallint not null,
	foreign key (type_id) references tb_restricment_type (type_id),
	foreign key (breed_id) references tb_horse_breed (breed_id)
);

create table tb_horse_gender
(
	gender_id smallserial primary key,
	gender_name varchar(50) not null
);

create table tb_horse
(
	horse_id serial primary key,
	horse_name varchar(50) not null,
	horse_year date not null,
	horse_gender_id smallint not null,
	horse_breed_id smallint not null,
	horse_trainer_fio varchar(150) not null,
	horse_owner_fio varchar(150) not null,
	horse_speed numeric(5, 1),
	horse_run_fail int not null,
	foreign key (horse_gender_id) references tb_horse_gender (gender_id),
	foreign key (horse_breed_id) references tb_horse_breed (breed_id)
);

create table tb_competition
(
	compet_id serial primary key,
	compet_date timestamp not null,
	compet_name varchar(50) not null
);

create table tb_ride_type
(
	type_id smallserial primary key,
	type_name varchar(50) not null
);

create table tb_ride
(
	ride_id serial primary key,
	ride_name varchar(50) not null,
	ride_type_id smallint not null,
	ride_distance int not null,
	ride_payment int not null,
	ride_time time not null,
	ride_num int not null,
	ride_restricment_type int not null,
	foreign key (ride_restricment_type) references tb_restricment_type (type_id),
	foreign key (ride_type_id) references tb_ride_type (type_id)
);

create table tb_ride_competitors
(
	ride_id int not null,
	jokey_id int not null,
	horse_id int not null,
	jokey_color varchar(50) not null,
	horse_row smallint not null,
	foreign key (ride_id) references tb_ride (ride_id),
	foreign key (jokey_id) references tb_jokey (jokey_id),
	foreign key (horse_id) references tb_horse (horse_id)
);

create table tb_competition_rides
(
	compet_id int not null,
	ride_id int not null,
	foreign key (compet_id) references tb_competition (compet_id),
	foreign key (ride_id) references tb_ride (ride_id)
);