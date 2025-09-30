USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_getFoodList;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Sửa đổi Stored Procedure lấy danh sách
ALTER PROCEDURE usp_getFoodList
AS
BEGIN
    SELECT 
        MaSP, 
        TenSP, 
        LoaiSP, 
        DonGia, 
        ISNULL(SoLuong, 1) as SoLuong -- THÊM: Lấy cột SoLuong (dùng ISNULL để tránh lỗi nếu dữ liệu cũ chưa có)
    FROM SanPham
END