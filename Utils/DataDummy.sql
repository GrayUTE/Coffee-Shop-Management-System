-- ================= NHÂN VIÊN =================
INSERT INTO NhanVien (MaNV, HoTen, SDT, NgayVaoLam, Luong, DiaChi) VALUES
('NV1',N'Nguyễn Văn An', '0901111111', '2021-01-10', 8000000, N'Từ Liêm, Hà Nội'),
('NV2', N'Lê Thị Bé',     '0902222222', '2022-05-20', 6500000, N'Hải Phòng'),
('NV3', N'Trần Văn Cung', '0903333333', '2023-02-15', 7000000, N'Nam Định');

-- ================= NGUYÊN LIỆU =================
INSERT INTO NguyenLieu (TenNL, TonKho, DonViTinh) VALUES
(N'Cà phê hạt', 100, N'Kg'),
(N'Sữa tươi',   50,  N'Hộp'),
(N'Đường trắng',200, N'Kg'),
(N'Trà xanh',   80,  N'Gói'),
(N'Siro dâu',   30,  N'Chai');

-- ================= NHÀ CUNG CẤP =================
INSERT INTO NhaCungCap (TenNCC, SDT, DiaChi) VALUES
(N'Công ty Cafe Trung Nguyên', '0911111111', N'Buôn Ma Thuột'),
(N'Vinamilk',                   '0922222222', N'HCM'),
(N'Đường Biên Hòa',             '0933333333', N'Đồng Nai'),
(N'Công ty Trà Thái Nguyên',    '0944444444', N'Thái Nguyên'),
(N'Siro Monin',                 '0955555555', N'Pháp');

-- ================= PHIẾU NHẬP =================
INSERT INTO PhieuNhap (MaNV, MaNCC) VALUES
('NV1', 1),
('NV2', 2),
('NV3', 3);

-- ================= CHI TIẾT PHIẾU NHẬP =================
INSERT INTO ChiTietPN (SoLuong, DonGia, MaPN, MaNL) VALUES
(10, 150000, 1, 1),
(20, 20000,  1, 2),
(15, 18000,  2, 3),
(5,  50000,  3, 4),
(8,  120000, 3, 5);

-- ================= KHÁCH HÀNG =================
INSERT INTO KhachHang (HoTen, SDT, DiemTichLuy) VALUES
(N'Nguyễn Thị Lan', '0981111111', 120),
(N'Trần Văn Hùng',  '0982222222', 50),
(N'Lê Thị Mai',     '0983333333', 150),
(N'Hoàng Minh',     '0984444444', 0),
(N'Phạm Thu Hà',    '0985555555', 30);

-- ================= SẢN PHẨM =================
INSERT INTO SanPham (TenSP, LoaiSP, DonGia) VALUES
(N'Cà phê đen', N'Đồ uống', 20000),
(N'Bánh Mì Que',N'Đồ ăn',   25000),
(N'Trà chanh', N'Đồ uống', 30000),
(N'Sinh tố dâu',N'Đồ uống', 40000),
(N'Bánh ngọt', N'Đồ ăn',   15000);

-- ================= BÀN =================
INSERT INTO Ban (STT, TrangThai) VALUES
(1, N'Trống'),
(2, N'Có khách'),
(3, N'Trống'),
(4, N'Trống'),
(5, N'Có khách');
-- ================= HÓA ĐƠN =================
INSERT INTO HoaDon (TruDiemTichLuy, MaNV, MaKH, MaBan) VALUES
(10, 'NV1', 1, 2),
(0,  'NV2', 2, 5);

-- ================= CHI TIẾT HÓA ĐƠN =================
INSERT INTO ChiTietHD (SoLuong, DaThu, MaHD, MaSP) VALUES
(2, 40000, 1, 1),   -- 2 ly cà phê đen
(1, 25000, 1, 2),   -- 1 bánh mì que
(1, 30000, 2, 3),   -- 1 trà chanh
(2, 80000, 2, 4);   -- 2 sinh tố dâu

-- ================= TÀI KHOẢN =================
INSERT INTO TaiKhoan (ID, MatKhau) VALUES
('NV1', '0901111111'),   -- NV1
('NV2', '0902222222'),   -- NV2
('NV3', '0903333333');   -- NV3

-- ================= CHỨC NĂNG =================
INSERT INTO ChucNang (MaCN, TenChucNang) VALUES
('NQL', N'admin'),
('NV', N'staff'),
('TN', N'cashier');

-- ================= CHI TIẾT CHỨC NĂNG =================
INSERT INTO ChiTietChucNang (ID, MaCN) VALUES
('NV1', 'NQL'),  -- NV1 -> admin
('NV2', 'NV'),  -- NV2 -> staff
('NV3', 'TN');  -- NV3 -> cashier




--Fix lại lỗi identity tăng

-- DBCC CHECKIDENT ('SanPham', RESEED, 5)
--DBCC CHECKIDENT ('SanPham', NORESEED)
