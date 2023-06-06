-- Bảng tham số
INSERT INTO THAMSO (ID, TENTS, TYPETS, GIATRI, GHICHU)
VALUES ('TS001', N'Tuổi tối thiểu học sinh', 'int', '15', N'Số tuổi tối thiểu học sinh nhập học.'),
('TS002', N'Tuổi tối đa học sinh', 'int', '20', N'Số tổi tối đa học sinh nhập học.'),
('TS003', N'Điểm số tối thiểu', 'double', '0', N'Điểm số tối thiểu môn học.'),
('TS004', N'Điểm số tối đa', 'double', '10', N'Điểm số tối đa môn học.'),
('TS005', N'Sỉ số tối đa của lớp', 'int', '30', N'Sỉ số tối đa trong một lớp.'),
('TS006', N'Điểm số đạt tối thiểu', 'double', '5', N'Điểm số cần và đủ để đạt môn học.');

-- Bảng môn học
INSERT INTO MONHOC (MAMH, TENMH) VALUES
('MH001', N'Toán'),
('MH002', N'Ngữ văn'),
('MH003', N'Vật lí'),
('MH004', N'Hóa học'),
('MH005', N'Sinh học'),
('MH006', N'Lịch sử'),
('MH007', N'Địa lí'),
('MH008', N'Giáo dục công dân'),
('MH009', N'Tiếng Anh'),
('MH010', N'Công nghệ'),
('MH011', N'Thể dục'),
('MH012', N'Âm nhạc'),
('MH013', N'Mỹ thuật');
-- Bảng NAMHOC
INSERT INTO NAMHOC (MANH, TENNAMHOC)
VALUES ('NH001', N'2021-2022'),
('NH002', N'2022-2023'),
('NH003', N'2023-2024'),
('NH004', N'2024-2025');

-- Bảng HOCKY
INSERT INTO HOCKY (MAHK, TENHK)
VALUES ('HK001', N'Học kỳ 1'),
('HK002', N'Học kỳ 2');

-- Bảng LOP
INSERT INTO LOP (MALOP, KHOI, TENLOP)
VALUES ('L10A1', 10, 'A1'),
('L10A2', 10, 'A2'),
('L10A3', 10, 'A3'),
('L10B1', 10, 'B1'),
('L10B2', 10, 'B2'),
('L10B3', 10, 'B3'),
('L10C1', 10, 'C1'),
('L10C2', 10, 'C2'),
('L10C3', 10, 'C3'),
('L10D1', 10, 'D1'),
('L10D2', 10, 'D2'),
('L10D3', 10, 'D3'),
('L11A1', 11, 'A1'),
('L11A2', 11, 'A2'),
('L11A3', 11, 'A3'),
('L11B1', 11, 'B1'),
('L11B2', 11, 'B2'),
('L11B3', 11, 'B3'),
('L11C1', 11, 'C1'),
('L11C2', 11, 'C2'),
('L11C3', 11, 'C3'),
('L11D1', 11, 'D1'),
('L11D2', 11, 'D2'),
('L11D3', 11, 'D3'),
('L12A1', 12, 'A1'),
('L12A2', 12, 'A2'),
('L12A3', 12, 'A3'),
('L12B1', 12, 'B1'),
('L12B2', 12, 'B2'),
('L12B3', 12, 'B3'),
('L12C1', 12, 'C1'),
('L12C2', 12, 'C2'),
('L12C3', 12, 'C3'),
('L12D1', 12, 'D1'),
('L12D2', 12, 'D2'),
('L12D3', 12, 'D3');

-- Bảng LOAIKIEMTRA
INSERT INTO LOAIKIEMTRA (MALKT, TENLOAIKIEMTRA, TILE)
VALUES ('LKT001', N'Kiểm tra miệng', 0.1),
('LKT002', N'Kiểm tra 15 phút', 0.2),
 ('LKT003', N'Kiểm tra 45 phút', 0.3),
('LKT004', N'Kiểm tra cuối kỳ', 0.4);

-- Bảng HOCLUC
INSERT INTO HOCLUC (MaHocLuc, TenHocLuc, DiemCanDuoi, DiemCanTren, DiemKhongChe)
VALUES ('HL001', N'Giỏi', 8.0, 10.0, 6.5),
('HL002', N'Khá', 6.5, 7.9, 5.0),
('HL003', N'Trung bình', 3.5, 4.9, 2.0),
('HL004', N'Yếu', 0.0, 3.4, 0.0);

-- Bảng HANHKIEM
INSERT INTO HANHKIEM (MaHanhKiem, TenHanhKiem)
VALUES ('HK001', N'Tốt'),
('HK002', N'Khá'),
('HK003', N'Trung bình');

-- Bảng KETQUA
INSERT INTO KETQUA (MaKetQua, TenKetQua)
VALUES ('KQ001', N'Lên lớp'),
('KQ002', N'Ở lại lớp');


-- Bảng TAIKHOAN
INSERT INTO TAIKHOAN (USERNAME, PASSWRD, VAITRO, HOTEN, NGSINH, EMAIL, DCHI, GIOITINH)
VALUES ('user1', 'password1', 'GV', N'Nguyễn Văn A', '1990-01-01', 'user1@example.com', 'Địa chỉ 1', 0),
('user2', 'password2', 'NV', N'Trần Thị B', '1995-02-02', 'user2@example.com', 'Địa chỉ 2', 1),
('user3', 'password001', 'GV', N'Nguyễn Văn A', '1990-01-01', 'nguyenvana@gmail.com', '123 Đường ABC', 1),
('user4', 'password002', 'NV', N'Nguyễn Thị B', '1995-05-05', 'nguyenthib@gmail.com', '456 Đường XYZ', 0),
('user5', 'password002', 'NV', N'Nguyễn Thị C', '1995-05-05', 'nguyenthib@gmail.com', '456 Đường XYZ', 0),
('user6', 'password002', 'NV', N'Nguyễn Thị D', '1995-05-05', 'nguyenthib@gmail.com', '456 Đường XYZ', 0);

