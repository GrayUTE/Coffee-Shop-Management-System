
USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_SearchCustomer;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Tìm kiếm khách hàng
CREATE PROCEDURE usp_SearchCustomer
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKH, HoTen, SDT, DiemTichLuy
    FROM KhachHang
    WHERE HoTen LIKE '%' + @Keyword + '%'
       OR SDT LIKE '%' + @Keyword + '%'
       OR MaKH LIKE '%' + @Keyword + '%';
END;