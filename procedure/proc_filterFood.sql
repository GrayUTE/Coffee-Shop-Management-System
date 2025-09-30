USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_filterFood;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_filterFood
    @FilterType NVARCHAR(20) -- Kiểu lọc: "Tất cả", "Đồ ăn", "Đồ uống"
AS
BEGIN
    SET NOCOUNT ON; -- Tắt thông báo số dòng bị ảnh hưởng để tối ưu

    BEGIN TRY
        IF @FilterType = 'Tất cả'
        BEGIN
            SELECT MaSP, TenSP, LoaiSP, DonGia
            FROM SanPham;
        END
        ELSE IF @FilterType = 'Đồ ăn'
        BEGIN
            SELECT MaSP, TenSP, LoaiSP, DonGia
            FROM SanPham
            WHERE LoaiSP = 'Đồ ăn';
        END
        ELSE IF @FilterType = 'Đồ uống'
        BEGIN
            SELECT MaSP, TenSP, LoaiSP, DonGia
            FROM SanPham
            WHERE LoaiSP = 'Đồ uống';
        END
        ELSE
        BEGIN
            RAISERROR ('Kiểu lọc không hợp lệ. Chỉ chấp nhận "Tất cả", "Đồ ăn" hoặc "Đồ uống".', 16, 1);
            RETURN;
        END
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO