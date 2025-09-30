USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_themTaiKhoanNV;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc usp_themTaiKhoanNV
@ID NVARCHAR(100),
@MatKhau CHAR(11)
as
insert into TaiKhoan values(@ID, @MatKhau)
exec usp_themTaiKhoanLoginSQL @ID, @MatKhau;


