
USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_UpdateCustomer;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_UpdateCustomer
    @MaKhachHang INT,
    @HoTen NVARCHAR(100),
    @SoDienThoai CHAR(11),
    @DiemTichLuy INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhachHang
    SET HoTen = @HoTen,
        SDT = @SoDienThoai,
        DiemTichLuy = @DiemTichLuy
    WHERE MaKH = @MaKhachHang;
END;