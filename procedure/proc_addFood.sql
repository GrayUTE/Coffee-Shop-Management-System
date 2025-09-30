USE [QuanLyQuanCafe]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_addFood]
    @TenSP NVARCHAR(100),
    @LoaiSP NVARCHAR(50),
    @DonGia Float
AS
BEGIN
    INSERT INTO SanPham (TenSP, LoaiSP, DonGia)
    VALUES (@TenSP, @LoaiSP, @DonGia);
END;

--Fix lại lỗi identity tăng

-- DBCC CHECKIDENT ('SanPham', RESEED, 5)
--DBCC CHECKIDENT ('SanPham', NORESEED)