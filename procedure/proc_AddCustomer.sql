USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_AddCustomer;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_AddCustomer
    @MaKhachHang INT,
    @HoTen NVARCHAR(100),
    @SoDienThoai CHAR(11),
    @DiemTichLuy INT,
    @ReturnValue INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO KhachHang (MaKH, HoTen, SDT, DiemTichLuy)
        VALUES (@MaKhachHang, @HoTen, @SoDienThoai, @DiemTichLuy);
        SET @ReturnValue = @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        SET @ReturnValue = 0;
    END CATCH
END;