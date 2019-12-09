use master;
go
if DB_ID('QLTraSua') is not null
	drop database QLTraSua;
go
create database QLTraSua;
go
use QLTraSua;
go

IF EXISTS (SELECT * FROM sysobjects WHERE name = '[fk_DANGNHAP_NHOMNHANVIEN]')
BEGIN
  ALTER TABLE DANGNHAP
  DROP CONSTRAINT [fk_DANGNHAP_NHOMNHANVIEN]
END;
IF EXISTS (SELECT * FROM sysobjects WHERE name = '[fk_NHANVIEN_NHOMNHANVIEN]')
BEGIN
  ALTER TABLE NHANVIEN
  DROP CONSTRAINT [fk_NHANVIEN_NHOMNHANVIEN]
END;
go
use QLTraSua
go
IF OBJECT_ID('NHOMNHANVIEN') IS NOT NULL
begin
        drop table NHOMNHANVIEN
end

create table NHOMNHANVIEN (
MaNhom int,
TenNhom nvarchar(50) not null,
constraint pk_NHOMNHANVIEN	primary key (MaNhom)
);

IF OBJECT_ID('DANGNHAP') IS NOT NULL
begin
        drop table  DANGNHAP
end
create table DANGNHAP(
TenTaiKhoan varchar(10),
Matkhau varchar (50) not null,
MaNhom int not null,
CONSTRAINT PK_DANGNHAP PRIMARY KEY (TenTaiKhoan)
);

IF OBJECT_ID('NHANVIEN') IS NOT NULL
begin
        drop table NHANVIEN
end
create table  NHANVIEN(
MaNhanVien varchar(10),
TenNhanVien nvarchar(50) not null,
GioiTinh nvarchar(10) not null, 
NgaySinh date not null,
QueQuan nvarchar(50) not null,
Email varchar(50),
MaNhom int not null,
Luong int,
MaQuanLy varchar(10),
constraint pk_NHANVIEN primary key (MaNhanVien)
);
--
ALTER TABLE DANGNHAP  WITH CHECK ADD CONSTRAINT [fk_DANGNHAP_NHOMNHANVIEN] FOREIGN KEY(MaNhom)
REFERENCES NHOMNHANVIEN(MaNhom)
GO
ALTER TABLE DANGNHAP CHECK CONSTRAINT [fk_DANGNHAP_NHOMNHANVIEN]
GO
ALTER TABLE NHANVIEN  WITH CHECK ADD CONSTRAINT [fk_NHANVIEN_NHOMNHANVIEN] FOREIGN KEY(MaNhom)
REFERENCES NHOMNHANVIEN(MaNhom)
GO
ALTER TABLE NHANVIEN CHECK CONSTRAINT [fk_NHANVIEN_NHOMNHANVIEN]
GO
--
Drop table if EXISTS Category;
Create table Category(
			CategoryID		nvarchar(10) not null,
			NameCategory	nvarchar(50) not null,			
			constraint PK_Category primary key CLUSTERED (CategoryID asc),
			Constraint Category_UQ	Unique (NameCategory)
			);
go
Drop table if EXISTS Drink;
create table Drink(
			DrinkID			int identity(1,1) not null,
			NameDrink       nvarchar(80) not null,
			CategoryID		nvarchar(10),
			Cost			int not null,
			Images			varbinary(Max),
			Description		nvarchar(200),
			constraint PK_Drink primary key CLUSTERED (DrinkID asc),
			constraint Drink_UQ UniQue (NameDrink)
			);
go
Alter table Drink with check Add constraint [FK_Drink_Category] foreign key (CategoryID) 
References ql.Category(CategoryID) on delete set null;
go
Drop table if EXISTS DrinkArchive;
go
create table DrinkArchive(
			DrinkID			int  not null,
			NameDrink       nvarchar(80) not null,
			CategoryID		nvarchar(10) not null,
			Cost			int not null,
			Images			varbinary(Max) not null,
			Description		nvarchar(200) not null
			);
go
Drop table if EXISTS Customer;
create table Customer(
            CustomerID int identity(1,1) not null,
			NameCustomer nvarchar(20) not null,
			BirthDay date,
			PhoneNumber  nvarchar(10) not null,
			Email		nvarchar(50),
			City		nvarchar(50),
			District	nvarchar(50),
			constraint PK_Customer primary key (CustomerID),
			constraint Customer_UQ UniQue (PhoneNumber)
			);
