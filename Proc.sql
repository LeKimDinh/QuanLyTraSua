use QLTraSua;
go
--Drink
--Insert or Edit
if object_id('sp_Insert_Edit_Drink') is not null
	Drop proc sp_Insert_Edit_Drink;
go
Create proc sp_Insert_Edit_Drink
	@DrinkID int,
	@NameDrink	nvarchar(80),
	@CategoryID	nvarchar(10),
	@Cost	int,
	@Image image,
	@Description  nvarchar(200)
as
begin
	if(@DrinkID = 0)
		insert into Drink (NameDrink,CategoryID,Cost,Images,Description)
		values(@NameDrink,@CategoryID,@Cost,@Image,@Description);
	else 
		update Drink set NameDrink=@NameDrink,CategoryID=@CategoryID,Cost=@Cost
		,Images=@Image,Description=@Description where DrinkID=@DrinkID;
end
go
--Load data
Use QLTraSua;
go
if OBJECT_ID('Drink_New_View') is not null
	Drop view Drink_New_View;
go
Create View Drink_New_View
as
select * 
from Drink
where CategoryID !='C1'and CategoryID !='C2'and CategoryID !='C3'and CategoryID !='C4'and CategoryID !='C5'and 
CategoryID !='C6'and CategoryID !='C7'
go
if object_id ('sp_Load_Drink') is not null
	Drop proc sp_Load_Drink;
go
Create proc sp_Load_Drink
		@Catagory nvarchar(10)
as
begin
	if(@Catagory !='')
		select * from Drink where CategoryID = @Catagory;
	else
		select * from Drink_New_View;
end
go
--Delete
if OBJECT_ID('sp_Delete_Drink') is not null
	Drop proc sp_Delete_Drink;
go
Create proc sp_Delete_Drink
	@DrinkID int
as 
begin Delete from Drink where DrinkID=@DrinkID;
end;
go
use QLTraSua;
go
if object_id('Drink_Delete') is not null
	Drop Trigger Drink_Delete;
go
create trigger Drink_Delete
	On Drink
	After Delete
as
Insert Into DrinkArchive
(DrinkID,NameDrink,CategoryID,Cost,Images,Description) select DrinkID,NameDrink,CategoryID,Cost,Images,Description from Deleted;
go
--Restore Drink
if OBJECT_ID('sp_Restore_Drink') is not null
	Drop proc sp_Restore_Drink;
go
go
Create proc sp_Restore_Drink
as
begin try
begin tran
	insert into Drink(DrinkID,NameDrink,CategoryID,Cost,Images,Description) 
	select * from DrinkArchive where DrinkID=(select MAX(DrinkID)from DrinkArchive);
	delete DrinkArchive where DrinkID = (select MAX(DrinkID)from DrinkArchive);
	commit tran;
end try
begin catch
	rollback tran;
end catch
go
delete DrinkArchive;
select * from DrinkArchive;
select * from Drink;
set identity_insert Drink on
exec sp_Restore_Drink;
set identity_insert Drink off
go

--Customer
--Load data theo SDT
use QLTraSua;
go
if OBJECT_ID('Customer_DisCount_View') is not null
	Drop view Customer_DisCount_View;
go
Create view Customer_DisCount_View
as
	select NameCustomer,Customer.PhoneNumber,Email,City,District,BirthDay,MemberPoints,Discount.Level from Customer,Discount where Customer.CustomerID
	= Discount.CustomerID;
go
if object_id('fn_Customer_DisCount') is not null
	Drop function fn_Customer_DisCount;
go
Create function fn_Customer_DisCount
	(@SDT nvarchar(10))
	returns Table 
return
	select * from Customer_DisCount_view where PhoneNumber=@SDT;
go
--select * from fn_Customer_DisCount(N'@SDT');
--exec sp_Check_Customer N'0337006601';
--select * from Customer;
--select * from Discount;
--insert Discount values(2,500,N'0337006601',N'Cấp 3');
--
--Insert or Edit Customer
if OBJECT_ID('sp_Insert_Edit_Customer') is not null
	Drop proc sp_Insert_Edit_Customer;
