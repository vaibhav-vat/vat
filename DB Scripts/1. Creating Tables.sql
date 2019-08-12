create table USERS
(
Id int primary key identity(1,1),
UserName varchar(50),
Password varchar(50),
Name varchar(50),
Location varchar(50),
)


create table RESTAURANTS
(
Id int primary key identity(1,1),
Name varchar(50),
Location varchar(50), 
)


create table REVIEWS
(
Id int primary key identity(1,1),
RestaurantId int foreign key references RESTAURANTS(Id) ,
UserId int foreign key references USERS(Id), 
Rating int,
Comment varchar(100) 

)

select * from USERS
select * from RESTAURANTS 
select * from REVIEWS
