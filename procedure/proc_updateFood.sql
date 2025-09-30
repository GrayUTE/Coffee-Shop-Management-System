USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_updateFood;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Sửa đổi Stored Procedure cập nhật món
ALTER PROCEDURE usp_updateFood
    @MaSP INT,
    @TenSP NVARCHAR(MAX),
    @LoaiSP NVARCHAR(50),
    @DonGia FLOAT,
    @SoLuong INT -- THÊM: Tham số Số lượng mới
AS
BEGIN
    UPDATE SanPham
    SET 
        TenSP = @TenSP,
        LoaiSP = @LoaiSP,
        DonGia = @DonGia,
        SoLuong = @SoLuong -- THÊM: Cập nhật giá trị SoLuong
    WHERE MaSP = @MaSP;
END