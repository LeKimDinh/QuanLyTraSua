use master;
go
if DB_ID('QLTraSua') is not null
	drop database QLTraSua;
go
create database QLTraSua;
go
use QLTraSua;
go


create table GroupStaff(

			GroupID		int not null,
			NameGroup	nvarchar(20) not null,
			primary key (GroupID)
			);
create table Staff(
			StaffID		int not null,
			GroupID			int not null,
			FullName	nvarchar(50) not null,
			Dateofbirth date not null,
			NumberPhone		int check (NumberPhone<11) not null,		
			primary key (StaffID),
			foreign key (GroupID) references GroupStaff on delete set null
			);
create table Timekeeping(
			StaffID		int not null,
			Salary			money not null,
			SoCa			time not null,
			primary key (StaffID),
			);
Create table Account(
			StaffID		int not null,
			UserE			nvarchar(50) not null,
			PassE			nvarchar(50) not null,
			primary key (StaffID)
			);
Create table Category(
			CategoryID		nvarchar(20) not null,
			NameCategory	nvarchar(20) not null,
			primary key (CategoryID)
			);
create table Drink(
			DrinkID			int not null,
			NameDrink       int not null,
			CategoryID		nvarchar(20) not null,
			Cost			money not null,
			primary key(DrinkID),
			foreign key (CategoryID) references Category on delete set null
			);
Create table Bill(
			StaffID		int not null,
			BillID			int not null,
			TotalMoney		money not null,
			primary key (BillID),

			foreign key(StaffID) references Staff on delete set null,
			);
create table Customer(
            CustomerID int not null,
			NameCustomer nvarchar(20) not null,
			DateCreated date not null,
			PhoneNumber int not null,
			primary key (CustomerID));
create table Discount(
			MemberPoints int not null,
			PhoneNumber int not null,
			foreign key(PhoneNumber) references Customer on delete set null);
go


>>>>>>> 50ffd92838bded689b8cc67e272ba25d376caafc
delete from Bill;
delete from Drink;
delete from Category;
delete from Account;
delete from Timekeeping;
delete from Staff;
delete from Account;
delete from GroupStaff;
go

