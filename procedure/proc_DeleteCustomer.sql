

USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_DeleteCustomer;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE usp_DeleteCustomer
    @MaKhachHang NVARCHAR(100),
    @ReturnValue INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM KhachHang WHERE MaKH = @MaKhachHang;
        SET @ReturnValue = @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        SET @ReturnValue = 0;
    END CATCH
END;