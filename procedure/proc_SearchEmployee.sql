USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_SearchEmployee;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_SearchEmployee
    @Keyword NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        NV.MaNV, NV.HoTen, NV.SDT, NV.NgayVaoLam, NV.Luong, NV.DiaChi, 
        ISNULL(CN.TenChucNang, N'Chưa gán') AS TenChucNang 
    FROM NhanVien NV
    LEFT JOIN TaiKhoan TK ON NV.MaNV = TK.ID
    LEFT JOIN ChiTietChucNang CTCN ON TK.ID = CTCN.ID
    LEFT JOIN ChucNang CN ON CTCN.MaCN = CN.MaCN
    WHERE 
        NV.HoTen LIKE '%' + @Keyword + '%' OR
        NV.SDT LIKE '%' + @Keyword + '%'
    ORDER BY NV.MaNV;
END
GO