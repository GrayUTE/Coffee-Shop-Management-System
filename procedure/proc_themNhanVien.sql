USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_themNhanVien;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc usp_themNhanVien
@MaNV NVARCHAR(100),
@HoTen NVARCHAR(100),
@SDT CHAR(11),
@NgayVaoLam DATE,
@LUONG FLOAT,
@DiaChi NVARCHAR(200)
as
begin tran

if(@MaNV is null)
begin
	raiserror('Mã Nhan vien khong duoc bo trong!', 16, 1)
	rollback
	return
end

if(@HoTen is null)
begin
	raiserror('Ho ten Nhan vien khong duoc bo trong!', 16, 1)
	rollback
	return
end

if(@SDT is null)
begin
	raiserror('So dien thoai da bi trung. Vui long nhap lai', 16, 1)
	rollback
	return
end

if(@NgayVaoLam > GETDATE())
begin
	raiserror('Ngay vao lam phai be hon ngay hien tai! Vui long nhap lai.', 16, 1)
	rollback
	return
end

if(@LUONG <= 0)
begin
	raiserror('Luong cua nhan vien phai lon hon 0! Vui long nhap lai.', 16, 1)
	rollback
	return
end

insert into NhanVien (MaNV, HoTen, SDT, NgayVaoLam, Luong, DiaChi)
values (@MaNV, @HoTen, @SDT, @NgayVaoLam, @LUONG, @DiaChi);

exec sp_themTaiKhoanNV @MaNV, @SDT;

if (@@ERROR <> 0)
begin
	raiserror ('Error', 16, 1)
	rollback tran
	return 
end
commit tran


