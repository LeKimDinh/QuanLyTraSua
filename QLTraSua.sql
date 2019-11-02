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

insert into GroupEmployee values('001', 'service');
insert into GroupEmployee values('002', 'preparation');
insert into GroupEmployee values('003', 'cashier');
insert into GroupEmployee values('004', 'protector');
insert into Employeer values('17110100', '001', 'A', 'Nguyen Van Ba', '0988806325');
insert into Employeer values('17110101', '001', 'A', 'Nguyen Thi Minh', '098802547');
insert into Employeer values('17110102', '002', 'A', 'Phan Minh Hai', '0984562147');
insert into Employeer values('17110103', '002', 'A', 'Nguyen Hai Nam', '0956148254');
insert into Employeer values('17110104', '003', 'A', 'Nguyen Thi Nhi', '0964156258');
insert into Employeer values('17110105', '001', 'B', 'Nguyen Van Son', '0988804759');
insert into Employeer values('17110106', '001', 'B', 'Nguyen Thi Anh', '0945148523');
insert into Employeer values('17110107', '002', 'B', 'Phan Minh Tu', '0984565412');
insert into Employeer values('17110108', '002', 'B', 'Nguyen Minh Thang', '0956144751');
insert into Employeer values('17110109', '003', 'B', 'Nguyen Thi Na', '0964421258');
insert into Employeer values('17110110', '001', 'C', 'Nguyen Quoc Anh', '0945206325');
insert into Employeer values('17110111', '001', 'C', 'Nguyen Thi Trang', '094512547');
insert into Employeer values('17110112', '002', 'C', 'Phan Minh Duong', '0981248147');
insert into Employeer values('17110113', '002', 'C', 'Nguyen Xuan Son', '0941848254');
insert into Employeer values('17110114', '003', 'C', 'Nguyen Thi Nguyet', '0942166258');
insert into Timekeeping values('17110100', '3000000', '2019-01-12 08:01:03')
insert into Timekeeping values('17110101', '3000000', '2019-01-10 10:02:04')
insert into Timekeeping values('17110102', '4000000', '2019-01-10 10:12:10')
insert into Timekeeping values('17110103', '4000000', '2019-01-10 10:18:17')
insert into Timekeeping values('17110104', '5000000', '2019-01-11 11:12:10')
insert into Timekeeping values('17110105', '3000000', '2019-01-11 10:15:14')
insert into Timekeeping values('17110106', '3000000', '2019-01-14 11:02:36')
insert into Timekeeping values('17110107', '4000000', '2019-01-13 12:12:10')
insert into Timekeeping values('17110108', '4000000', '2019-01-15 11:17:17')
insert into Timekeeping values('17110109', '5000000', '2019-01-11 10:10:10')
insert into Timekeeping values('17110110', '3000000', '2019-01-07 08:08:03')
insert into Timekeeping values('17110111', '3000000', '2019-01-10 11:04:04')
insert into Timekeeping values('17110112', '4000000', '2019-01-11 12:12:10')
insert into Timekeeping values('17110113', '4000000', '2019-01-13 14:15:17')
insert into Timekeeping values('17110114', '5000000', '2019-01-09 11:13:17')
insert into Account values('17110104', 'A', '1');
insert into Account values('17110109', 'B', '1');
insert into Account values('17110114', 'C', '1');
insert into Category values('C1', 'Milk Tea', '30% sugar');
insert into Category values('C1', 'Milk Tea', '50% sugar');
insert into Category values('C1', 'Milk Tea', '80% sugar');
insert into Category values('C2', 'Tea', '30% sugar');
insert into Category values('C2', 'Tea', '50% sugar');
insert into Category values('C2', 'Tea', '80% sugar');
insert into Category values('C3', 'cookies', '30% sugar');
insert into Category values('C3', 'cookies', '50% sugar');
insert into Category values('C3', 'cookies', '80% sugar');
insert into Category values('C4', 'Latte', '30% sugar');
insert into Category values('C4', 'Latte', '50% sugar');
insert into Category values('C4', 'Latte', '80% sugar');
insert into Dinks values('D1', 'C1', '30000');
insert into Dinks values('D2', 'C2', '30000');
insert into Dinks values('D3', 'C3', '40000');
insert into Dinks values('D4', 'C4', '40000');
insert into Area values('A','B1','tang tret');
insert into Area values('A','B2','tang tret');
insert into Area values('B','B8','lau 1');
insert into Area values('C','B15','lau 2');
insert into Bill values('17110104', 'B1', '01', '180000');
insert into Bill values('17110104', 'B2', '02', '200000');
insert into Bill values('17110109', 'B8', '03', '185000');
insert into Bill values('17110114', 'B15', '04', '160000');
insert into DetailsBill values('01', '6', 'Tra sua', '0', '180000');
insert into DetailsBill values('02', '7', 'Tra', '0', '200000');
insert into DetailsBill values('03', '6', 'Tra sua', '0', '185000');
insert into DetailsBill values('04', '4', 'Latte', '0', '160000');