-- Bảng GIAOVIEN
INSERT INTO GIAOVIEN (MAGV, USERNAME, HOCVI)
VALUES ('GV001', 'user1', N'Tiến sĩ'),
('GV002', 'user2', N'Thạc sĩ'),
 ('GV003', 'user3', N'Tiến sĩ');
 INSERT INTO NHANVIENPHONGDAOTAO (MANV, USERNAME, CHUCVU) VALUES
('NV001', 'user4', N'Thạc sĩ'),
 ('NV002', 'user5', N'Trưởng phòng'),
 ('NV003', 'user6', N'Trưởng phòng');

-- Bảng HOCSINH
INSERT INTO HOCSINH (MAHS, CCCD, HOTENHS, NGSINH, EMAIL, SDT, DCHI, GIOITINH, TONGIAO, DANTOC)
VALUES ('HS001', 'CCCD001', N'Nguyễn Thị C', '2005-03-03', 'hs1@example.com', '123456789', N'Địa chỉ 3', 1, N'Không', N'Kinh'),
('HS002', 'CCCD002', N'Trần Văn D', '2006-04-04', 'hs2@example.com', '987654321', N'Địa chỉ 4', 0, N'Không', N'Kinh'),
('HS003', '123456789012', N'Nguyễn Thị C', '2000-03-03', 'nguyenthic@gmail.com', '0123456789', N'789 Đường XYZ', 0, N'Không', N'Kinh'),
('HS004', '987654321098', N'Nguyễn Văn D', '2001-04-04', 'nguyenvand@gmail.com', '0987654321', N'987 Đường ABC', 1, N'Công giáo', N'Kinh');

-- Bảng PHHS
INSERT INTO PHHS (MAPHHS, MAHS, HOTENPHHS, SDT)
VALUES ('PHHS001', 'HS003', N'Phụ huynh C', '0123456789'),
('PHHS002', 'HS004', N'Phụ huynh D', '0987654321');



-- Bảng LOPHOCTHUCTE
INSERT INTO LOPHOCTHUCTE (MALHTT, MALOP, MANH, MAGVCN)
VALUES 
('LHTT001', 'L10A2', 'NH001', 'GV001'),
('LHTT002', 'L10A1', 'NH002', 'GV002'),
('LHTT003', 'L11A2', 'NH002', 'GV002'),
('LHTT004', 'L12A2', 'NH003', 'GV003');

-- Bảng LOPHOCTHUCTE_HOCSINH
INSERT INTO LOPHOCTHUCTE_HOCSINH (MALHTT, MAHS)
VALUES ('LHTT001', 'HS001'),
('LHTT002', 'HS002'),
('LHTT003', 'HS003'),
('LHTT004', 'HS004');



-- Bảng DIEMMONHOC
INSERT INTO DIEMMONHOC (MAHS, MAHK, MAMH, MANH, MALKT, DIEM)
VALUES ('HS001', 'HK001', 'MH001', 'NH001', 'LKT001', 8.5),
('HS002', 'HK001', 'MH001', 'NH002', 'LKT001', 9.0),
 ('HS003', 'HK002', 'MH003', 'NH003', 'LKT003', 8.5),
('HS004', 'HK002', 'MH004', 'NH004', 'LKT004', 7.2);


-- Bảng KQHOCKYMONHOC
INSERT INTO KQHOCKYMONHOC (MAHS, MAMH, MAHK, MANH, DTBMonHocKy)
VALUES ('HS001', 'MH001', 'HK001', 'NH001', 8.7),
('HS002', 'MH001', 'HK001', 'NH001', 9.2),
('HS003', 'MH003', 'HK002', 'NH002', 8.7),
('HS004', 'MH004', 'HK002', 'NH003', 6.8);

-- Bảng KQHOCKYTONGHOP
INSERT INTO KQHOCKYTONGHOP (MAHS, MAHK, MANH, MaHocLuc, MaHanhKiem, DTBTatCaMonHocKy)
VALUES ('HS001', 'HK001', 'NH001', 'HL001', 'HK001', 8.2),
('HS002', 'HK002', 'NH002', 'HL002', 'HK002', 7.6);

-- Bảng KQNAMHOC
INSERT INTO KQNAMHOC (MAHS, MANH, MaHocLuc, MaHanhKiem, MaKetQua)
VALUES ('HS001', 'NH001', 'HL001', 'HK001', 'KQ001'),
('HS002', 'NH001', 'HL001', 'HK001', 'KQ001'),
('HS003', 'NH002', 'HL001', 'HK001', 'KQ001'),
('HS004', 'NH003', 'HL002', 'HK002', 'KQ002');

-- Bảng KHANANGGIANGDAY
INSERT INTO KHANANGGIANGDAY (MAGV, MAMH)
VALUES ('GV001', 'MH001'),
('GV002', 'MH002'),
('GV002', 'MH003'),
('GV003', 'MH004');

-- Bảng PHANCONGGIANGDAY
INSERT INTO PHANCONGGIANGDAY (MANH, MALHTT, MAGV, MAMH)
VALUES ('NH001', 'LHTT001', 'GV001', 'MH001'),
('NH002', 'LHTT002', 'GV002', 'MH002');
