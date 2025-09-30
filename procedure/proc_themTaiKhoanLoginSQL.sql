USE QuanLyQuanCafe
GO

DROP PROCEDURE IF EXISTS dbo.usp_themTaiKhoanLoginSQL;
GO 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.usp_themTaiKhoanLoginSQL
    @TenTaiKhoan NVARCHAR(100),
    @MatKhau CHAR(11)   
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Nếu login chưa có thì tạo mới
        IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @TenTaiKhoan)
        BEGIN
            DECLARE @SQLStringCreateLogin NVARCHAR(MAX);
            SET @SQLStringCreateLogin = 
                N'CREATE LOGIN [' + @TenTaiKhoan + N'] ' +
                N'WITH PASSWORD = N''' + @MatKhau + N''', ' +
                N'DEFAULT_DATABASE = [QuanLyQuanCafe], ' +
                N'DEFAULT_LANGUAGE = [us_english], ' +
                N'CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;';
            EXEC (@SQLStringCreateLogin);
        END
        ELSE
        BEGIN
            -- Nếu login đã có thì đổi mật khẩu
            DECLARE @SQLStringAlterLogin NVARCHAR(MAX);
            SET @SQLStringAlterLogin = 
                N'ALTER LOGIN [' + @TenTaiKhoan + N'] WITH PASSWORD = N''' + @MatKhau + N''';';
            EXEC (@SQLStringAlterLogin);
        END

        -- Nếu user chưa tồn tại trong database thì tạo
        IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @TenTaiKhoan)
        BEGIN
            DECLARE @SQLStringCreateUser NVARCHAR(MAX);
            SET @SQLStringCreateUser = 
                N'CREATE USER [' + @TenTaiKhoan + N'] FOR LOGIN [' + @TenTaiKhoan + N'];';
            EXEC (@SQLStringCreateUser);
        END
    END TRY
    BEGIN CATCH
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(N'Lỗi khi tạo hoặc cập nhật login: %s', 16, 1, @ErrMsg);
        RETURN;
    END CATCH
END
GO

