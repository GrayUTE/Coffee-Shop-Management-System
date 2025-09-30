USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS usp_UpdateEmployee;
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE usp_UpdateEmployee
    @MaNV NVARCHAR(100),
    @HoTen NVARCHAR(100),
    @SDT CHAR(11),
    @NgayVaoLam DATE,
    @Luong FLOAT,
    @DiaChi NVARCHAR(200),
    @ChucNang NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra đầu vào
        IF @HoTen IS NULL OR @HoTen = '' OR @SDT IS NULL OR @SDT = '' OR @ChucNang IS NULL OR @ChucNang = ''
        BEGIN
            RAISERROR (N'Họ tên, SĐT và Chức năng không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Kiểm tra MaNV tồn tại
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV)
        BEGIN
            RAISERROR (N'Không tìm thấy nhân viên với MaNV đã cho.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Kiểm tra SDT có trùng với nhân viên khác không
        IF EXISTS (SELECT 1 FROM NhanVien WHERE SDT = @SDT AND MaNV != @MaNV)
        BEGIN
            RAISERROR (N'SĐT đã được sử dụng bởi nhân viên khác.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 0;
        END

        -- Cập nhật bảng NhanVien
        UPDATE NhanVien
        SET 
            HoTen = @HoTen,
            SDT = @SDT,
            NgayVaoLam = @NgayVaoLam,
            Luong = @Luong,
            DiaChi = @DiaChi
        WHERE MaNV = @MaNV;

        -- Cập nhật mật khẩu trong bảng TaiKhoan
        UPDATE TaiKhoan
        SET MatKhau = @SDT
        WHERE ID = @MaNV;

        -- Đảm bảo chức năng tồn tại trong bảng ChucNang
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaCN = @ChucNang)
        BEGIN
            INSERT INTO ChucNang (MaCN, TenChucNang)
            VALUES (@ChucNang, @ChucNang);
        END

        -- Gán lại chức năng cho nhân viên
        DELETE FROM ChiTietChucNang WHERE ID = @MaNV;

        INSERT INTO ChiTietChucNang (ID, MaCN)
        VALUES (@MaNV, @ChucNang);

        COMMIT TRANSACTION;
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        RETURN 0;
    END CATCH
END
GO