go
Create proc sp_Insert_Edit_Customer
	@NameCustomer	nvarchar(20),
	@BirthDay		date,
	@PhoneNumber	nvarchar(20),
	@Email			nvarchar(50),
	@City			nvarchar(50),
	@District		nvarchar(50),
	@ID int
as
if @NameCustomer='' or @NameCustomer is null THROW 50001, 'Tên Khách Hàng Không Được Bỏ Trống!!!', 1;
if @PhoneNumber='' or @PhoneNumber is null THROW 50001, 'Số Điện Thoại Không Được Bỏ Trống!!!', 1;
if(@ID = 0)
	begin
		begin try
			begin tran;
				insert into Customer(NameCustomer,BirthDay,PhoneNumber,Email,City,District)
				values(@NameCustomer,@BirthDay,@PhoneNumber,@Email,@City,@District);
				insert Discount (CustomerID,MemberPoints,PhoneNumber,Level) 
				values (@@IDENTITY,0,@PhoneNumber,N'Cấp 1');
				commit tran;
		end try
		begin catch
				rollback tran;
				DECLARE @ErrorMessage NVARCHAR(2000)
				SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
				RAISERROR(@ErrorMessage, 16, 1)
		end catch;
	end;
else 
	begin
		begin try
			begin tran	
				update Customer set NameCustomer=@NameCustomer,BirthDay=@BirthDay,
				PhoneNumber=@PhoneNumber,Email=@Email,City=@City,District=@District where CustomerID=@ID
				update Discount set PhoneNumber=@PhoneNumber where CustomerID=@ID;
				commit tran;
		end try
		begin catch
			rollback tran;
		end catch
	end;
go
--Lấy CustomerID
use QLTraSua;
go
if OBJECT_ID('fn_Select_CustomerID') is not null
	Drop function fn_Select_CustomerID;
go
create function fn_Select_CustomerID
		(@PhoneNumber nvarchar(10))
		returns int
begin
declare @CustomerID int
	select @CustomerID = (select CustomerID from Customer where PhoneNumber = @PhoneNumber) 
return 
	@CustomerID;
end
go
--select dbo.fn_Select_CustomerID(N'0337006601') as CustomerID;
--select * from Customer;
go

--Discount
Use QLTraSua;
go
if OBJECT_ID('sp_Load_Discount') is not null
	Drop proc sp_Load_Discount;
go
Create proc sp_Load_Discount 
as
select Discount.PhoneNumber,NameCustomer,MemberPoints,Level from Discount join Customer on Discount.PhoneNumber = Customer.PhoneNumber;
go
--Lấy thông tin mã giảm giá cho Customer
if OBJECT_ID('sp_Select_Discount') is not null
	Drop proc sp_Select_Discount;
go
Create proc sp_Select_Discount
		@PhoneNumber nvarchar(10) = '%'
as
select Discount.PhoneNumber,NameCustomer,MemberPoints,Level from Discount join Customer on Discount.PhoneNumber=Customer.PhoneNumber where Discount.PhoneNumber like @PhoneNumber
go
--Lấy gái trị giảm giá
if OBJECT_ID('fn_Select_Discount') is not null
	Drop function fn_Select_Discount;
go
Create function fn_Select_Discount
		(@PhoneNumber nvarchar(10))
		returns int
begin
declare @MemberPoints int
	select @MemberPoints = (select MemberPoints from Discount where PhoneNumber = @PhoneNumber); 
	if @MemberPoints >= 0 and @MemberPoints < 100
		return 0;
	else if @MemberPoints >= 100 and @MemberPoints < 500
		return 5;
	else if @MemberPoints >= 500 and @MemberPoints < 1500
		return 8;
	else if @MemberPoints >= 1500 
		return 10;
	return @MemberPoints;
end
go
select dbo.fn_Select_Discount(N'0337006601')as MemberDiscount;
go
if OBJECT_ID('sp_Edit_Discount') is not null
	Drop proc sp_Edit_Discount;
