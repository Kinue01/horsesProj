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
	judge_fio varchar(70) not null,
	judge_town varchar(150) not null,
	judge_user_login varchar(50) not null,
	foreign key (judge_user_login) references tb_user (user_login)
);

create table tb_jockey
(
	jokey_id serial primary key,
	jokey_fio varchar(70) not null,
	jokey_birth timestamp not null,
	jokey_weight int not null,
	jokey_user_login varchar(50) not null,
	foreign key (jokey_user_login) references tb_user (user_login)
);

create table tb_restricment
(
	restricment_id serial primary key,
	restricment_gender varchar(50) not null,
	restricment_age_lower int not null,
	restricment_age_upper int not null,
	restricment_horse_birthplace varchar(50) not null
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
	restricment_id int not null,
	breed_id smallint not null,
	foreign key (restricment_id) references tb_restricment (restricment_id),
	foreign key (breed_id) references tb_horse_breed (breed_id)
);

create table tb_offence
(
	offence_id serial primary key,
	offence_name varchar(100) not null,
	offence_description text
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
	horse_birth_year int not null,
	horse_gender_id smallint not null,
	horse_breed_id smallint not null,
	horse_trainer_fio varchar(150) not null,
	horse_owner_id int not null,
	foreign key (horse_gender_id) references tb_horse_gender (gender_id),
	foreign key (horse_breed_id) references tb_horse_breed (breed_id),
	foreign key (horse_owner_id) references tb_jockey (jokey_id)
);

create table tb_competitor
(
	competitor_id serial primary key,
	competitor_jockey_id int not null,
	competitor_horse_id int not null,
	competitor_disqualification bool not null,
	competitor_row int,
	foreign key (competitor_jockey_id) references tb_jockey (jokey_id),
	foreign key (competitor_horse_id) references tb_horse (horse_id)
);

create table tb_competition
(
	compet_id serial primary key,
	compet_date timestamp not null,
	compet_name varchar(50) not null,
	compet_judge_id int not null,
	foreign key (compet_judge_id) references tb_judge (judge_id)
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
	ride_restricment int not null,
	ride_competition int not null,
	foreign key (ride_restricment) references tb_restricment (restricment_id),
	foreign key (ride_type_id) references tb_ride_type (type_id),
	foreign key (ride_competition) references tb_competition (compet_id)
);

create table tb_ride_competitors
(
	competitor_id int not null,
	ride_id int not null,
	jockey_color varchar(150) not null,
	horse_run_fail int,
	ride_result numeric(5, 1),
	primary key (competitor_id, ride_id),
	foreign key (competitor_id) references tb_competitor (competitor_id),
	foreign key (ride_id) references tb_ride (ride_id)
);

create table tb_competitor_offences
(
	offence_id int not null,
	competitor_id int not null,
	primary key (offence_id, competitor_id),
	foreign key (offence_id) references tb_offence (offence_id),
	foreign key (competitor_id) references tb_competitor (competitor_id)
);

insert into tb_role (role_name) values ('Жокей'), ('Судья');

insert into tb_user values ('jockey1', 'jockey1', 1), ('judge1', 'judge1', 2);

insert into tb_judge (judge_fio, judge_town, judge_user_login) values ('Зотова Ярослава Андреевна', 'Тюменская область, город Серпухов, бульвар Ленина, 91', 'judge1');

insert into tb_jockey (jokey_fio, jokey_birth, jokey_weight, jokey_user_login) values ('Елисеев Максим Иванович', '1999-06-16', 80, 'jockey1');

insert into tb_restricment (restricment_gender, restricment_age_lower, restricment_age_upper, restricment_horse_birthplace) values ('Кобыла', 3, 5, 'Место 1'), ('Жеребец', 2, 2, 'Место 2');

insert into tb_horse_breed_type (type_name) values ('Верховая'), ('Рысистая');

insert into tb_horse_breed (breed_name, breed_type_id) values ('Арабская чистокровная', 1), ('Ахалтекинская порода', 1), ('Орловская рысистая', 2), ('Русская рысистая', 2);

insert into tb_restricment_breeds values (1, 1), (1, 3), (2, 2), (2, 4);

insert into tb_offence (offence_name, offence_description) values 
('Сбой хода', 'Переход лошади с рыси на галоп, если при этом она сделала три скачка и более, расценивается как сбой'),
('Неправильный ход', 'Под неправильным ходом понимают выраженное нарушение двухтактного ритма или синхронного диагонального движения конечностей на
резвой рыси'),
('Галоп к столбу', 'Лошадь, сделавшая лишние сбои, проскачку, имевшая зафиксированный неправильный ход по дистанции либо прошедшая линию финиша галопом (галоп к столбу) или неправильным ходом');

insert into tb_horse_gender (gender_name) values ('Кобыла'), ('Жеребец');

insert into tb_horse (horse_name, horse_birth_year, horse_gender_id, horse_breed_id, horse_trainer_fio, horse_owner_id) values 
('Dineena', 2020, 1, 1, 'Плотников Марат Кириллович', 1),
('Zan', 2022, 2, 3, 'Сергеев Илья Артёмович', 1),
('Zander', 2024, 2, 2, 'Овчинникова Алиса Никитична', 1);

insert into tb_competition (compet_date, compet_name, compet_judge_id) values ('2020-05-15', 'Состязание 1', 1), ('2024-01-20', 'Состязание 2', 1);

insert into tb_ride_type (type_name) values ('Бега'), ('Скачки');

insert into tb_ride (ride_name, ride_type_id, ride_distance, ride_payment, ride_time, ride_num, ride_restricment, ride_competition) values
('Забег 1', 1, 1000, 50000, '11:00', 1, 1, 1), 
('Забег 2', 2, 1500, 40000, '16:00', 2, 1, 1),
('Забег 1', 1, 1200, 60000, '9:00', 1, 2, 2),
('Забег 2', 2, 2000, 80000, '15:00', 2, 2, 2);