insert into GroupStaff values('001', 'service');
insert into GroupStaff values('002', 'preparation');
insert into GroupStaff values('003', 'cashier');
insert into GroupStaff values('004', 'protector');
insert into Staff values('17110100', '001', 'A', 'Nguyen Van Ba', '0988806325');
insert into Staff values('17110101', '001', 'A', 'Nguyen Thi Minh', '098802547');
insert into Staff values('17110102', '002', 'A', 'Phan Minh Hai', '0984562147');
insert into Staff values('17110103', '002', 'A', 'Nguyen Hai Nam', '0956148254');
insert into Staff values('17110104', '003', 'A', 'Nguyen Thi Nhi', '0964156258');
insert into Staff values('17110105', '001', 'B', 'Nguyen Van Son', '0988804759');
insert into Staff values('17110106', '001', 'B', 'Nguyen Thi Anh', '0945148523');
insert into Staff values('17110107', '002', 'B', 'Phan Minh Tu', '0984565412');
insert into Staff values('17110108', '002', 'B', 'Nguyen Minh Thang', '0956144751');
insert into Staff values('17110109', '003', 'B', 'Nguyen Thi Na', '0964421258');
insert into Staff values('17110110', '001', 'C', 'Nguyen Quoc Anh', '0945206325');
insert into Staff values('17110111', '001', 'C', 'Nguyen Thi Trang', '094512547');
insert into Staff values('17110112', '002', 'C', 'Phan Minh Duong', '0981248147');
insert into Staff values('17110113', '002', 'C', 'Nguyen Xuan Son', '0941848254');
insert into Staff values('17110114', '003', 'C', 'Nguyen Thi Nguyet', '0942166258');
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
insert into Category values('C1', 'Trà xanh nướng HoJiTa');
insert into Category values('C2', 'COMBO');
insert into Category values('C3', 'Trà không sữa');
insert into Category values('C4', 'Sữa tươi nguyên chất');
insert into Category values('C5', 'Các loại Topping');
insert into Category values('C6', 'Xiên que');
insert into Category values('C7', 'Thức ăn');
insert into Category values('C8', 'COMBO tiết kiệm');
insert into Drink values('D1','Trà nướng HoJiTa Premium','C1','42000');
insert into Drink values('D1', 'Trà sữa nướng HoJiTa Premium','C1','48000');
insert into Drink values('D1','Trà sữa nướng HoJiTa phô mai Premium', 'C1','60000');
insert into Drink values('D1', 'Trà nướng HoJiTa Jelly trà nướng', 'C1', '49000');
insert into Drink values('D2', 'HC - COMBO1 Trà Sữa H&C, Sốt Socola, TC Socola, P.Socola', 'C2', '37000');
insert into Drink values('D2', 'HC - COMBO2 Trà Sữa Hot&Cold, TC Mật Ong, P.Trứng', 'C2', '40000');
insert into Drink values('D2', 'HC - COMBO3 Trà Sữa H&C, TC Khoai Môn Sợi, TC Củ Năng', 'C2', '42000');
insert into Drink values('D2', 'HC - COMBO4 Trà Sữa H&C, TC Trắng, Jelly Trà Nướng', 'C2', '42000');
insert into Drink values('D3', 'Hồng trà dâu xay hạt đác', 'C3', '35000');
insert into Drink values('D3', 'Hồng trà nho xay trai dẻo', 'C3', '35000');
insert into Drink values('D3', 'Lục trà nho xay trai dẻo', 'C3', '35000');
insert into Drink values('D3', 'Lục Trà Vải Xay Trái Vải', 'C3', '35000');
insert into Drink values('D4', ' ST Phô Mai TC Ninh Đường Đen', 'C4', '67000');
insert into Drink values('D4', ' ST Phô Mai Matcha TC Ninh Đường Đen', 'C4', '74000');
insert into Drink values('D4', ' ST Phô Mai Socola TC Ninh Đường Đen', 'C4', '74000');
insert into Drink values('D4', ' HC Sữa Tươi Socola Volcano', 'C4', '48000');
insert into Drink values('D5', 'Sốt Đường Đen', 'C5', '10000');
insert into Drink values('D5', 'Sốt Cafe', 'C5', '10000');
insert into Drink values('D5', 'Sốt Socola', 'C5', '10000');
insert into Drink values('D5', 'M.Phô Mai', 'C5', '10000');
insert into Drink values('D5', 'Zb.Nho Mỹ Đen', 'C5', '10000');
insert into Drink values('D5', 'Zb.Đào Tươi', 'C5', '10000');
insert into Drink values('D6', 'Gà Xiên Que', 'C6', '17000');
insert into Drink values('D6', 'Xúc Xích Đức', 'C6', '17000');
insert into Drink values('D6', 'Viên Mực', 'C6', '17000');
insert into Drink values('D6', 'Khoai Tây Xoắn Phomai', 'C6', '19000');
insert into Drink values('D6', 'Khoai Tây Sợi Lắc Phomai', 'C6', '29000');
insert into Drink values('D6', 'Khoai Tây Chiên Lắc Phomai', 'C6', '29000');
insert into Drink values('D7', 'Cơm Chiên Tứ Sắc', 'C7', '27000');
insert into Drink values('D7', 'Mì Spaghetti Bò Bằm', 'C7', '49000');
insert into Drink values('D7', 'Bắp Xào Tôm Bơ', 'C7', '21000');
insert into Drink values('D7', 'Mì Trộn Phô Mai Xúc Xích', 'C7', '39000');
insert into Drink values('D7', 'Mì Trộn Phô Mai', 'C7', '27000');
insert into Drink values('D8', 'Combo Xiên Que 1', 'C8', '34000');
insert into Drink values('D8', 'Combo Xiên Que 2', 'C8', '35000');
insert into Drink values('D8', 'Combo Xiên Que 3', 'C8', '42000');
insert into Drink values('D8', 'Cơm Chiên Tứ Sắc Gà Xiên', 'C8', '34000');
insert into Drink values('D8', 'Cơm Chiên Tứ Sắc Xúc Xích Đức', 'C8', '34000');
insert into Drink values('D8', 'Mì Trộn Phô Mai Cá Viên', 'C8', '34000');
insert into Bill values('17110104', 'B1', '01', '180000');
insert into Bill values('17110104', 'B2', '02', '200000');
insert into Bill values('17110109', 'B8', '03', '185000');
insert into Bill values('17110114', 'B15', '04', '160000');