go
Create proc sp_Edit_Discount
		@MemberPoints	int,
		@PhoneNumber	nvarchar(10)
as
if @PhoneNumber!='' or @PhoneNumber is not null
	begin
		if @MemberPoints >= 100 and @MemberPoints < 500
		begin
			Update Discount set MemberPoints=@MemberPoints,Level=N'Cấp 2' where PhoneNumber=@PhoneNumber;
		end
		else if @MemberPoints >= 500 and @MemberPoints < 1500
		begin
			Update Discount set MemberPoints=@MemberPoints,Level=N'Cấp 3' where PhoneNumber=@PhoneNumber;
		end
		else if @MemberPoints >= 1500 
		begin
			Update Discount set MemberPoints=@MemberPoints,Level=N'Cấp 4' where PhoneNumber=@PhoneNumber;
		end
		else Update Discount set MemberPoints=@MemberPoints,Level=N'Cấp 1' where PhoneNumber=@PhoneNumber;
	end;
go

--Bill
use QLTraSua;
go
if OBJECT_ID('sp_Load_Bill') is not null
	Drop proc sp_Load_Bill;
go
Create proc sp_Load_Bill
as
		Select BillID,DateBuy,NameStaff,NameCustomer,NameDrink,Numbers,Money from Bill 
go

--Insert bill
if OBJECT_ID('sp_Insert_Bill')is not null
	Drop proc sp_Insert_Bill;
go
alter table Bill nocheck constraint FK_Bill_Customer;
go
Create proc sp_Insert_Bill
	@BillID		int,
	@StaffID	nvarchar(10),
	@NameStaff	nvarchar(30),
	@NameDrink	nvarchar(80),
	@Numbers		int,
	@NameCustomer nvarchar(50),
	@PhoneCustomer	nvarchar(10) null,
	@DateBuy		date,
	@Money	int
as
if @NameStaff='' or @NameStaff is null Throw 5001,'Tên nhân viên bán không được bỏ trống!!!',1;
	Insert into Bill (BillID,StaffID,NameStaff,NameDrink,Numbers,NameCustomer,PhoneCustomer,DateBuy,Money) values(@BillID,@StaffID,@NameStaff,@NameDrink,@Numbers,@NameCustomer,@PhoneCustomer,@DateBuy,@Money)
go
--Lấy ngày bán gần đây nhất
if OBJECT_ID('sp_Select_DateBuy') is not null
	Drop proc sp_Select_DateBuy;
go
Create proc sp_Select_DateBuy
as
select DateBuy from Bill where ID=(select MAX(ID) from Bill)
go
--
if OBJECT_ID('fn_Select_BillID') is not null
	Drop function fn_Select_BillID
go
Create function fn_Select_BillID
		(@DateBuy date)
		returns int
begin
declare @BillID int
	select @BillID = (select BillID from Bill where ID = (select MAX(ID) from Bill where DateBuy=@DateBuy))
return @BillID
end;
go
select dbo.fn_Select_BillID(N'2019-12-9')as
BillID;
go
--
if OBJECT_ID('sp_Select_Bill') is not null
	Drop proc sp_Select_Bill;
go
Create proc sp_Select_Bill
	@Date date
as
Select BillID,DateBuy,NameStaff,NameCustomer,NameDrink,Numbers,Money from Bill where DateBuy=@Date; 
select Max(BillID) as TongBill ,SUM(Numbers) as TongSoluong,SUM(Money) as TongTien from Bill where DateBuy=@Date;
go
if OBJECT_ID('sp_Delete_Bill') is not null
	Drop proc sp_Delete_Bill;
go
Create proc sp_Delete_Bill
	@Date date
as
	delete Bill where DateBuy=@Date;
go
select * from Bill;
go
--Category
use QLTraSua;
go
if OBJECT_ID('sp_Load_Category') is not null
	Drop proc sp_Load_Category;
go
Create proc sp_Load_Category
as
select * from ql.Category;
go

