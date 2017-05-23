﻿use master 

create database	Автозаправки
go 
use Автозаправки 

create table Топливо 
( 
код_топлива int not null constraint PK_Топливо primary key, 
название_топлива nchar(50), 
стоимость int not null
) 
insert into Топливо (код_топлива, название_топлива,стоимость) 
values (1,N'92',1.17); 
insert into Топливо (код_топлива, название_топлива,стоимость) 
values (2,N'95',1.25); 
insert into Топливо (код_топлива, название_топлива,стоимость) 
values (3,N'Дизельное',1.44); 

create table Товар 
( 
код_товара int not null constraint PK_Товары primary key, 
название_товара nchar(50), 
стоимость money,
количесвто int
) 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (1,N'Яблоки',4.5,150); 
insert into Товар(код_товара, название_товара, стоимость, количесвто)
values (2,N'Средства для мытья окон',3.17,20); 
insert into Товар(код_товара, название_товара, стоимость, количесвто)
values (3,N'Антифриз',2,24); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (4,N'Минералка',2.4,20); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (5,N'Чипсы Лейс',1,50); 
insert into Товар(код_товара, название_товара, стоимость, количесвто)
values (6,N'Чипсы Мира',1,50); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (7,N'Жвачка',0.5,100); 
insert into Товар(код_товара, название_товара, стоимость, количесвто)
values (8,N'Сигареты',5,10); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (9,N'Печенье',6,30); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (10,N'Мороженое',3,40); 
insert into Товар(код_товара, название_товара, стоимость, количесвто)
values (11,N'Батончик',1.5,45); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (12,N'Чупа-Чупс',0.3,100); 
insert into Товар(код_товара, название_товара, стоимость, количесвто) 
values (13,N'Журнал',1,60); 

create table Услуга 
( 
код_услуги int not null constraint PK_услуги primary key, 
название_услуги nchar(50), 
стоимость money 
) 
insert into Услуга(код_услуги, название_услуги, стоимость) 
values (1,N'Мытье окон',6); 
insert into Услуга(код_услуги, название_услуги, стоимость) 
values (2,N'Подкачка колес',7); 
insert into Услуга(код_услуги, название_услуги, стоимость) 
values (3,N'Мытье машины',9); 
insert into Услуга(код_услуги, название_услуги, стоимость) 
values (4,N'Туалет',0.5); 

create table Акции_на_товар 
( 
Код_акции_товар int not null constraint PK_Акциит primary key,
Вид_акции nchar(50) , 
Описание nchar(100), 
код_товара_на_акции int not null foreign key references Товар(код_товара), 
[Скидка%] nchar(50) 
) 
insert into Акции_на_товар(Код_акции_товар,Вид_акции,Описание, код_товара_на_акции, [Скидка%]) 
values (1,N'Акция на товар1',N'Акция здоровья.Выздоравливаем вместе!',1,30); 
insert into Акции_на_товар(Код_акции_товар,Вид_акции,Описание, код_товара_на_акции, [Скидка%]) 
values (2,N'Акция на товар2',N'Не замерзай!!',3,80); 
insert into Акции_на_товар(Код_акции_товар,Вид_акции,Описание, код_товара_на_акции, [Скидка%]) 
values (3,N'Акция на товар3',N'Просвещаемся и умнеем!',13,10); 

create table Акции_на_услугу 
( 
Код_акции_услуга int not null constraint PK_Акцииу primary key,
Вид_акции nchar(50), 
Описание nchar(100), 
код_услуги_на_акции int not null foreign key references Услуга(код_услуги), 
[Скидка%] nchar(50) 
) 
insert into Акции_на_услугу(Код_акции_услуга,Вид_акции,Описание, код_услуги_на_акции, [Скидка%]) 
values (1,N'Акция на услугу1',N'Сделай мир четче!',1,40); 
insert into Акции_на_услугу(Код_акции_услуга,Вид_акции,Описание, код_услуги_на_акции, [Скидка%]) 
values (2,N'Акция на услугу2',N'Заставь свою ласточку сверкать!',3,50); 

create table Постоянные_клиенты 
( 
Номер_карточки_клиента int not null constraint PK_ФИО_клиента primary key, 
ФИО_клиента nchar(50), 
Количество_посещений int, 
Средняя_потраченная_сумма money not null, 
Скидка_на_количество_посещений int, 
) 
insert into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (1,N'Орехова Виктория Павловна', 5, 500, 15 ); 
insert into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (2,N'Юбкин Виталий Георгевич', 4, 400, 10 ); 
insert
into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (3,N'Фомин Олег Валерьевич', 5, 500, 15 ); 
insert into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (4,N'Плохов Владислав Альбертович', 7, 700, 20 ); 
insert into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (5,N'Юркина Оксана Геннадьевна', 4, 400, 10); 
insert into Постоянные_клиенты(Номер_карточки_клиента, ФИО_клиента, Количество_посещений, Средняя_потраченная_сумма,Скидка_на_количество_посещений) 
values (6,N'Валькин Павел Викторович', 5, 500, 15 ); 

