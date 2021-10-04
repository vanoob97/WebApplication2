create database testdb;

create table testdb.regdynamics_user(
reg_year int,
reg_month int,
number_of_users int
);

insert testdb.regdynamics_user(reg_year, reg_month, number_of_users) 
values 
(2020, 8, 10), (2020, 9, 5), (2020, 10, 3), (2020, 11, 11), (2020, 12, 9), (2021, 1, 6), (2021, 2, 10), (2021, 3, 9), (2021, 4, 20), 
(2021, 5, 15), (2021, 6, 12), (2021, 7, 8), (2021, 8, 2), (2021, 9, 13), (2021, 10, 6), (2021, 11, 8), (2021, 12, 11);

create table testdb.regdynamics_device(
reg_year int,
reg_month int,
device_type varchar(20),
number_of_users int
);

insert testdb.regdynamics_device(reg_year, reg_month, device_type, number_of_users) 
values 
(2020, 8, "Laptop", 5), (2020, 8, "Mobile phone", 5), (2020, 9, "Mobile phone", 5), (2020, 10, "Tablet", 3), (2020, 11, "Laptop", 4), (2020, 11, "Mobile phone", 4), (2020, 11, "Tablet", 3), 
(2020, 12, "Mobile phone", 5), (2020, 12, "Tablet", 4), (2021, 1, "Laptop", 3), (2021, 1, "Tablet", 3), (2021, 2, "Laptop", 10), (2021, 3, "Laptop", 3), (2021, 3, "Mobile phone", 6),
(2021, 4, "Laptop", 10), (2021, 4, "Mobile phone", 5), (2021, 4, "Tablet", 5),  (2021, 5, "Mobile phone", 8), (2021, 5, "Tablet", 7), 
(2021, 6, "Laptop", 6), (2021, 6, "Tablet", 6), (2021, 7, "Mobile phone", 8), (2021, 8, "Tablet", 2), (2021, 9, "Mobile phone", 7), (2021, 9, "Tablet", 6), (2021, 10, "Laptop", 6), 
(2021, 11, "Mobile phone", 8), (2021, 12, "Laptop", 6), (2021, 12, "Tablet", 5);

create table testdb.concsessions_hour(
hour_ts datetime,
max_concsessions int
);

insert testdb.concsessions_hour(hour_ts, max_concsessions) 
values 
('2021-12-15 15:00:00', 5), ('2021-12-15 16:00:00', 8), ('2021-12-15 17:00:00', 3), ('2021-12-15 18:00:00', 11), ('2021-12-15 19:00:00', 15), ('2021-12-15 20:00:00', 4),
('2021-12-15 21:00:00', 20), ('2021-12-15 22:00:00', 2), ('2021-12-15 23:00:00', 5), ('2021-12-15 00:00:00', 10), ('2021-12-16 01:00:00', 9), ('2021-12-16 02:00:00', 15), 
('2021-12-16 03:00:00', 3), ('2021-12-16 04:00:00', 10), ('2021-12-16 05:00:00', 5), ('2021-12-16 06:00:00', 23), ('2021-12-16 07:00:00', 12), ('2021-12-16 08:00:00', 3), 
('2021-12-16 09:00:00', 9), ('2021-12-16 10:00:00', 5), ('2021-12-16 11:00:00', 11), ('2021-12-16 12:00:00', 8), ('2021-12-16 13:00:00', 18), ('2021-12-16 14:00:00', 13), 
('2021-12-16 15:00:00', 9), ('2021-12-16 16:00:00', 19), ('2021-12-16 17:00:00', 6), ('2021-12-16 18:00:00', 21), ('2021-12-16 19:00:00', 9), ('2021-12-16 20:00:00', 10), 
('2021-12-16 21:00:00', 5), ('2021-12-16 22:00:00', 3), ('2021-12-16 23:00:00', 11), ('2021-12-16 00:00:00', 6);

create table testdb.concsessions_mult_devices(
user_name varchar(20),
device_name varchar(30),
login_ts datetime
);

insert testdb.concsessions_mult_devices(user_name, device_name, login_ts) 
values 
("Bill Thompson", "Bill's Tablet", '2021-12-15 16:21:35'), ("Bill Thompson", "Bill's Laptop", '2021-12-15 16:30:11'),
("Sam Green", "Sam's Mobile phone", '2021-12-15 17:00:20'), ("Sam Green", "Sam's Laptop", '2021-12-15 17:05:43'), ("Sam Green", "Sam's Tablet", '2021-12-15 17:12:24'),
("Andrew Johnson", "Andrew's Mobile phone", '2021-12-16 03:21:10'), ("Andrew Johnson", "Andrew's Tablet", '2021-12-16 03:30:55'),
("Kirk Bloom", "Kirk's Laptop", '2021-12-16 10:05:03'), ("Kirk Bloom", "Kirk's Mobile phone", '2021-12-16 10:08:42'),
("Mary Stew", "Mary's Mobile phone", '2021-12-16 13:20:35'), ("Mary Stew", "Mary's Laptop", '2021-12-16 13:55:49'), ("Mary Stew", "Mary's Tablet", '2021-12-16 14:00:31');

create table testdb.total_sessions_hour(
date_ts date,
hour_ts int,
total_s_duration_minutes int,
total_s_duration_acc int
);

insert testdb.total_sessions_hour(date_ts, hour_ts, total_s_duration_minutes, total_s_duration_acc) 
values 
('2021-12-15', 15, 130, 698), ('2021-12-15', 16, 300, 300), ('2021-12-15', 17, 205, 1564), ('2021-12-15', 18, 420, 800), ('2021-12-15', 19, 550, 2587), ('2021-12-15', 20, 180, 600),
('2021-12-15', 21, 110, 10985), ('2021-12-15', 22, 203, 500), ('2021-12-15', 23, 435, 900), ('2021-12-15', 24, 510, 3045), ('2021-12-16', 0, 156, 300), ('2021-12-16', 1, 591, 1100), 
('2021-12-16', 2, 277, 5431), ('2021-12-16', 3, 314, 400), ('2021-12-16', 4, 549, 2000), ('2021-12-16', 5, 480, 6189), ('2021-12-16', 6, 105, 395), ('2021-12-16', 7, 298, 711), 
('2021-12-16', 8, 400, 952), ('2021-12-16', 9, 521, 3500), ('2021-12-16', 10, 309, 834), ('2021-12-16', 11, 555, 15203), ('2021-12-16', 12, 267, 1901), ('2021-12-16', 13, 481, 800), 
('2021-12-16', 14, 222, 500), ('2021-12-16', 15, 533, 9058), ('2021-12-16', 16, 111, 950), ('2021-12-16', 17, 446, 600), ('2021-12-16', 18, 505, 1200), ('2021-12-16', 19, 99, 4307), 
('2021-12-16', 20, 354, 400), ('2021-12-16', 21, 108, 550), ('2021-12-16', 22, 401, 6700), ('2021-12-16', 23, 500, 706);

create table testdb.login_user_countries(
user_name varchar(20),
country varchar(20),
login_ts datetime
);

insert testdb.login_user_countries(user_name, country, login_ts)
values
("Bill Thompson", "Poland", '2021-12-15 16:21:35'), ("Andrew Johnson", "Peru", '2021-12-16 03:21:10'), ("Mary Stew", "Sweden", '2021-12-16 13:20:35');