if OBJECT_ID('sp_Insert_Category') is not null
	Drop proc sp_Insert_Category;
go
Create proc sp_Insert_Category
	@Ma nvarchar(10),
	@Ten nvarchar(50)
as
Insert into ql.Category(CategoryID,NameCategory) values (@Ma,@Ten);
go

---------------------------------------------------------
if OBJECT_ID('LayMaQuanLy') is not null
	drop proc LayMaQuanLy;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayMaQuanLy
	@MaQL varchar(10)
as
begin
	select NHANVIEN.MaQuanLy from NHANVIEN where MaQuanLy = @MaQL
end
go
exec LayMaQuanLy N'admin';
go
if OBJECT_ID('LayMaNhanVien') is not null
	drop proc LayMaNhanVien;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayMaNhanVien
	@MaNV varchar(10)
as
begin
	select NHANVIEN.MaNhanVien from NHANVIEN where MaNhanVien=@MaNV
end
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
use QLTraSua;
go
if OBJECT_ID('LayTenNhanVien') is not null
	drop proc LayTenNhanVien;
go
create proc LayTenNhanVien
	@MaNV varchar(10)
as
begin
	select NHANVIEN.TenNhanVien from NHANVIEN where MaNhanVien=@MaNV
end
go
exec LayTenNhanVien '0001';
go
if OBJECT_ID('LayTenDangNhap') is not null
	drop proc LayTenDangNhap;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayTenDangNhap
	@TenDangNhap varchar(10)
as
begin
	select DANGNHAP.TenTaiKhoan from DANGNHAP where TenTaiKhoan = @TenDangNhap
end
go
if OBJECT_ID('ThemTaiKhoan') is not null
	drop proc ThemTaiKhoan;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc ThemTaiKhoan
	@TenDangNhap varchar(10),
	@MatKhau  varchar(50),
	@MaNhom int
as
begin
		
		Insert into DANGNHAP (TenTaiKhoan,Matkhau,MaNhom) values (@TenDangNhap, @MatKhau,@MaNhom);
end
go
if OBJECT_ID('LayMatKhau') is not null
	drop proc LayMatKhau
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayMatKhau
	@TenDangNhap varchar(10)
as
begin
		
		Select MatKhau from DANGNHAP where TenTaiKhoan =@TenDangNhap
end
go
if OBJECT_ID('CapNhatMatKhau') is not null
	drop proc CapNhatMatKhau;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc CapNhatMatKhau
	@MatKhauMoi  varchar(50),
		@TenDangNhap varchar(10),
	@MatKhauCu varchar(50)
as
begin
	update DANGNHAP set MatKhau=@MatKhauMoi
	where TenTaiKhoan=@TenDangNhap and MatKhau=@MatKhauCu
end
go
if OBJECT_ID('LayUser') is not null
	drop proc LayUser;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayUser
		@TenDangNhap varchar(10),
	@MatKhau varchar(50)
as
begin
	Select * from DANGNHAP where TenTaiKhoan=@TenDangNhap and MatKhau =@MatKhau
end
go
if OBJECT_ID('LayMaNhom') is not null
	drop proc LayMaNhom;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayMaNhom
		@TenDangNhap varchar(10),
	@MatKhau varchar(50)
as
begin
	Select MaNhom from DANGNHAP where TenTaiKhoan=@TenDangNhap and MatKhau =@MatKhau
end
go
if OBJECT_ID('LayNhanVien') is not null
	drop proc LayNhanVien;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc LayNhanVien
as
begin
	Select * from NHANVIEN
end
go

if OBJECT_ID('ThemNhanVien') is not null
	drop proc ThemNhanVien;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc ThemNhanVien
@MaNhanVien varchar(10),
@TenNhanVien nvarchar(50),
@GioiTinh nvarchar(10), 
@NgaySinh date ,
@QueQuan nvarchar(50) ,
@Email varchar(50),
@MaNhom int,
@Luong int,
@MaQuanLy varchar(10)
as
begin
IF	EXISTS (SELECT * FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien)
	THROW 50001, N'Mã nhân viên Này Đã Tồn Tại!', 1;
