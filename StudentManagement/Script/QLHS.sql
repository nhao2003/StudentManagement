﻿CREATE database QUANLYHOCSINH;
GO 
USE QUANLYHOCSINH;
CREATE TABLE NAMHOC (
    MANH nvarchar(7) NOT NULL PRIMARY key,
    TENNAMHOC nvarchar(20),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE HOCKY (
    MAHK nvarchar(7) NOT NULL PRIMARY key,
    TENHK nvarchar(20),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE TAIKHOAN (
    USERNAME nvarchar(100) NOT NULL PRIMARY key,
    PASSWRD nvarchar(100) NOT NULL,
    VAITRO nvarchar(7),
    HOTEN nvarchar(100) NOT NULL,
    NGSINH SMALLDATETIME,
    EMAIL nvarchar(50),
    DCHI nvarchar(250),
    GIOITINH BIT DEFAULT 0,
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE GIAOVIEN (
    MAGV nvarchar(7) NOT NULL PRIMARY KEY,
    USERNAME nvarchar(100) NOT NULL FOREIGN KEY REFERENCES TAIKHOAN (USERNAME),
    HOCVI nvarchar(50),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE NHANVIENPHONGDAOTAO (
    MANV nvarchar(7) NOT NULL PRIMARY KEY,
    USERNAME nvarchar(100) NOT NULL FOREIGN KEY REFERENCES TAIKHOAN (USERNAME),
    CHUCVU nvarchar(50),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE HOCSINH (
    MAHS nvarchar(7) NOT NULL PRIMARY key,
    CCCD nvarchar(12),
    HOTENHS nvarchar(100),
    NGSINH DATE,
    EMAIL nvarchar(250),
    SDT nvarchar(11),
    DCHI nvarchar(250),
    GIOITINH BIT DEFAULT 0,
    TONGIAO nvarchar(10),
    DANTOC nvarchar(10),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE PHHS (
    MAPHHS nvarchar(7) NOT NULL PRIMARY key,
    MAHS nvarchar(7) FOREIGN KEY REFERENCES HOCSINH (MAHS),
    HOTENPHHS nvarchar(100),
	SDT nvarchar(11),
);
CREATE TABLE MONHOC (
    MAMH nvarchar(7) NOT NULL PRIMARY key,
    TENMH nvarchar(30),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE LOP (
    MALOP nvarchar(7) NOT NULL PRIMARY key,
    KHOI INT,
    TENLOP nvarchar(30),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE LOPHOCTHUCTE (
    MALHTT nvarchar(10) NOT NULL PRIMARY key,
    MALOP nvarchar(7) FOREIGN KEY REFERENCES LOP (MALOP),
    MANH nvarchar(7) FOREIGN KEY REFERENCES NAMHOC (MANH),
    MAGVCN nvarchar(7) FOREIGN KEY REFERENCES GIAOVIEN (MAGV),
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE LOPHOCTHUCTE_HOCSINH (
    MALHTT nvarchar(10) FOREIGN KEY REFERENCES LOPHOCTHUCTE (MALHTT),
    MAHS nvarchar(7) FOREIGN KEY REFERENCES HOCSINH (MAHS),
    PRIMARY key (MALHTT, MAHS)
);
CREATE TABLE LOAIKIEMTRA (
    MALKT nvarchar(7) PRIMARY KEY,
    TENLOAIKIEMTRA nvarchar(50),
    TILE FLOAT NOT NULL,
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE DIEMMONHOC (
    MAHS nvarchar(7) FOREIGN KEY REFERENCES HOCSINH (MAHS),
    MAHK nvarchar(7) FOREIGN KEY REFERENCES HOCKY (MAHK),
    MAMH nvarchar(7) FOREIGN KEY REFERENCES MONHOC (MAMH),
    MANH nvarchar(7) FOREIGN KEY REFERENCES NAMHOC (MANH),
    MALKT nvarchar(7) FOREIGN KEY REFERENCES LOAIKIEMTRA (MALKT),
    DIEM FLOAT NOT NULL,
    PRIMARY key (MAHS, MAHK, MANH, MAMH, MALKT)
);
CREATE TABLE HOCLUC (
    MaHocLuc NVARCHAR (7) NOT NULL PRIMARY KEY,
    TenHocLuc NVARCHAR (50) NOT NULL,
    DiemCanDuoi FLOAT NOT NULL,
    DiemCanTren FLOAT NOT NULL,
    DiemKhongChe FLOAT NOT NULL,
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE HANHKIEM (
    MaHanhKiem NVARCHAR (7) NOT NULL PRIMARY KEY,
    TenHanhKiem NVARCHAR (50) NOT NULL,
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE KETQUA (
    MaKetQua NVARCHAR (7) NOT NULL PRIMARY KEY,
    TenKetQua NVARCHAR (50) NOT NULL,
    ISDELETED BIT DEFAULT 0,
);
CREATE TABLE KQHOCKYMONHOC
(
	MAHS	NVARCHAR (7)		NOT NULL FOREIGN KEY REFERENCES HOCSINH(MAHS),
	MAMH	NVARCHAR (7)		NOT NULL FOREIGN KEY REFERENCES MONHOC(MAMH),
	MAHK	NVARCHAR (7)		NOT NULL FOREIGN KEY REFERENCES HOCKY(MAHK),
	MANH	NVARCHAR (7)		NOT NULL FOREIGN KEY REFERENCES NAMHOC(MANH),
	DTBMonHocKy	FLOAT			NOT NULL,
	PRIMARY KEY(MAHS, MAMH, MAHK, MANH),
);
CREATE TABLE KQHOCKYTONGHOP
(
	MAHS NVARCHAR (7) NOT NULL FOREIGN KEY REFERENCES HOCSINH(MAHS),
	MAHK NVARCHAR (7) NOT NULL FOREIGN KEY REFERENCES HOCKY(MAHK),
	MANH NVARCHAR (7) NOT NULL FOREIGN KEY REFERENCES NAMHOC(MANH),
    MaHocLuc NVARCHAR (7) FOREIGN KEY REFERENCES HOCLUC (MaHocLuc),
    MaHanhKiem NVARCHAR (7) FOREIGN KEY REFERENCES HANHKIEM (MaHanhKiem),
	DTBTatCaMonHocKy FLOAT,
	PRIMARY KEY(MAHS, MAHK, MANH),

);
CREATE TABLE KQNAMHOC (
    MAHS nvarchar(7) FOREIGN KEY REFERENCES HOCSINH (MAHS),
    MANH nvarchar(7) FOREIGN KEY REFERENCES NAMHOC (MANH),
    MaHocLuc NVARCHAR (7) FOREIGN KEY REFERENCES HOCLUC (MaHocLuc),
    MaHanhKiem NVARCHAR (7) FOREIGN KEY REFERENCES HANHKIEM (MaHanhKiem),
    MaKetQua NVARCHAR (7) FOREIGN KEY REFERENCES KETQUA (MaKetQua),
	PRIMARY KEY (MAHS, MANH),
);
CREATE TABLE KHANANGGIANGDAY (
    MAGV nvarchar(7) FOREIGN KEY REFERENCES GIAOVIEN (MAGV),
    MAMH nvarchar(7) FOREIGN KEY REFERENCES MONHOC (MAMH),
    ISDELETED BIT DEFAULT 0,
    PRIMARY KEY (MAGV, MAMH)
);
CREATE TABLE PHANCONGGIANGDAY (
    MANH nvarchar(7) FOREIGN KEY REFERENCES NAMHOC (MANH),
    MALHTT nvarchar(10) FOREIGN KEY REFERENCES LOPHOCTHUCTE (MALHTT),
    MAGV nvarchar(7) FOREIGN KEY REFERENCES GIAOVIEN (MAGV),
    MAMH nvarchar(7) FOREIGN KEY REFERENCES MONHOC (MAMH),
    ISDELETED BIT DEFAULT 0,
    PRIMARY KEY (MANH, MALHTT, MAMH, MAGV),
    FOREIGN KEY (MAGV, MAMH) REFERENCES KHANANGGIANGDAY (MAGV, MAMH)
);
CREATE TABLE THAMSO (
    ID nvarchar(10) NOT NULL PRIMARY key,
    TENTS nvarchar(100),
    TYPETS nvarchar(100),
    GIATRI nvarchar(1000),
    GHICHU nvarchar(1000),
    ISDELETED BIT DEFAULT 0,
);
SET
    DATEFORMAT DMY;