create table Чек 
( 
код_чека int not null constraint PK_код_чека primary key, 
дата date, 
код_топлива int null foreign key references Топливо(код_топлива),--как сделать так, чтобы было код_товара*количесвто*стоимость 
--код_товара int  null foreign key references Товар(код_товара), 
--код_услуги int null foreign key references Услуга(код_услуги), 
номер_карточки_клиента int null foreign key references Постоянные_клиенты(номер_карточки_клиента), 
) 
insert into Чек(код_чека, дата, код_топлива, --код_товара,код_услуги,
номер_карточки_клиента) 
values (1,'2017-12-10', 3, --3, NULL,
 1); 
insert into Чек(код_чека, дата, код_топлива, --код_товара,код_услуги,
номер_карточки_клиента) 
values (2,'2017-12-11', 1, --4, 4,
 2); 

create table ЧекТовар 
(
	Номер	   int not null constraint номерЧТ_РК primary key, 
	код_товара int not null constraint номерТ1_РК foreign key references Товар(код_товара),
	код_чека   int not null constraint номерЧ1_РК foreign key references Чек(код_чека)
)

create table ЧекУслуга 
(
	Номер	   int not null constraint номерЧУ_РК primary key, 
	код_услуги int not null constraint номерУ_РК foreign key references Услуга(код_услуги),
	код_чека   int not null constraint номерЧ2_РК foreign key references Чек(код_чека)
)

create table Автозаправка 
(  
Номер_автозаправки int constraint PK_Номер_автозаправки primary key,
Номер_телефона nchar(50), 
Описание nchar(500), 
количесвто_топлива int, 
количесвто_товаров int, 
) 

--Код, Код,,код_топлива,код_товара,код_услуги,количесвто_услуг,1,1,NULL,NULL,,код_чекаколичсвто_товаров,код_услуги,количесвто_услуг,код_чека) ,1,1,1); 
--Номер_карточки_клиента int foreign key references Постоянные_клиенты(Номер_карточки_клиента), 
--Акции_на_товар int constraint FK_Акции1 foreign key references Акции_на_товар (Код_акции_товар), 
--Акции_на_услугу int constraint FK_Акции2 foreign key references Акции_на_услугу (Код_акции_услуга), 
--код_чека int not null foreign key references Чек(код_чека), 
--код_топлива int foreign key references Топливо(код_топлива),--как сделать так, чтобы было код_товара*количесвто*стоимость 
--код_товара int foreign key references Товар(код_товара), 
--количесвто_услуг int, 
--Номер_карточки_клиента,Акции_на_товар,Акции_на_услугу, Номер_карточки_клиента,Акции_на_товар,Акции_на_услугу,
--1,1,NULL2,NULL,2,

insert into Автозаправка(Номер_автозаправки, Номер_телефона,Описание,количесвто_топлива,количесвто_товаров) 
values (1, 80298887766,N'Автозаправка в центре города.Гарантированная продажа качественных нефтепродуктов и всевозможных товаров и услуг для вас и вашей машины', 5,1); 
insert into Автозаправка(Номер_автозаправки, Номер_телефона,Описание,количесвто_топлива,количесвто_товаров)
values (2,80298887765,N'Автозаправка на выезде из города. Гарантированная продажа качественных нефтепродуктов и всевозможных товаров и услуг для вас и вашей машины',2, 6);

create table Общая 
(
Код int constraint PK_Код primary key,
Номер_автозаправки int not null constraint PK_Автозаправка foreign key references Автозаправка(Номер_автозаправки),
Адреса nchar(50), 
) 
insert into Общая(Код, Номер_автозаправки, Адреса) 
values (1,1,N'ул.Гагарина 26'); 
insert into Общая(Код, Номер_автозаправки, Адреса) 
values (2,2,N'ул.Космонавтов 54'); 
--insert into Общая(Номер_автозаправки, Адреса) 
--values (3,3,N'пр.Независимости 30'); 
--insert into Общая(Номер_автозаправки, Адреса) 
--values (4,4,N'ул, Бобруйская 80'); 
--insert into Общая(Номер_автозаправки, Адреса) 
--values (5,5,N'ул.Кижеватова 27'); 

create table Запись 
( 
Номер_записи int not null constraint номерЗ_РК primary key, 
Номер_автозаправки int not null constraint номерАЗ_РК foreign key references Автозаправка(Номер_автозаправки), 
Код_топлива int not null constraint номерТ2_РК foreign key references Топливо(Код_топлива)
) 
insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
values (1,1,1); 									
insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
values (2,1,2); 									
insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
values (3,1,3); 									
insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
values (4,2,1); 									
insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
values (5,2,3); 									
--insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
--values (6,3,1); 									
--insert into Запись(Номер_записи, Номер_автозаправки,Код_топлива) 
--values (7,3,2); 

create table Сервер 
( 
Код_записи int not null constraint PK_Код_записи primary key, 
дата date, 
Средняя_прибыль_за_месяц money not null, 
Средняя_прибыль_за_топливо money not null,  
Общая_прибыль_за_месяц_по_услугам_и_товарам money not null, 
Общий_объём_израсходованного_топлива int not null
)
