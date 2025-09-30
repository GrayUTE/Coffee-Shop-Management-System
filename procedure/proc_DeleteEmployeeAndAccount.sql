USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_DeleteEmployeeAndAccount;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_DeleteEmployeeAndAccount
    @MaNV NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RowsAffected INT = 0;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra MaNV tồn tại
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV)
        BEGIN
            RAISERROR (N'Không tìm thấy nhân viên với MaNV đã cho.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Xóa từ bảng ChiTietChucNang
        DELETE FROM ChiTietChucNang WHERE ID = @MaNV;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        -- Xóa từ bảng TaiKhoan
        DELETE FROM TaiKhoan WHERE ID = @MaNV;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        -- Xóa từ bảng NhanVien
        DELETE FROM NhanVien WHERE MaNV = @MaNV;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @RowsAffected;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        RETURN 0;
    END CATCH
END
GO