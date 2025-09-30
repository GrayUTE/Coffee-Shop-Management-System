USE [QuanLyQuanCafe]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sửa đổi Stored Procedure thêm món
ALTER PROCEDURE usp_addFood
    @TenSP NVARCHAR(MAX),
    @LoaiSP NVARCHAR(50),
    @DonGia FLOAT,
    @SoLuong INT -- THÊM: Tham số Số lượng mới
AS
BEGIN
    INSERT INTO SanPham (TenSP, LoaiSP, DonGia, SoLuong) -- THÊM: Cột SoLuong
    VALUES (@TenSP, @LoaiSP, @DonGia, @SoLuong);       -- THÊM: Giá trị @SoLuong

    -- Trả về MaSP vừa được thêm
    SELECT SCOPE_IDENTITY();
END

--Fix lại lỗi identity tăng

-- DBCC CHECKIDENT ('SanPham', RESEED, 5)
--DBCC CHECKIDENT ('SanPham', NORESEED)