IF	@TenNhanVien is null or @TenNhanVien = ''
	THROW 50001, N'Tên nhân viên Không Được Phép Để Trống!', 1;
	Insert NHANVIEN values (@MaNhanVien,@TenNhanVien,@GioiTinh,@NgaySinh,@QueQuan,@Email,@MaNhom,@Luong,@MaQuanLy)
end
go

if OBJECT_ID('CapNhatNhanVien ') is not null
	drop proc CapNhatNhanVien ;
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC CapNhatNhanVien
		@MaNhanVien varchar(10),
		@TenNhanVien nvarchar(50),
		@GioiTinh nvarchar(10), 
		@NgaySinh date ,
		@QueQuan nvarchar(50) ,
		@Email varchar(50),
		@MaNhom int,
		@Luong int,
		@MaQuanLy varchar(10)
AS
--Kiểm Soát Lỗi
IF	NOT EXISTS (SELECT * FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien)
	THROW 50001,N'Nhân viên Này Không Tồn Tại',1;
IF	@TenNhanVien IS NULL OR @TenNhanVien= ''
	THROW 50001, N'Tên nhân viên Không Được Phép Để Trống!', 1;
IF	@NgaySinh IS NULL OR @NgaySinh > GETDATE()
	THROW 50001, N'Ngày Sinh không Được Lớn Hơn Ngày Hiện Tại!', 1;
	BEGIN
		UPDATE	 NHANVIEN
		SET		MaNhanVien =@MaNhanVien,
					TenNhanVien =@TenNhanVien,
					GioiTinh = @GioiTinh,
					NgaySinh = @NgaySinh,
					QueQuan=@QueQuan,
					Email = @Email,
					MaNhom=@MaNhom,
					Luong=@Luong,
					MaQuanLy=@MaQuanLy
		WHERE	MaNhanVien =@MaNhanVien
		IF	 EXISTS (SELECT * FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien)
	THROW 50001, 'Cập nhật thành công!', 1;
	END
GO

if OBJECT_ID('XoaNhanVien ') is not null
	drop proc XoaNhanVien ;
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc XoaNhanVien
	@MaNhanVien varchar(10)
as
begin
	delete NHANVIEN
	where MaNhanVien = @MaNhanVien
end
GO
select * from NHANVIEN;
go

USE QLTraSua;
go
 IF OBJECT_ID(N'GetSortedDiscount') IS NOT NULL DROP PROC GetSortedDiscount;
 GO
 CREATE PROC GetSortedDiscount
 @colname AS sysname =N'Level', @sortdir AS CHAR(1) = 'A'
 AS
 select Discount.PhoneNumber,NameCustomer,MemberPoints,Level 
from Discount join Customer on Discount.PhoneNumber=Customer.PhoneNumber 
 ORDER BY
 CASE WHEN @colname = N'PhoneNumber' AND @sortdir = 'A'
 THEN Discount.PhoneNumber END,
 CASE WHEN @colname = N'NameCustomer' AND @sortdir = 'A'
 THEN NameCustomer END,
 CASE WHEN @colname = N'MemberPoints' AND @sortdir = 'A'
 THEN MemberPoints END,
  CASE WHEN @colname = N'Level' AND @sortdir = 'A'
 THEN Level END,
 CASE WHEN @colname = N'PhoneNumber' AND @sortdir = 'D'
 THEN Discount.PhoneNumber END DESC,
 CASE WHEN @colname = N'NameCustomer' AND @sortdir = 'D'
 THEN NameCustomer END DESC,
 CASE WHEN @colname = N'MemberPoints' AND @sortdir = 'D'
 THEN MemberPoints END DESC,
 CASE WHEN @colname = N'MemberPoints' AND @sortdir = 'D'
 THEN Level END DESC
 OPTION (RECOMPILE);
 GO
 EXEC GetSortedDiscount N'PhoneNumber', N'D';
 GO