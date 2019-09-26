use master;
go

if DB_ID('QLTraSua') is not null
	drop database QLTraSua;
go

create database QLTraSua;
go

use QLTraSua;
go


create table GroupEmployee(
			GroupID		int,
			NameGroup	nvarchar(20),
			primary key (GroupID)
			);
create table Employeer(
			EmployeerID		int,
			GroupID			int,
			AreaID			nvarchar(15),
			FullName	nvarchar(50),
			NumberPhone		int check (NumberPhone<11),		
			primary key (EmployeerID),
			foreign key (GroupID) references GroupEmployee on delete set null
			);
create table Timekeeping(
			EmployeerID		int,
			Salary			money,
			SoCa			time,
			primary key (EmployeerID),
			);
Create table Account(
			EmployeerID		int,
			UserE			nvarchar(50),
			PassE			nvarchar(50),
			primary key (EmployeerID)
			);
Create table Category(
			CategoryID		nvarchar(20),
			NameCategory	nvarchar(20),
			Recipe			nvarchar(20),
			primary key (CategoryID)
			);
create table Dinks(
			DrinkID			int,
			CategoryID		nvarchar(20),
			Cost			money,
			primary key(DrinkID),
			foreign key (CategoryID) references Category on delete set null
			);
Create table TableD(
			TableID			int,
			DrinkID			int,
			NumberCustomer	int,
			Unit			int,
			DrinkName		nvarchar(20),
			primary key (TableID),
			foreign key (DrinkID) references Dinks on delete set null
			);
Create table Area(
			AreaID			nvarchar(15),
			TableID			int,
			NameArea		nvarchar(50),
			primary key (AreaID),
			foreign key (TableID) references TableD on delete set null
			);
Create table Bill(
			EmployeerID		int,
			TableID			int,
			BillID			int,
			TotalMoney		money,
			primary key (BillID),
			foreign key(EmployeerID) references Employeer on delete set null,
			foreign key(TableID	) references TableD	on delete set null		
			);
Create table DetailsBill(
			BillID			int,
			Number			int,
			DinksName		nvarchar(20),
			Coupons			int,
			TotalMoney		money,
			primary key (BillID),
			foreign key(BillID) references Bill on delete set null,
			);
go
delete from DetailsBill;
delete from Bill;
delete from Area;
delete from TableD;
delete from Dinks;
delete from Category;
delete from Account;
delete from Timekeeping;
delete from Employeer;
delete from Account;
delete from GroupEmployee;
go







