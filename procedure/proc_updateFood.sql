USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_updateFood;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_updateFood
    @MaSP INT,
    @TenSP NVARCHAR(100),
    @LoaiSP NVARCHAR(50),
    @DonGia Float
AS
BEGIN
    UPDATE SanPham
    SET TenSP = @TenSP, LoaiSP = @LoaiSP, DonGia = @DonGia
    WHERE MaSP = @MaSP;
END;