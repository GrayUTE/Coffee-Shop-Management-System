USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_searchFood;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_searchFood
    @Keyword NVARCHAR(100)
AS
BEGIN
    -- Loại bỏ khoảng trắng ở đầu và cuối (TRIM)
    SET @Keyword = TRIM(@Keyword);
    
    -- Khai báo biến
    DECLARE @IsNumeric BIT = 0;
    
    -- KIỂM TRA TỪ KHÓA CÓ PHẢI LÀ SỐ HAY KHÔNG
    IF ISNUMERIC(@Keyword) = 1
    BEGIN -- BẮT ĐẦU khối lệnh IF
        SET @IsNumeric = 1;
    END   -- KẾT THÚC khối lệnh IF

    -- Thực hiện truy vấn tìm kiếm
    SELECT 
        MaSP, 
        TenSP, 
        LoaiSP, 
        DonGia
    FROM 
        SanPham
    WHERE 
        -- 1. Tìm kiếm theo Tên SP (luôn tìm kiếm gần đúng)
        TenSP LIKE N'%' + @Keyword + N'%'
        
        -- 2. Tìm kiếm theo Mã SP (nếu từ khóa là số)
        -- Chuyển MaSP thành NVARCHAR để so sánh với từ khóa, đảm bảo không lỗi kiểu dữ liệu
        OR (@IsNumeric = 1 AND CAST(MaSP AS NVARCHAR) = @Keyword)
        
        -- 3. Tìm kiếm theo Đơn Giá (nếu từ khóa là số)
        -- Chuyển DonGia thành NVARCHAR để so sánh với từ khóa
        OR (@IsNumeric = 1 AND CAST(DonGia AS NVARCHAR) = @Keyword);
END -- Lỗi Msg 102 đã được khắc phục sau khi sửa khối lệnh
GO