go
Drop table if EXISTS Bill;
Create table Bill(
			ID			int identity(1,1),
			BillID		int,
			StaffID		varchar(10),
			NameStaff	nvarchar(30),
			NameDrink	nvarchar(80),
			Numbers		int,
			NameCustomer nvarchar(50),
			PhoneCustomer	nvarchar(10),
			DateBuy		date,
			Money	float not null,
			constraint PK_Bill primary key CLUSTERED (ID asc)
			);
go
Alter table Bill add constraint [FK_Bill_Customer] foreign key (PhoneCustomer) 
References Customer(PhoneNumber) on delete set null
go
Alter table Bill with check Add constraint [FK_Bill_Drink] foreign key (NameDrink) 
References Drink(NameDrink) on delete set null
go
Alter table Bill with check Add constraint [FK_Bill_NHANVIEN] foreign key (StaffID) 
References NHANVIEN(MaNhanVien) on delete set null
go

Drop table if EXISTS Discount;
create table Discount(
			CustomerID int,
			MemberPoints int,
			PhoneNumber nvarchar(10),
			Level		nvarchar(10),
			constraint  PK_Discount primary key CLUSTERED (PhoneNumber)
			);
go
Alter table Discount with check add constraint [FK_Discount_Customer] foreign key (CustomerID) 
references Customer(CustomerID);
go
use QLTraSua;
go
delete from Bill;
delete from Drink;
delete from Category;
delete from Discount;
delete from Customer;
delete from DrinkArchive;
go
select * from NHANVIEN;
select * from NHOMNHANVIEN;
delete NHOMNHANVIEN;
delete NHANVIEN;
select * from DANGNHAP;
go
insert NHOMNHANVIEN(MaNhom, TenNhom) values('1', N'Quản Lý')
insert NHOMNHANVIEN(MaNhom, TenNhom) values('2', N'Nhân Viên')
insert NHANVIEN(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, QueQuan, Email, MaNhom, Luong, MaQuanLy) values ('0001',N'Nguyễn Quang Hải','Nam','1999-03-07',N'Hà Nội','Nguyenquanghai@student.hcmute.edu.vn','1', '4000000', 'admin')
insert NHANVIEN(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, QueQuan, Email, MaNhom, Luong, MaQuanLy) values ('0002',N'Bùi Tiến Dũng','Nam','1999-08-10',N'Hà Nội','Buitiendung@student.hcmute.edu.vn','2','5000000','')
insert NHANVIEN(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, QueQuan, Email, MaNhom, Luong, MaQuanLy) values ('0003',N'Nguyễn Tiến Linh','Nam','1999-10-12',N'Vũng Tàu','Nguyentienlinhi@student.hcmute.edu.vn','2','4000000','')

