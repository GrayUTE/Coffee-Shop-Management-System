USE QuanLyQuanCafe

-- Xóa procedure cũ nếu đã tồn tại
DROP PROCEDURE IF EXISTS usp_PhanQuyenNguoiDung;
GO

CREATE PROCEDURE usp_PhanQuyenNguoiDung
    @UserID NVARCHAR(100),         -- ID trong bảng TaiKhoan
    @MaCN NVARCHAR(10)   -- Mã chức năng (NQL, NV, TN)
AS
BEGIN
if(@MaCN = 'NQL') 
BEGIN
EXEC sp_addrolemember 'NQL', @UserID
END

if(@MaCN = 'NV') 
BEGIN
EXEC sp_addrolemember 'NV', @UserID
END

if(@MaCN = 'TN') 
BEGIN
EXEC sp_addrolemember 'TN', @UserID
END
END










