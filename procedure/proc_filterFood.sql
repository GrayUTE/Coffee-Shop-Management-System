USE [QuanLyQuanCafe]
GO
/****** Object:  StoredProcedure [dbo].[usp_filterFood]    Script Date: 9/30/2025 12:10:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_filterFood]
    @FilterType NVARCHAR(20), -- Kiểu lọc: "Tất cả", "Tên ", "Mã SP", "giá", "loại"
    @Value NVARCHAR(100) = NULL -- Giá trị lọc (tên, mã, đơn giá, hoặc loại)
AS
BEGIN
    IF @FilterType = 'Tất cả'
    BEGIN
        SELECT MaSP, TenSP, LoaiSP, DonGia
        FROM SanPham;
    END
    ELSE IF @FilterType = 'Tên'
    BEGIN
        SELECT MaSP, TenSP, LoaiSP, DonGia
        FROM SanPham
        WHERE TenSP LIKE '%' + @Value + '%';
    END
    ELSE IF @FilterType = 'Mã Sản phẩm'
    BEGIN
        IF ISNUMERIC(@Value) = 1
        BEGIN
            SELECT MaSP, TenSP, LoaiSP, DonGia
            FROM SanPham
            WHERE MaSP = CAST(@Value AS INT);
        END
    END
    ELSE IF @FilterType = 'Giá'
    BEGIN
        IF ISNUMERIC(@Value) = 1
        BEGIN
            SELECT MaSP, TenSP, LoaiSP, DonGia
            FROM SanPham
            WHERE DonGia = CAST(@Value AS INT);
        END
    END
    ELSE IF @FilterType = 'Loại'
    BEGIN
        SELECT MaSP, TenSP, LoaiSP, DonGia
        FROM SanPham
        WHERE LoaiSP = @Value;
    END
END;