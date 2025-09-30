USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_AddEmployeeAndAccount;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_AddEmployeeAndAccount
    @MaNV NVARCHAR(100) OUTPUT,
    @HoTen NVARCHAR(100),
    @SDT CHAR(11),
    @NgayVaoLam DATE,
    @Luong FLOAT,
    @DiaChi NVARCHAR(200),
    @ChucNang NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RowsAffected INT = 0;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra đầu vào
        IF @HoTen IS NULL OR @HoTen = '' OR @SDT IS NULL OR @SDT = '' OR @ChucNang IS NULL OR @ChucNang = ''
        BEGIN
            RAISERROR (N'Họ tên, SĐT và Chức năng không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Kiểm tra SDT có trùng không
        IF EXISTS (SELECT 1 FROM NhanVien WHERE SDT = @SDT)
        BEGIN
            RAISERROR (N'SĐT đã được sử dụng.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Tạo MaNV mới nếu chưa có
        IF @MaNV IS NULL OR @MaNV = ''
        BEGIN
            DECLARE @MaxId NVARCHAR(100);
            SET @MaxId = (SELECT ISNULL(MAX(MaNV), 'NV0') FROM NhanVien);
            SET @MaNV = 'NV' + CAST(CAST(SUBSTRING(@MaxId, 3, LEN(@MaxId) - 2) AS INT) + 1 AS NVARCHAR);
        END

        -- Thêm vào bảng NhanVien
        INSERT INTO NhanVien (MaNV, HoTen, SDT, NgayVaoLam, Luong, DiaChi)
        VALUES (@MaNV, @HoTen, @SDT, @NgayVaoLam, @Luong, @DiaChi);
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        -- Thêm tài khoản vào bảng TaiKhoan
        INSERT INTO TaiKhoan (ID, MatKhau)
        VALUES (@MaNV, @SDT);
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        -- Đảm bảo chức năng tồn tại trong bảng ChucNang
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaCN = @ChucNang)
        BEGIN
            INSERT INTO ChucNang (MaCN, TenChucNang)
            VALUES (@ChucNang, @ChucNang);
            SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
        END

        -- Thêm vào bảng ChiTietChucNang
        INSERT INTO ChiTietChucNang (ID, MaCN)
        VALUES (@MaNV, @ChucNang);
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @RowsAffected;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        RETURN 0;
    END CATCH
END
GO