insert  Category values
('C1', N'Trà xanh HoJiTa'),
('C2', N'COMBO'),
('C3', N'Trà không sữa'),
('C4', N'Sữa tươi nguyên chất'),
('C5', N'Các loại Topping'),
('C6', N'Xiên que'),
('C7', N'Thức ăn'),
('C8', N'COMBO tiết kiệm')
;
go
Insert Drink values
(N'Trà nướng HoJiTa Premium','C1','42000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\1.PNG',SINGLE_BLOB)as Images),N'Trà xanh nướng thuần Việt không ướp hương, vị thơm đặc trưng, đậm đà. Nướng theo kỹ thuật Hojicha Nhật Bản'),
( N'Trà sữa nướng HoJiTa Premium','C1','48000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\2.PNG',SINGLE_BLOB)as Images),N'Trà sữa trà xanh nướng thơm béo ngọt nhẹ, đậm đà vị trà nguyên chất thuần Việt.'),
(N'Trà sữa nướng HoJiTa phô mai Premium', 'C1','60000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\3.PNG',SINGLE_BLOB)as Images),N'Trà sữa nướng thuần Việt không ướp hương kết hợp cùng lớp kem phô mai vị béo thơm, ngọt dịu'),
( N'Trà nướng HoJiTa Jelly trà nướng', 'C1', '49000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\4.PNG',SINGLE_BLOB)as Images),N'Trà xanh nướng thuần Việt không ướp hương, kết hợp với jelly mùi trà nướng đặc trưng độc đáo chỉ có tại HC.'),
( N'HC - COMBO1 Trà Sữa H&C, Sốt Socola, TC Socola, P.Socola', 'C2', '37000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\5.PNG',SINGLE_BLOB)as Images),N'Combo trà sữa truyền thống thêm sốt Socola chảy quanh thành ly và 2 loại topping vị socola'),
( N'HC - COMBO2 Trà Sữa Hot&Cold, TC Mật Ong, P.Trứng', 'C2', '40000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\6.PNG',SINGLE_BLOB)as Images),N'Combo trà sữa truyền thống kết hợp với trân châu và pudding trứng'),
(N'HC - COMBO3 Trà Sữa H&C, TC Khoai Môn Sợi, TC Củ Năng', 'C2', '42000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\8.PNG',SINGLE_BLOB)as Images),N'Combo trà sữa truyền thống kết hợp trân châu khoai môn sợi dai dẽo làm từ 100% khoai môn nghiền và củ năng giòn áo bột lá dứa.'),
(N'HC - COMBO4 Trà Sữa H&C, TC Trắng, Jelly Trà Nướng', 'C2', '42000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\7.PNG',SINGLE_BLOB)as Images),N'Combo trà sữa kết hợp cùng trân châu ninh nhừ tron đường đen thơm lừng và jelly vị trà rang đặc trưng chỉ có tại HC'),
(N'Hồng trà Dâu xay hạt đác', 'C3', '35000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\9.PNG',SINGLE_BLOB)as Images),N'Hồng trà thanh mát kết hợp cùng nho dẻo ngọt thơm, kèm thêm vải nguyên trái thơm giòn'),
(N'Hồng trà Nho xay trai dẻo', 'C3', '35000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\10.PNG',SINGLE_BLOB)as Images),N'Hồng trà thanh mát kết hợp cùng vải xay ngọt thơm, kèm thêm vải nguyên trái thơm giòn'),
(N'Lục trà Nho xay trai dẻo', 'C3', '35000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\11.PNG',SINGLE_BLOB)as Images),N'Lục trà thanh mát kết hợp cùng nho dẻo ngọt thơm, kèm thêm vải nguyên trái thơm giòn'),
(N'Lục Trà Vải xay trái vải', 'C3', '35000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\12.PNG',SINGLE_BLOB)as Images),N'Lục trà thanh mát kết hợp cùng vải xay ngọt thơm, kèm thêm vải nguyên trái thơm giòn '),
(N'ST Phô Mai TC Ninh Đường Đen', 'C4', '67000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\13.PNG',SINGLE_BLOB)as Images),N'Sữa tươi nguyên chất kết hợp cùng đường organic, trân châu dai dai, ngọt thanh.
Sản phẩm dạng đá xay không gây ngán, mang đến trải nghiệm khác biệt'),
(N'ST Phô Mai Matcha TC Ninh Đường Đen', 'C4', '74000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\14.PNG',SINGLE_BLOB)as Images),N'Sữa tươi nguyên chất kết hợp đường organic, trân châu dai dai, ngọt thanh.
Sản phẩm dạng đá xay không gây ngán, vị matcha mang đến trải nghiệm khác biệt.'),
(N'ST Phô Mai Socola TC Ninh Đường Đen', 'C4', '74000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\15.PNG',SINGLE_BLOB)as Images),N'Sữa tươi nguyên chất kết hợp cùng đường đen organic, trân châu dai dai, vị ngọt thanh.
Sản phẩm dạng đá xay không gây ngán, vị socola mang đến trải nghiệm khác biệt.'),
(N'HC Sữa Tươi Socola Volcano', 'C4', '48000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\16.PNG',SINGLE_BLOB)as Images),N'Sản phẩm độc đáo, là sự kết hợp giữa sữa tươi, sữa đặc, sốt Sô và bột Volcano.
Vị thơm, ngọt, béo, giòn tan.'),
(N'Sốt Đường Đen', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\23.PNG',SINGLE_BLOB)as Images),N''),
(N'Sốt Cafe', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\24.PNG',SINGLE_BLOB)as Images),N''),
(N'Sốt Socola', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\25.PNG',SINGLE_BLOB)as Images),N''),
(N'M.Phô Mai', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\26.PNG',SINGLE_BLOB)as Images),N''),
(N'Zb.Nho Mỹ Đen', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\27.PNG',SINGLE_BLOB)as Images),N''),
(N'Zb.Đào Tươi', 'C5', '10000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\28.PNG',SINGLE_BLOB)as Images),N''),
(N'Gà Xiên Que', 'C6', '17000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\17.PNG',SINGLE_BLOB)as Images),N''),
(N'Xúc Xích Đức', 'C6', '17000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\18.PNG',SINGLE_BLOB)as Images),N''),
(N'Viên Mực', 'C6', '17000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\19.PNG',SINGLE_BLOB)as Images),N''),
(N'Khoai Tây Xoắn Phomai', 'C6', '19000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\20.PNG',SINGLE_BLOB)as Images),N''),
(N'Khoai Tây Sợi Lắc Phomai', 'C6', '29000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\21.PNG',SINGLE_BLOB)as Images),N''),
(N'Khoai Tây Chiên Lắc Phomai', 'C6', '29000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\22.PNG',SINGLE_BLOB)as Images),N''),
(N'Cơm Chiên Tứ Sắc', 'C7', '27000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\29.PNG',SINGLE_BLOB)as Images),N''),
(N'Mì Spaghetti Bò Bằm', 'C7', '49000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\30.PNG',SINGLE_BLOB)as Images),N''),
(N'Bắp Xào Tôm Bơ', 'C7', '21000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\31.PNG',SINGLE_BLOB)as Images),N''),
(N'Mì Trộn Phô Mai Xúc Xích', 'C7','23000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\32.PNG',SINGLE_BLOB)as Images),N''),
(N'Mì Trộn Phô Mai', 'C7', '27000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\33.PNG',SINGLE_BLOB)as Images),N''),
(N'Combo Xiên Que 1', 'C8', '34000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\34.PNG',SINGLE_BLOB)as Images),N''),
(N'Combo Xiên Que 2', 'C8', '35000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\35.PNG',SINGLE_BLOB)as Images),N''),
(N'Combo Xiên Que 3', 'C8', '42000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\36.PNG',SINGLE_BLOB)as Images),N''),
(N'Cơm Chiên Tứ Sắc Gà Xiên', 'C8', '34000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\37.PNG',SINGLE_BLOB)as Images),N''),
(N'Cơm Chiên Tứ Sắc Xúc Xích Đức', 'C8', '34000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\38.PNG',SINGLE_BLOB)as Images),N''),
(N'Mì Trộn Phô Mai Cá Viên', 'C8', '34000',(select*from Openrowset(Bulk N'D:\Học Kỳ 1 Năm 3\HQTCSDL\Do_An\39.PNG',SINGLE_BLOB)as Images),N'');
go

