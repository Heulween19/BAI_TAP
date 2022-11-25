USE [Db_User ]
GO

CREATE TABLE DB_USER 
(
Id  int primary key identity(1,1),
UserName  Nvarchar(150) Not null,
Password  Nvarchar(250) not null,
BirthDay  DateTime ,
Address  Nvarchar(250) ,
Email  Nvarchar(250) ,
Age  Int ,
Gender  bit 
)



select * from dbo.DB_USER