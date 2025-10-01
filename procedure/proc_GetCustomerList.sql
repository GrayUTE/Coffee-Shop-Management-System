
USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_GetCustomerList;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Lấy danh sách khách hàng
CREATE PROCEDURE usp_GetCustomerList
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKH, HoTen, SDT, DiemTichLuy
    FROM KhachHang;
END;