--Index Drink
use QLTraSua;
go
Drop index Drink.IX_Drink;
go
CREATE NONCLUSTERED INDEX IX_Drink on Drink (CategoryID asc)
go
--Index Customer
Drop index Customer.IX_Customer;
go
Create Unique INDEX IX_Customer on Customer(PhoneNumber asc)
go
select * from Customer where PhoneNumber=N'0337006601'
--Index Discount
Drop index Discount.IX_Discount;
go
Create nonclustered INDEX IX_Discount on Discount(CustomerID asc)
go
select * from Discount where PhoneNumber=N'0337006601'

select * from Bill;

--Schema
use master;
go
--Xóa tên đăng nhập
if exists (
	select name
	from master.sys.server_principals
	where name = 'ql')
begin
	drop login ql;
end
go

--Tạo đăng nhập mới
if not exists (
	select name
	from master.sys.server_principals
	where name = 'ql')
begin 
	create login ql
		with password = '123';
end
go
--kiểm tra
select * 
from master.sys.server_principals
where name = 'ql';
go

use QLTraSua;
go
--Tạo người dùng
if USER_ID ('ql') is null
	begin 
		CREATE USER ql FOR LOGIN ql;
		alter role [db_owner] add member [ql];
	end
go
--xóa schema tên là ql nếu tồn tại
drop schema if exists ql;
go
--tạo chema tên là ql với người dùng ql là chủ sở hữu
create schema ql authorization ql;
go
--kiểm tra
select * from sys.schemas
where name = 'ql';
go

--Chỉ dinh ql là default_schema
alter user ql
	with default_schema = ql;
go
--Kiem tra
select name, default_schema_name
from sys.database_principals
where name = 'ql';
go
--Chuyển bảng customer từ schema dbo sang schema ql

alter schema ql transfer dbo.DANGNHAP;
go
alter schema ql transfer dbo.PHANQUYEN;
go
select * from ql.Category




