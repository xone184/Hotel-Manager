USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 10/12/2023 10:36:26 AM ******/
CREATE DATABASE [QLKS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKS_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLKS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLKS_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLKS.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLKS] SET  MULTI_USER 
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLKS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLKS', N'ON'
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLKS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[datphong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[datphong](
	[id_datphong] [varchar](5) NOT NULL,
	[id_nhanvien] [varchar](5) NOT NULL,
	[id_khachhang] [varchar](5) NOT NULL,
	[id_phong] [varchar](5) NOT NULL,
	[check_in] [datetime] NOT NULL,
	[check_out] [datetime] NULL,
	[dat_coc] [float] NULL,
	[tien_phong] [float] NULL,
	[phu_thu_checkin] [float] NULL,
	[phu_thu_checkout] [float] NULL,
	[tong_tien_dv] [float] NULL,
	[tong_tien_tb] [float] NULL,
	[tong_tien_hoa_don] [float] NULL,
	[tong_tien] [float] NULL,
	[so_nguoi_o] [int] NULL,
	[loai] [nvarchar](20) NULL,
	[trang_thai] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_datphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[id_khachhang] [varchar](5) NOT NULL,
	[ten_khachhang] [nvarchar](50) NOT NULL,
	[ngay_sinh] [date] NOT NULL,
	[dia_chi] [nvarchar](300) NOT NULL,
	[sdt] [varchar](15) NOT NULL,
	[cmnd] [varchar](15) NOT NULL,
	[gioi_tinh] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_khachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[id_nhanvien] [varchar](5) NOT NULL,
	[ten_nhanvien] [nvarchar](100) NOT NULL,
	[ngay_sinh] [date] NOT NULL,
	[sdt] [varchar](10) NOT NULL,
	[gioi_tinh] [nvarchar](6) NOT NULL,
	[email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_nhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phong](
	[id_phong] [varchar](5) NOT NULL,
	[id_loaiphong] [int] NOT NULL,
	[id_tang] [int] NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[trang_thai] [nvarchar](30) NULL,
	[gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_phong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_datphong2]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC Update_TrangThaiPhong_1 @idphong = ''




--CREATE VIEW thongtindatphong AS
--SELECT dp.id_datphong, p.ten, dp.loai AS loai, dp.check_in, dp.check_out, DATEDIFF(HOUR, dp.check_in, dp.check_out) AS tong_thoi_gian
--FROM datphong dp
--INNER JOIN phong p ON dp.id_phong = p.id_phong
--INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong;
--GO

--SELECT id_datphong, ten, loai, check_in, check_out, tong_thoi_gian FROM thongtindatphong;

--CREATE VIEW thongtindatphong1 AS
--SELECT dp.id_datphong, p.ten, dp.loai AS loai, dp.check_in, dp.check_out, DATEDIFF(DAY, dp.check_in, dp.check_out) AS tong_thoi_gian
--FROM datphong dp
--INNER JOIN phong p ON dp.id_phong = p.id_phong
--INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong;
--GO

--SELECT id_datphong, ten, loai, check_in, check_out, tong_thoi_gian FROM thongtindatphong1;
--SELECT * FROM datphong

--CREATE VIEW view_datphong AS
--SELECT dp.id_datphong, p.ten, dp.loai, dp.check_in, dp.check_out, 
--CASE
--    WHEN dp.loai = N'Theo ngày' THEN DATEDIFF(DAY, dp.check_in, dp.check_out)
--    WHEN dp.loai = N'Theo giờ' THEN DATEDIFF(HOUR, dp.check_in, dp.check_out)
--END AS tong_thoi_gian,
--nv.ten_nhanvien AS ten_nhanvien, kh.ten_khachhang AS ten_khachhang
--FROM datphong dp
--JOIN phong p ON dp.id_phong = p.id_phong
--JOIN nhanvien nv ON dp.id_nhanvien = nv.id_nhanvien
--JOIN khachhang kh ON dp.id_khachhang = kh.id_khachhang;
--GO

--SELECT id_datphong, ten, ten_nhanvien, ten_khachhang, loai, check_in, check_out, tong_thoi_gian 
--FROM view_datphong 
--where ten = N'Phòng 101' 

--GO

--CREATE VIEW view_datphong1 AS
--SELECT dp.id_datphong, p.ten, dp.id_phong, dp.loai, dp.check_in, dp.check_out, 
--CASE
--    WHEN dp.loai = N'Theo ngày' THEN DATEDIFF(DAY, dp.check_in, dp.check_out)
--    WHEN dp.loai = N'Theo giờ' THEN DATEDIFF(HOUR, dp.check_in, dp.check_out)
--END AS tong_thoi_gian,
--nv.ten_nhanvien AS ten_nhanvien, kh.ten_khachhang AS ten_khachhang
--FROM datphong dp
--JOIN phong p ON dp.id_phong = p.id_phong
--JOIN nhanvien nv ON dp.id_nhanvien = nv.id_nhanvien
--JOIN khachhang kh ON dp.id_khachhang = kh.id_khachhang;
--GO
--SELECT id_datphong, ten, id_phong, ten_nhanvien, ten_khachhang, loai, check_in, check_out, tong_thoi_gian FROM view_datphong1;

CREATE VIEW [dbo].[view_datphong2] AS
SELECT dp.id_datphong, p.ten, dp.loai, dp.check_in, dp.check_out, dp.trang_thai,
CASE
    WHEN dp.loai = N'Theo ngày' THEN DATEDIFF(DAY, dp.check_in, dp.check_out)
    WHEN dp.loai = N'Theo giờ' THEN DATEDIFF(HOUR, dp.check_in, dp.check_out)
END AS tong_thoi_gian,
nv.ten_nhanvien AS ten_nhanvien, kh.ten_khachhang AS ten_khachhang
FROM datphong dp
JOIN phong p ON dp.id_phong = p.id_phong
JOIN nhanvien nv ON dp.id_nhanvien = nv.id_nhanvien
JOIN khachhang kh ON dp.id_khachhang = kh.id_khachhang;
GO
/****** Object:  Table [dbo].[chitietsudungdv]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietsudungdv](
	[id_datphong] [varchar](5) NOT NULL,
	[id_dichvu] [varchar](5) NOT NULL,
	[ngay_thue] [date] NULL,
	[so_luong] [int] NULL,
	[tong_tien_dv] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_datphong] ASC,
	[id_dichvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietsudungtb]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietsudungtb](
	[id_datphong] [varchar](5) NOT NULL,
	[id_thietbi] [varchar](5) NOT NULL,
	[ngay_thue] [date] NULL,
	[so_luong] [int] NULL,
	[tong_tien_tb] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_datphong] ASC,
	[id_thietbi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[datphongonline]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[datphongonline](
	[id_datphong] [int] IDENTITY(1,1) NOT NULL,
	[id_phong] [varchar](5) NOT NULL,
	[check_in] [datetime] NOT NULL,
	[check_out] [datetime] NOT NULL,
	[tong_tien] [float] NOT NULL,
	[so_nguoi_o] [int] NOT NULL,
	[trang_thai] [nvarchar](40) NULL,
	[ten_khachhang] [nvarchar](50) NOT NULL,
	[ngay_sinh] [date] NOT NULL,
	[dia_chi] [nvarchar](300) NOT NULL,
	[sdt] [varchar](15) NOT NULL,
	[cmnd] [varchar](15) NOT NULL,
	[gioi_tinh] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_datphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dichvu]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dichvu](
	[id_dichvu] [varchar](5) NOT NULL,
	[ten_dichvu] [nvarchar](50) NOT NULL,
	[gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_dichvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[imgphong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[imgphong](
	[id_loaiphong] [int] NOT NULL,
	[id_hinh] [varchar](150) NOT NULL,
 CONSTRAINT [pk_imgphong] PRIMARY KEY CLUSTERED 
(
	[id_loaiphong] ASC,
	[id_hinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachsan]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachsan](
	[id] [varchar](5) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[dia_chi] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaiphong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiphong](
	[id_loaiphong] [int] NOT NULL,
	[ten_loai] [nvarchar](50) NOT NULL,
	[so_luong_nguoi] [int] NOT NULL,
	[mota] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_loaiphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taikhoan]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[id_taikhoan] [int] IDENTITY(1,1) NOT NULL,
	[id_nhanvien] [varchar](5) NULL,
	[ten_dang_nhap] [varchar](100) NOT NULL,
	[mat_khau] [varchar](100) NULL,
	[hoat_dong] [int] NULL,
	[quyen] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tang]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tang](
	[id_tang] [int] NOT NULL,
	[ten_tang] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thietbi]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thietbi](
	[id_thietbi] [varchar](5) NOT NULL,
	[ten_thietbi] [nvarchar](50) NOT NULL,
	[gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_thietbi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[chitietsudungdv] ([id_datphong], [id_dichvu], [ngay_thue], [so_luong], [tong_tien_dv]) VALUES (N'HD011', N'DV001', CAST(N'2023-12-07' AS Date), 1, 200000)
GO
INSERT [dbo].[chitietsudungtb] ([id_datphong], [id_thietbi], [ngay_thue], [so_luong], [tong_tien_tb]) VALUES (N'HD011', N'TB002', CAST(N'2023-12-07' AS Date), 1, 10000)
GO
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD001', N'NV001', N'KH001', N'P001', CAST(N'2023-11-01T22:42:44.000' AS DateTime), CAST(N'2023-11-03T22:42:44.000' AS DateTime), 250000, 500000, 0, 125000, 0, 0, 625000, 375000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD002', N'NV001', N'KH002', N'P018', CAST(N'2023-11-03T22:45:28.000' AS DateTime), CAST(N'2023-11-08T22:45:28.000' AS DateTime), 2375000, 4750000, 0, 475000, 0, 0, 5225000, 2850000, 2, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD003', N'NV001', N'KH008', N'P004', CAST(N'2023-11-14T22:48:40.000' AS DateTime), CAST(N'2023-11-17T22:48:40.000' AS DateTime), 525000, 1050000, 0, 175000, 0, 0, 1225000, 700000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD004', N'NV001', N'KH009', N'P010', CAST(N'2023-11-30T22:49:29.000' AS DateTime), CAST(N'2023-12-03T22:49:29.000' AS DateTime), 1275000, 2550000, 0, 425000, 0, 0, 2975000, 1700000, 2, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD005', N'NV001', N'KH003', N'P016', CAST(N'2023-11-21T22:56:51.000' AS DateTime), CAST(N'2023-11-26T22:56:51.000' AS DateTime), 2375000, 4750000, 0, 475000, 0, 0, 5225000, 2850000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD006', N'NV001', N'KH004', N'P012', CAST(N'2023-11-18T22:58:58.000' AS DateTime), CAST(N'2023-11-22T22:58:58.000' AS DateTime), 1700000, 3400000, 0, 425000, 0, 0, 3825000, 2125000, 2, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD007', N'NV001', N'KH010', N'P011', CAST(N'2023-11-28T23:10:39.000' AS DateTime), CAST(N'2023-11-30T23:10:39.000' AS DateTime), 850000, 1700000, 0, 425000, 0, 0, 2125000, 1275000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD008', N'NV001', N'KH001', N'P009', CAST(N'2023-11-30T23:11:51.000' AS DateTime), CAST(N'2023-12-01T23:11:51.000' AS DateTime), 325000, 650000, 0, 325000, 0, 0, 975000, 650000, 2, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD009', N'NV001', N'KH006', N'P002', CAST(N'2023-11-17T23:13:05.000' AS DateTime), CAST(N'2023-11-24T23:13:05.000' AS DateTime), 875000, 1750000, 0, 125000, 0, 0, 1875000, 1000000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD010', N'NV001', N'KH011', N'P017', CAST(N'2023-11-09T23:14:04.000' AS DateTime), CAST(N'2023-11-16T23:14:04.000' AS DateTime), 3325000, 6650000, 0, 475000, 0, 0, 7125000, 3800000, 2, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD011', N'NV001', N'KH001', N'P019', CAST(N'2023-12-07T08:44:39.773' AS DateTime), CAST(N'2023-12-10T08:44:39.000' AS DateTime), 750000, 1500000, 150000, 0, 200000, 10000, 1860000, 1110000, 1, N'Theo Ngày', N'Đã thanh toán')
INSERT [dbo].[datphong] ([id_datphong], [id_nhanvien], [id_khachhang], [id_phong], [check_in], [check_out], [dat_coc], [tien_phong], [phu_thu_checkin], [phu_thu_checkout], [tong_tien_dv], [tong_tien_tb], [tong_tien_hoa_don], [tong_tien], [so_nguoi_o], [loai], [trang_thai]) VALUES (N'HD012', N'NV001', N'KH012', N'P002', CAST(N'2023-12-07T00:00:00.000' AS DateTime), CAST(N'2023-12-08T00:00:00.000' AS DateTime), 125000, 250000, 250000, 0, 0, 0, 500000, 375000, 1, N'Theo Ngày', N'Chưa thanh toán')
GO
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV001', N'Giặt ủi', 200000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV002', N'Quầy bar', 300000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV003', N'Dịch vụ spa', 250000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV004', N'Fitness', 350000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV005', N'Buổi ăn phụ', 200000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV006', N'Sử dụng hồ bơi', 150000)
INSERT [dbo].[dichvu] ([id_dichvu], [ten_dichvu], [gia]) VALUES (N'DV007', N'Karaoke', 250000)
GO
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (1, N'loai1_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (1, N'loai1_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (1, N'loai1_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (1, N'loai1_img4.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (2, N'loai2_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (2, N'loai2_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (2, N'loai2_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (2, N'loai2_img4.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (3, N'loai3_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (3, N'loai3_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (3, N'loai3_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (3, N'loai3_img4.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (4, N'loai4_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (4, N'loai4_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (4, N'loai4_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (4, N'loai4_img4.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (5, N'loai5_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (5, N'loai5_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (5, N'loai5_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (5, N'loai5_img4.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (6, N'loai6_img1.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (6, N'loai6_img2.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (6, N'loai6_img3.jpg')
INSERT [dbo].[imgphong] ([id_loaiphong], [id_hinh]) VALUES (6, N'loai6_img4.jpg')
GO
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH001', N'Châu Minh Quân', CAST(N'2002-03-01' AS Date), N'Bình Tân', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH002', N'Huỳnh Khánh Duy', CAST(N'2002-03-01' AS Date), N'Hóc Môn', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH003', N'Ngô Hoài Nhật Duy', CAST(N'2002-03-01' AS Date), N'Tân Phú', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH004', N'Lư Gia Hoàng', CAST(N'2002-03-01' AS Date), N'Tân Phú', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH005', N'Trần Đỗ Anh Hào', CAST(N'2002-03-01' AS Date), N'Hóc Môn', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH006', N'Vũ Nguyễn Hoàng', CAST(N'2002-03-01' AS Date), N'Trường Chinh', N'0123456789', N'159635784000', N'Nam')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH007', N'Trần Phi Bằng', CAST(N'2002-03-01' AS Date), N'Quang Trung', N'0123456789', N'159635784000', N'Nữ')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH008', N'Huỳnh Gia Thuận', CAST(N'2002-03-01' AS Date), N'Hóc Môn', N'0123456789', N'159635784000', N'Nữ')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH009', N'Phan Chí Cường', CAST(N'2002-03-01' AS Date), N'Tân Phú', N'0123456789', N'159635784000', N'Nữ')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH010', N'Lê Thành An', CAST(N'2002-03-01' AS Date), N'Tân Phú', N'0123456789', N'159635784000', N'Nữ')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH011', N'Mai Ngọc Khang', CAST(N'2002-03-01' AS Date), N'Tân Phú', N'0123456789', N'159635784000', N'Nữ')
INSERT [dbo].[khachhang] ([id_khachhang], [ten_khachhang], [ngay_sinh], [dia_chi], [sdt], [cmnd], [gioi_tinh]) VALUES (N'KH012', N'Phạm Tuấn Anh', CAST(N'2002-09-30' AS Date), N'đasasdadasdsa', N'3423243432', N'432434324466', N'Nam')
GO
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (1, N'Phòng đơn loại 1', 1, N'Phòng đơn loại 1 tại GreenInn là sự hoàn hảo của sự tinh tế và tiện nghi. Với kiến ​​trúc độc đáo kết hợp giữa vẻ cổ điển và thiết kế hiện đại, mỗi phòng đều là một không gian ấm áp và thoải mái. Nội thất sang trọng và cao cấp được chăm chút tỉ mỉ.')
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (2, N'Phòng đơn loại 2', 1, N'Phòng đơn loại 2 không chỉ là một nơi nghỉ ngơi, mà còn là điểm đến của sự sang trọng và tiện nghi. Tận hưởng không gian riêng tư của bạn trong không gian ấm cúng và đẳng cấp tại GreenInn, nơi mà mọi yêu cầu của bạn đều được chăm sóc với tận tâm và chất lượng.')
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (3, N'Phòng đôi loại 1', 2, N'Phòng đôi loại 1 của chúng tôi không chỉ là một nơi nghỉ ngơi, mà còn là điểm đến của sự sang trọng và tiện nghi. Tận hưởng không gian riêng tư của bạn trong không gian ấm cúng và đẳng cấp tại GreenInn.')
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (4, N'Phòng đôi loại 2', 2, N'Phòng đôi loại 2 được thiết kế để mang đến trải nghiệm lưu trú đặc biệt, với không gian rộng rãi, trang thiết bị hiện đại và dịch vụ chăm sóc khách hàng hàng đầu.')
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (5, N'Phòng VIP đơn Standard', 1, N'Phòng VIP đơn loại Standard tại chỗ nghỉ của chúng tôi là sự kết hợp tuyệt vời giữa tiện nghi cao cấp và không gian thoải mái. Nơi đây được thiết kế đặc biệt để đáp ứng mọi nhu cầu của khách hàng VIP, mang đến trải nghiệm lưu trú đẳng cấp và sang trọng.')
INSERT [dbo].[loaiphong] ([id_loaiphong], [ten_loai], [so_luong_nguoi], [mota]) VALUES (6, N'Phòng VIP đôi Standard', 2, N'Phòng VIP đôi loại Standard tại chỗ nghỉ của chúng tôi là sự kết hợp hoàn hảo giữa tiện nghi cao cấp và không gian sang trọng. Đây là nơi lưu trú lý tưởng cho các cặp đôi hoặc những người muốn trải nghiệm không gian sang trọng và đẳng cấp cùng nhau.')
GO
INSERT [dbo].[nhanvien] ([id_nhanvien], [ten_nhanvien], [ngay_sinh], [sdt], [gioi_tinh], [email]) VALUES (N'NV001', N'Phạm Lê Tuấn Anh', CAST(N'2002-05-12' AS Date), N'0123456789', N'Nam', N'ta@gmail.com')
INSERT [dbo].[nhanvien] ([id_nhanvien], [ten_nhanvien], [ngay_sinh], [sdt], [gioi_tinh], [email]) VALUES (N'NV002', N'Châu Minh Quân ', CAST(N'2002-12-27' AS Date), N'0123456789', N'Nam', N'quan@gmail.com')
INSERT [dbo].[nhanvien] ([id_nhanvien], [ten_nhanvien], [ngay_sinh], [sdt], [gioi_tinh], [email]) VALUES (N'NV003', N'Huỳnh Khánh Duy', CAST(N'2002-09-30' AS Date), N'0123345667', N'Nam ', N'duy@gmail.com')
GO
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P001', 1, 1, N'Phòng 101', N'Còn trống', 250000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P002', 1, 1, N'Phòng 102', N'Đang sử dụng', 250000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P003', 1, 1, N'Phòng 103', N'Còn trống', 250000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P004', 2, 1, N'Phòng 104', N'Còn trống', 350000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P005', 2, 1, N'Phòng 105', N'Còn trống', 350000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P006', 2, 1, N'Phòng 106', N'Còn trống', 350000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P007', 3, 2, N'Phòng 107', N'Đang dọn phòng', 650000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P008', 3, 2, N'Phòng 108', N'Còn trống', 650000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P009', 3, 2, N'Phòng 109', N'Đang dọn phòng', 650000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P010', 4, 2, N'Phòng 110', N'Còn trống', 850000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P011', 4, 2, N'Phòng 111', N'Còn trống', 850000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P012', 4, 2, N'Phòng 112', N'Còn trống', 850000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P013', 5, 3, N'Phòng 113', N'Còn trống', 810000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P014', 5, 3, N'Phòng 114', N'Còn trống', 810000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P015', 5, 3, N'Phòng 115', N'Còn trống', 810000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P016', 6, 3, N'Phòng 116', N'Còn trống', 950000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P017', 6, 3, N'Phòng 117', N'Còn trống', 950000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P018', 6, 3, N'Phòng 118', N'Còn trống', 950000)
INSERT [dbo].[phong] ([id_phong], [id_loaiphong], [id_tang], [ten], [trang_thai], [gia]) VALUES (N'P019', 1, 1, N'abc', N'Đang dọn phòng', 500000)
GO
SET IDENTITY_INSERT [dbo].[taikhoan] ON 

INSERT [dbo].[taikhoan] ([id_taikhoan], [id_nhanvien], [ten_dang_nhap], [mat_khau], [hoat_dong], [quyen]) VALUES (3, N'NV001', N'tuananh', N'123', 1, N'admin')
INSERT [dbo].[taikhoan] ([id_taikhoan], [id_nhanvien], [ten_dang_nhap], [mat_khau], [hoat_dong], [quyen]) VALUES (4, N'NV002', N'quan', N'456', 1, N'staff')
INSERT [dbo].[taikhoan] ([id_taikhoan], [id_nhanvien], [ten_dang_nhap], [mat_khau], [hoat_dong], [quyen]) VALUES (5, N'NV003', N'duy', N'789', 1, N'staff')
SET IDENTITY_INSERT [dbo].[taikhoan] OFF
GO
INSERT [dbo].[tang] ([id_tang], [ten_tang]) VALUES (1, N'Tầng 1')
INSERT [dbo].[tang] ([id_tang], [ten_tang]) VALUES (2, N'Tầng 2')
INSERT [dbo].[tang] ([id_tang], [ten_tang]) VALUES (3, N'Tầng 3')
GO
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB001', N'Dép (1 đôi)', 100000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB002', N'Nước suối (1 chai)', 10000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB003', N'Dầu gội (1 chai nhỏ)', 15000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB004', N'Sữa tắm (1 chai nhỏ)', 15000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB005', N'Kem đánh răng (1 tuýp nhỏ)', 15000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB006', N'Bàn chải (1 cây)', 5000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB007', N'Khăn tắm (1 cái)', 100000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB008', N'Máy sấy tóc (1 cái)', 300000)
INSERT [dbo].[thietbi] ([id_thietbi], [ten_thietbi], [gia]) VALUES (N'TB009', N'Cà phê (1 gói)', 5000)
GO
ALTER TABLE [dbo].[datphong] ADD  DEFAULT ((0)) FOR [tien_phong]
GO
ALTER TABLE [dbo].[datphong] ADD  DEFAULT ((0)) FOR [tong_tien_dv]
GO
ALTER TABLE [dbo].[datphong] ADD  DEFAULT ((0)) FOR [tong_tien_tb]
GO
ALTER TABLE [dbo].[datphong] ADD  DEFAULT ((0)) FOR [tong_tien_hoa_don]
GO
ALTER TABLE [dbo].[datphong] ADD  DEFAULT (N'Chưa thanh toán') FOR [trang_thai]
GO
ALTER TABLE [dbo].[datphongonline] ADD  DEFAULT (N'Chưa thanh toán') FOR [trang_thai]
GO
ALTER TABLE [dbo].[phong] ADD  DEFAULT (N'Còn trống') FOR [trang_thai]
GO
ALTER TABLE [dbo].[taikhoan] ADD  DEFAULT ('123') FOR [mat_khau]
GO
ALTER TABLE [dbo].[taikhoan] ADD  DEFAULT ('staff') FOR [quyen]
GO
ALTER TABLE [dbo].[chitietsudungdv]  WITH CHECK ADD  CONSTRAINT [fk_datphong_ctsddv] FOREIGN KEY([id_datphong])
REFERENCES [dbo].[datphong] ([id_datphong])
GO
ALTER TABLE [dbo].[chitietsudungdv] CHECK CONSTRAINT [fk_datphong_ctsddv]
GO
ALTER TABLE [dbo].[chitietsudungdv]  WITH CHECK ADD  CONSTRAINT [fk_dichvu_ctsddv] FOREIGN KEY([id_dichvu])
REFERENCES [dbo].[dichvu] ([id_dichvu])
GO
ALTER TABLE [dbo].[chitietsudungdv] CHECK CONSTRAINT [fk_dichvu_ctsddv]
GO
ALTER TABLE [dbo].[chitietsudungtb]  WITH CHECK ADD  CONSTRAINT [fk_datphong_ctsdtb] FOREIGN KEY([id_datphong])
REFERENCES [dbo].[datphong] ([id_datphong])
GO
ALTER TABLE [dbo].[chitietsudungtb] CHECK CONSTRAINT [fk_datphong_ctsdtb]
GO
ALTER TABLE [dbo].[chitietsudungtb]  WITH CHECK ADD  CONSTRAINT [fk_dichvu_ctsdtb] FOREIGN KEY([id_thietbi])
REFERENCES [dbo].[thietbi] ([id_thietbi])
GO
ALTER TABLE [dbo].[chitietsudungtb] CHECK CONSTRAINT [fk_dichvu_ctsdtb]
GO
ALTER TABLE [dbo].[datphong]  WITH CHECK ADD  CONSTRAINT [fk_khachhang] FOREIGN KEY([id_khachhang])
REFERENCES [dbo].[khachhang] ([id_khachhang])
GO
ALTER TABLE [dbo].[datphong] CHECK CONSTRAINT [fk_khachhang]
GO
ALTER TABLE [dbo].[datphong]  WITH CHECK ADD  CONSTRAINT [fk_nhanvien] FOREIGN KEY([id_nhanvien])
REFERENCES [dbo].[nhanvien] ([id_nhanvien])
GO
ALTER TABLE [dbo].[datphong] CHECK CONSTRAINT [fk_nhanvien]
GO
ALTER TABLE [dbo].[datphong]  WITH CHECK ADD  CONSTRAINT [fk_phong] FOREIGN KEY([id_phong])
REFERENCES [dbo].[phong] ([id_phong])
GO
ALTER TABLE [dbo].[datphong] CHECK CONSTRAINT [fk_phong]
GO
ALTER TABLE [dbo].[datphongonline]  WITH CHECK ADD  CONSTRAINT [fk_phong_online] FOREIGN KEY([id_phong])
REFERENCES [dbo].[phong] ([id_phong])
GO
ALTER TABLE [dbo].[datphongonline] CHECK CONSTRAINT [fk_phong_online]
GO
ALTER TABLE [dbo].[imgphong]  WITH CHECK ADD  CONSTRAINT [fk_loaiphong_imgphong] FOREIGN KEY([id_loaiphong])
REFERENCES [dbo].[loaiphong] ([id_loaiphong])
GO
ALTER TABLE [dbo].[imgphong] CHECK CONSTRAINT [fk_loaiphong_imgphong]
GO
ALTER TABLE [dbo].[phong]  WITH CHECK ADD  CONSTRAINT [fk_loaiphong] FOREIGN KEY([id_loaiphong])
REFERENCES [dbo].[loaiphong] ([id_loaiphong])
GO
ALTER TABLE [dbo].[phong] CHECK CONSTRAINT [fk_loaiphong]
GO
ALTER TABLE [dbo].[phong]  WITH CHECK ADD  CONSTRAINT [fk_tang] FOREIGN KEY([id_tang])
REFERENCES [dbo].[tang] ([id_tang])
GO
ALTER TABLE [dbo].[phong] CHECK CONSTRAINT [fk_tang]
GO
ALTER TABLE [dbo].[taikhoan]  WITH CHECK ADD FOREIGN KEY([id_nhanvien])
REFERENCES [dbo].[nhanvien] ([id_nhanvien])
GO
/****** Object:  StoredProcedure [dbo].[Capnhat_chi_tiet_su_dung_dv]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Capnhat_chi_tiet_su_dung_dv]  
    @iddatphong NVARCHAR(50),
    @iddv NVARCHAR(50),
    @soluong INT
AS
BEGIN
    UPDATE chitietsudungdv 
    SET 
        so_luong = @soluong,
        tong_tien_dv = (
            (SELECT gia FROM dichvu WHERE id_dichvu = @iddv) * @soluong
        )
    WHERE 
        id_dichvu = @iddv AND 
        id_datphong = @iddatphong;
END;
GO
/****** Object:  StoredProcedure [dbo].[Capnhat_chi_tiet_su_dung_tb]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Capnhat_chi_tiet_su_dung_tb]  
    @iddatphong NVARCHAR(50),
    @idtb NVARCHAR(50),
    @soluong INT
AS
BEGIN
    UPDATE chitietsudungtb
    SET 
        so_luong = @soluong,
        tong_tien_tb = (
            (SELECT gia FROM thietbi WHERE id_thietbi = @idtb) * @soluong
        )
    WHERE 
        id_thietbi = @idtb AND 
        id_datphong = @iddatphong;
END;
GO
/****** Object:  StoredProcedure [dbo].[Dat_Phong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC Them_Phong 1, 1, N'Phòng tầng 1', 1
--SELECT * FROM phong
--delete phong where id_phong = 'P019'


--Thêm đặt phòng tăng tự động
CREATE PROCEDURE [dbo].[Dat_Phong]
	  @id_nhanvien VARCHAR(5),
	  @id_khachhang VARCHAR(5),
	  @id_phong VARCHAR(5),
	  @check_in datetime,
	  @check_out datetime,
	  @so_nguoi_o int,
	  @loai NVARCHAR(20),
	  @dat_coc FLOAT
AS
BEGIN
    DECLARE @id_datphong VARCHAR(10)
    DECLARE @id_datphong_max VARCHAR(10)
    SELECT @id_datphong_max = MAX(id_datphong) FROM datphong
    IF @id_datphong_max IS NULL
        SET @id_datphong = 'HD001'
    ELSE
        SET @id_datphong = 'HD' + RIGHT('000' + CAST(RIGHT(@id_datphong_max, 3) + 1 AS VARCHAR(3)), 3)
    
	INSERT INTO datphong(id_datphong, id_nhanvien, id_khachhang, id_phong, check_in, check_out, so_nguoi_o, loai, dat_coc, phu_thu_checkin, phu_thu_checkout, tong_tien)
	VALUES(@id_datphong, @id_nhanvien, @id_khachhang, @id_phong, @check_in, @check_out, @so_nguoi_o, @loai, @dat_coc, 0, 0, 0)
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_chi_tiet_su_dung_dv]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-------------------------------------------------------------------------------------------------------------------------------------



CREATE PROCEDURE [dbo].[Them_chi_tiet_su_dung_dv] 
(
	@id_datphong VARCHAR(10),
	@id_dvu VARCHAR(10), 
	@ngaythue DATE,
    @so_luong INT
)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT * FROM chitietsudungdv WHERE id_dichvu = @id_dvu AND id_datphong = @id_datphong)
    BEGIN
        UPDATE chitietsudungdv 
        SET so_luong = so_luong + @so_luong , tong_tien_dv =((select tong_tien_dv from chitietsudungdv where id_dichvu = @id_dvu) + ((select gia from dichvu where id_dichvu = @id_dvu) * @so_luong) )
        WHERE id_dichvu = @id_dvu AND id_datphong = @id_datphong
    END
    ELSE
    BEGIN
        --INSERT INTO chitietsudungdv (id_dv, id_kh, so_luong) 
        --VALUES (@id_dv, @id_kh, @so_luong)
		insert into chitietsudungdv 
		values (@id_datphong, @id_dvu, @ngaythue, @so_luong, ((select gia from dichvu where id_dichvu = @id_dvu) * @so_luong))
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_chi_tiet_su_dung_tb]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC Them_chi_tiet_su_dung_dv 'HD009', 'DV001', '2023-05-28', 1

--select * from chitietsudungdv
--select * from dichvu
--select * from datphong
--delete from chitietsudungdv where id_datphong = 'HD002' and id_dichvu = 'DV001'


CREATE PROCEDURE [dbo].[Them_chi_tiet_su_dung_tb] 
(
	@id_datphong VARCHAR(5),
	@id_tbi VARCHAR(5), 
	@ngaythue DATE,
    @so_luong INT
)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT * FROM chitietsudungtb WHERE id_thietbi = @id_tbi AND id_datphong = @id_datphong)
    BEGIN
        UPDATE chitietsudungtb 
        SET so_luong = so_luong + @so_luong , tong_tien_tb =((select tong_tien_tb from chitietsudungtb where id_thietbi = @id_tbi) + ((select gia from thietbi where id_thietbi = @id_tbi) * @so_luong) )
        WHERE id_thietbi = @id_tbi AND id_datphong = @id_datphong
    END
    ELSE
    BEGIN
        --INSERT INTO chitietsudungdv (id_dv, id_kh, so_luong) 
        --VALUES (@id_dv, @id_kh, @so_luong)
		insert into chitietsudungtb
		values (@id_datphong, @id_tbi, @ngaythue, @so_luong, ((select gia from thietbi where id_thietbi = @id_tbi) * @so_luong))
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_Dich_Vu]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC Them_Thiet_Bi N'Mì gói', 3000
--SELECT * FROM thietbi

--------------------
--Thêm dịch vụ, tự động thêm mã dịch vụ (tự tăng)
CREATE PROCEDURE [dbo].[Them_Dich_Vu]
	@ten_dichvu NVARCHAR(50),
	@gia INT
AS
BEGIN
    DECLARE @id_dichvu NVARCHAR(10)
    DECLARE @id_dichvu_max NVARCHAR(10)
    SELECT @id_dichvu_max = MAX(id_dichvu) FROM dichvu
    IF @id_dichvu_max IS NULL
        SET @id_dichvu = 'DV001'
    ELSE
        SET @id_dichvu = 'DV' + RIGHT('000' + CAST(RIGHT(@id_dichvu_max, 3) + 1 AS VARCHAR(3)), 3)
    
    INSERT INTO dichvu(id_dichvu, ten_dichvu, gia)
	VALUES(@id_dichvu, @ten_dichvu, @gia)
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_Khach_Hang]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC Them_Dich_Vu N'Thuê xe', 100000
--SELECT * FROM dichvu

--------------------
--Thêm khách hàng, tự động thêm mã khách hàng (tự tăng)
CREATE PROCEDURE [dbo].[Them_Khach_Hang]
	@ten_khachhang NVARCHAR(50),
	@ngay_sinh DATE,
	@dia_chi NVARCHAR(100),
	@sdt VARCHAR(15),
	@cmnd VARCHAR(15),
	@gioi_tinh NVARCHAR(6)
AS
BEGIN
    DECLARE @id_khachhang NVARCHAR(10)
    DECLARE @id_khachhang_max NVARCHAR(10)
    SELECT @id_khachhang_max = MAX(id_khachhang) FROM khachhang
    IF @id_khachhang_max IS NULL
        SET @id_khachhang = 'KH001'
    ELSE
        SET @id_khachhang = 'KH' + RIGHT('000' + CAST(RIGHT(@id_khachhang_max, 3) + 1 AS VARCHAR(3)), 3)
    
    INSERT INTO khachhang(id_khachhang, ten_khachhang, ngay_sinh, dia_chi, sdt, cmnd, gioi_tinh)
	VALUES(@id_khachhang, @ten_khachhang, @ngay_sinh, @dia_chi, @sdt, @cmnd, @gioi_tinh)
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_Nhan_Vien]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Them_Nhan_Vien]
	@ten_nhanvien NVARCHAR(100),
	@ngay_sinh DATE,
	@sdt VARCHAR(10),
	@gioi_tinh NVARCHAR(6),
	@email VARCHAR(50)
AS
BEGIN
    DECLARE @Ma_NV NVARCHAR(10)
    DECLARE @Max_Ma_NV NVARCHAR(10)
    SELECT @Max_Ma_NV = MAX(id_nhanvien) FROM nhanvien
    IF @Max_Ma_NV IS NULL
        SET @Ma_NV = 'NV001'
    ELSE
        SET @Ma_NV = 'NV' + RIGHT('000' + CAST(RIGHT(@Max_Ma_NV, 3) + 1 AS VARCHAR(3)), 3)
    
    INSERT INTO nhanvien(id_nhanvien, ten_nhanvien, ngay_sinh, sdt, gioi_tinh, email)
	VALUES(@Ma_NV, @ten_nhanvien, @ngay_sinh, @sdt, @gioi_tinh, @email)
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_Phong]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SELECT * FROM khachhang

--------------------
--Thêm loại phòng tăng tự động
--CREATE PROCEDURE Them_Loai_Phong
--	  @ten_loai NVARCHAR(50),
--	  @gia INT
--AS
--BEGIN
--	DECLARE @id_loaiphong INT
--	DECLARE @id_loaiphong_max INT
--	SELECT @id_loaiphong_max = MAX(id_loaiphong) FROM loaiphong
--	IF @id_loaiphong_max IS NULL
--		SET @id_loaiphong = 1
--	ELSE
--		SET @id_loaiphong = @id_loaiphong_max + 1

--	INSERT INTO loaiphong(id_loaiphong, ten_loai, gia)
--	VALUES(@id_loaiphong, @ten_loai, @gia)
--END;
--GO
--EXEC Them_Loai_Phong N'Loại gì đó', 156000
--SELECT * FROM loaiphong

--------------------
--Thêm phòng tăng tự động
CREATE PROCEDURE [dbo].[Them_Phong]
	  @id_loaiphong INT,
	  @id_tang INT,
	  @ten NVARCHAR(50),
	  @trangthai NVARCHAR(50),
	  @gia INT
AS
BEGIN
    DECLARE @id_phong VARCHAR(10)
    DECLARE @id_phong_max NVARCHAR(10)
    SELECT @id_phong_max = MAX(id_phong) FROM phong
    IF @id_phong_max IS NULL
        SET @id_phong = 'P001'
    ELSE
        SET @id_phong = 'P' + RIGHT('000' + CAST(RIGHT(@id_phong_max, 3) + 1 AS VARCHAR(3)), 3)
    
    INSERT INTO phong(id_phong, id_loaiphong, id_tang, ten, trang_thai, gia)
	VALUES(@id_phong, @id_loaiphong, @id_tang, @ten, @trangthai, @gia)
END;
GO
/****** Object:  StoredProcedure [dbo].[Them_Thiet_Bi]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Thêm nhân viên, tự động thêm mã nhân viên (tự tăng)
--CREATE PROCEDURE Them_Nhan_Vien

--	@ten_nhanvien NVARCHAR(100),
--	@ngay_sinh DATE,
--	@sdt VARCHAR(10),
--	@gioi_tinh NVARCHAR(6),
--	@email VARCHAR(50),
--	@hinh_anh VARCHAR(100),
--	@ten_dang_nhap VARCHAR(50),
--	@mat_khau VARCHAR(50),
--	@quyen INT
--AS
--BEGIN
--    DECLARE @Ma_NV NVARCHAR(10)
--    DECLARE @Max_Ma_NV NVARCHAR(10)
--    SELECT @Max_Ma_NV = MAX(id_nhanvien) FROM nhanvien
--    IF @Max_Ma_NV IS NULL
--        SET @Ma_NV = 'NV001'
--    ELSE
--        SET @Ma_NV = 'NV' + RIGHT('000' + CAST(RIGHT(@Max_Ma_NV, 3) + 1 AS VARCHAR(3)), 3)
    
--    INSERT INTO nhanvien(id_nhanvien, ten_nhanvien, ngay_sinh, sdt, gioi_tinh, email, hinh_anh, ten_dang_nhap, mat_khau, quyen)
--	VALUES(@Ma_NV, @ten_nhanvien, @ngay_sinh, @sdt, @gioi_tinh, @email, @hinh_anh, @ten_dang_nhap, @mat_khau, @quyen)
--END;
--GO
--set dateformat dmy EXEC Them_Nhan_Vien N'Huỳnh Khánh Duy', '27-03-2002', '0123456789', N'Nam', 'duy@gmail.com', '', 'duy', '123', 0
--SELECT * FROM nhanvien

--------------------
--Thêm thiết bị, tự động thêm mã thiết bị (tự tăng)
CREATE PROCEDURE [dbo].[Them_Thiet_Bi]
	@ten_thietbi NVARCHAR(50),
	@gia INT
AS
BEGIN
    DECLARE @id_thietbi NVARCHAR(10)
    DECLARE @id_thietbi_max NVARCHAR(10)
    SELECT @id_thietbi_max = MAX(id_thietbi) FROM thietbi
    IF @id_thietbi_max IS NULL
        SET @id_thietbi = 'TB001'
    ELSE
        SET @id_thietbi = 'TB' + RIGHT('000' + CAST(RIGHT(@id_thietbi_max, 3) + 1 AS VARCHAR(3)), 3)
    
    INSERT INTO thietbi(id_thietbi, ten_thietbi, gia)
	VALUES(@id_thietbi, @ten_thietbi, @gia)
END;
GO
/****** Object:  StoredProcedure [dbo].[Tinh_Tong_Tien_DichVu]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Tinh_Tong_Tien_DichVu]
    @id_datphong VARCHAR(5),
    @tong_tien_dv FLOAT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem có id_datphong nào trong bảng chitietsudungdv không
    IF EXISTS (SELECT 1 FROM chitietsudungdv WHERE id_datphong = @id_datphong)
    BEGIN
        -- Tính tổng tiền dịch vụ nếu có id_datphong
        SELECT @tong_tien_dv = SUM(tong_tien_dv)
        FROM chitietsudungdv
        WHERE id_datphong = @id_datphong;
    END
    ELSE
    BEGIN
        -- Gán tổng tiền dịch vụ = 0 nếu không có id_datphong
        SET @tong_tien_dv = 0;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Tinh_Tong_Tien_Phuthu]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--SELECT id_datphong, ten, ten_nhanvien, ten_khachhang, loai, check_in, check_out, tong_thoi_gian, trang_thai FROM view_datphong2 
--where id = N'Phòng 101' AND ten_khachhang = N''
--GO

--CREATE FUNCTION tinh_tong_tien(@id_datphong VARCHAR(5))
--RETURNS FLOAT
--AS BEGIN
--    DECLARE @tong_tien FLOAT;
--    SELECT @tong_tien = DATEDIFF(day, check_in, ISNULL(check_out, GETDATE())) * loaiphong.gia
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--    RETURN @tong_tien;
--END;
--GO

--SELECT dbo.tinh_tong_tien('HD001');
--select * from phong
--select * from loaiphong;
--select * from datphong;
--select id_datphong from datphong where id_phong = ''


--CREATE FUNCTION tinh_tong_tien_co_phu_thu(@id_datphong VARCHAR(5))
--RETURNS FLOAT
--AS BEGIN
--    DECLARE @tong_tien FLOAT, @so_ngay INT;
--    SELECT @so_ngay = DATEDIFF(day, check_in, ISNULL(check_out, GETDATE()))
--    FROM datphong
--    WHERE id_datphong = @id_datphong;
--    SELECT @tong_tien = @so_ngay * loaiphong.gia
--        + CASE WHEN DATEPART(hour, check_in) < 13 THEN 0.3 * loaiphong.gia ELSE 0 END
--        + CASE WHEN DATEPART(hour, check_out) > 11 THEN 0.3 * loaiphong.gia ELSE 0 END

--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;

--    RETURN @tong_tien;
--END;
--GO

--SELECT DATEPART(HOUR, check_in) FROM datphong
--SELECT DATEPART(HOUR, check_out) FROM datphong
--select * from datphong;
--SELECT dbo.tinh_tong_tien('HD002');
--SELECT dbo.tinh_tong_tien_co_phu_thu('HD002');



--CREATE FUNCTION tinh_tong_tien1(@id_datphong VARCHAR(5))
--RETURNS FLOAT
--AS BEGIN
--    DECLARE @tong_tien FLOAT;
--    DECLARE @phuthu FLOAT;
--	DECLARE @phuthu1 FLOAT;
--    DECLARE @checkin DATETIME;
--	DECLARE @checkout DATETIME;
--    SELECT @checkin = check_in FROM datphong WHERE id_datphong = @id_datphong;
--	SELECT @checkout = check_out FROM datphong WHERE id_datphong = @id_datphong;
--    SELECT @phuthu = 
--        CASE 
--            WHEN DATEPART(hour, @checkin) < 4 THEN 1
--            WHEN DATEPART(hour, @checkin) < 7 THEN 0.5
--            WHEN DATEPART(hour, @checkin) < 13 THEN 0.3
--            ELSE 0
--        END
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--	SELECT @phuthu1 = 
--        CASE 
--            WHEN DATEPART(hour, @checkout) > 23 THEN 1
--            WHEN DATEPART(hour, @checkout) > 18 THEN 0.5
--            WHEN DATEPART(hour, @checkout) > 11 THEN 0.3
--            ELSE 0
--        END
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--    SELECT @tong_tien = DATEDIFF(day, check_in, check_out) * loaiphong.gia + loaiphong.gia * @phuthu + loaiphong.gia * @phuthu1
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--    RETURN @tong_tien;
--END;
--GO

----SELECT dbo.tinh_tong_tien('HD002');
----SELECT dbo.tinh_tong_tien1('HD002');




--CREATE PROCEDURE Tinh_Tong_Tien_Phuthu
--    @id_datphong VARCHAR(5),
--    @tong_tien FLOAT OUTPUT,
--	@tien_phuthu FLOAT OUTPUT,
--    @tien_phuthu1 FLOAT OUTPUT
--AS 
--BEGIN
--	DECLARE @phuthu FLOAT;
--	DECLARE @phuthu1 FLOAT;
--    DECLARE @checkin DATETIME;
--    DECLARE @checkout DATETIME;
--    SELECT @checkin = check_in FROM datphong WHERE id_datphong = @id_datphong;
--    SELECT @checkout = check_out FROM datphong WHERE id_datphong = @id_datphong;
--    SELECT @phuthu = 
--        CASE 
--            WHEN DATEPART(hour, @checkin) < 4 THEN 1
--            WHEN DATEPART(hour, @checkin) < 7 THEN 0.5
--            WHEN DATEPART(hour, @checkin) < 13 THEN 0.3
--            ELSE 0
--        END
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--    SELECT @phuthu1 = 
--        CASE 
--            WHEN DATEPART(hour, @checkout) > 23 THEN 1
--            WHEN DATEPART(hour, @checkout) > 18 THEN 0.5
--            WHEN DATEPART(hour, @checkout) > 11 THEN 0.3
--            ELSE 0
--        END
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--    SELECT @tong_tien = DATEDIFF(day, check_in, check_out) * loaiphong.gia + loaiphong.gia * @phuthu + loaiphong.gia * @phuthu1
--	, @tien_phuthu = loaiphong.gia * @phuthu, @tien_phuthu1 = loaiphong.gia * @phuthu1
--    FROM datphong
--    INNER JOIN phong ON datphong.id_phong = phong.id_phong
--    INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--    WHERE id_datphong = @id_datphong;
--END;
--GO




--CREATE PROCEDURE Tinh_Tong_Tien_Phuthu_1  --Java--
--	@mychoose nvarchar(30),
--    @id_datphong VARCHAR(5),
--    @tong_tien FLOAT OUTPUT,
--	@tien_phuthu FLOAT OUTPUT,
--    @tien_phuthu1 FLOAT OUTPUT
--AS 
--BEGIN
--	IF (@mychoose LIKE N'Theo ngày')
--		BEGIN
--			DECLARE @phuthu FLOAT;
--			DECLARE @phuthu1 FLOAT;
--			DECLARE @checkin DATETIME;
--			DECLARE @checkout DATETIME;
--			SELECT @checkin = check_in FROM datphong WHERE id_datphong = @id_datphong;
--			SELECT @checkout = check_out FROM datphong WHERE id_datphong = @id_datphong;
--			SELECT @phuthu = 
--				CASE 
--					WHEN DATEPART(hour, @checkin) < 4 THEN 1
--					WHEN DATEPART(hour, @checkin) < 7 THEN 0.5
--					WHEN DATEPART(hour, @checkin) < 13 THEN 0.3
--					ELSE 0
--				END
--			FROM datphong
--			INNER JOIN phong ON datphong.id_phong = phong.id_phong
--			INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--			WHERE id_datphong = @id_datphong;
--			SELECT @phuthu1 = 
--				CASE 
--					WHEN DATEPART(hour, @checkout) > 23 THEN 1
--					WHEN DATEPART(hour, @checkout) > 18 THEN 0.5
--					WHEN DATEPART(hour, @checkout) > 11 THEN 0.3
--					ELSE 0
--				END
--			FROM datphong
--			INNER JOIN phong ON datphong.id_phong = phong.id_phong
--			INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--			WHERE id_datphong = @id_datphong;
--			SELECT @tong_tien = DATEDIFF(day, check_in, check_out) * loaiphong.gia + loaiphong.gia * @phuthu + loaiphong.gia * @phuthu1
--			, @tien_phuthu = loaiphong.gia * @phuthu, @tien_phuthu1 = loaiphong.gia * @phuthu1
--			FROM datphong
--			INNER JOIN phong ON datphong.id_phong = phong.id_phong
--			INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
--			WHERE id_datphong = @id_datphong;
--				END
--	ELSE IF (@mychoose LIKE N'Theo giờ')
--		BEGIN
--			DECLARE @checkin1 DATETIME;
--			DECLARE @checkout1 DATETIME;
--			SELECT @checkin1 = check_in FROM datphong WHERE id_datphong = @id_datphong;
--			SELECT @checkout1 = check_out FROM datphong WHERE id_datphong = @id_datphong;
--			SET @phuthu = 0.0;
--			SET @phuthu1 = 0.0;
--			SELECT @tong_tien = DATEDIFF(HOUR, @checkin1, @checkout1) * 50000
--			FROM datphong
--			WHERE id_datphong = @id_datphong;
--		END
--END;
--GO


--DECLARE @tong_tien FLOAT;
--DECLARE @tien_phuthu FLOAT;
--DECLARE @tien_phuthu1 FLOAT;
--EXEC Tinh_Tong_Tien_Phuthu_1 N'Theo giờ', 'HD002', @tong_tien OUTPUT, @tien_phuthu OUTPUT, @tien_phuthu1 OUTPUT;
--SELECT @tong_tien AS tong_tien, @tien_phuthu AS tien_phuthu_checkin, @tien_phuthu1 AS tien_phuthu_checkout;




CREATE PROCEDURE [dbo].[Tinh_Tong_Tien_Phuthu]  --c#--
	@mychoose NVARCHAR(30),
    @id_datphong VARCHAR(5),
    @tong_tien FLOAT OUTPUT,
	@tien_phuthu FLOAT OUTPUT,
    @tien_phuthu1 FLOAT OUTPUT
AS 
BEGIN
	IF (@mychoose LIKE N'Theo ngày')
	BEGIN
		DECLARE @phuthu FLOAT;
		DECLARE @phuthu1 FLOAT;
		DECLARE @checkin DATETIME;
		DECLARE @checkout DATETIME;

		SELECT @checkin = check_in, @checkout = check_out
		FROM datphong
		WHERE id_datphong = @id_datphong;

		SELECT @phuthu = 
			CASE 
				WHEN DATEPART(hour, @checkin) < 4 THEN 1
				WHEN DATEPART(hour, @checkin) < 7 THEN 0.5
				WHEN DATEPART(hour, @checkin) < 13 THEN 0.3
				ELSE 0
			END;

		SELECT @phuthu1 = 
			CASE 
				WHEN DATEPART(hour, @checkout) > 23 THEN 1
				WHEN DATEPART(hour, @checkout) > 18 THEN 0.5
				WHEN DATEPART(hour, @checkout) > 11 THEN 0.3
				ELSE 0
			END;

		SELECT 
			@tong_tien = DATEDIFF(day, @checkin, @checkout) * phong.gia + phong.gia * @phuthu + phong.gia * @phuthu1,
			@tien_phuthu = phong.gia * @phuthu,
			@tien_phuthu1 = phong.gia * @phuthu1
		FROM datphong
		INNER JOIN phong ON datphong.id_phong = phong.id_phong
		INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
		WHERE id_datphong = @id_datphong;
	END
	ELSE IF (@mychoose LIKE N'Theo giờ')
	BEGIN
		DECLARE @checkin1 DATETIME;
		DECLARE @checkout1 DATETIME;

		SELECT @checkin1 = check_in, @checkout1 = check_out
		FROM datphong
		WHERE id_datphong = @id_datphong;

		SET @phuthu = 0.0;
		SET @phuthu1 = 0.0;

		SELECT @tong_tien = DATEDIFF(HOUR, @checkin1, @checkout1) * phong.gia
		FROM datphong
		INNER JOIN phong ON datphong.id_phong = phong.id_phong
		INNER JOIN loaiphong ON phong.id_loaiphong = loaiphong.id_loaiphong
		WHERE id_datphong = @id_datphong;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[Tinh_Tong_Tien_ThietBi]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Tinh_Tong_Tien_ThietBi]
    @id_datphong VARCHAR(5),
    @tong_tien_tb FLOAT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem có id_datphong nào trong bảng chitietsudungdv không
    IF EXISTS (SELECT 1 FROM chitietsudungtb WHERE id_datphong = @id_datphong)
    BEGIN
        -- Tính tổng tiền dịch vụ nếu có id_datphong
        SELECT @tong_tien_tb = SUM(tong_tien_tb)
        FROM chitietsudungtb
        WHERE id_datphong = @id_datphong;
    END
    ELSE
    BEGIN
        -- Gán tổng tiền dịch vụ = 0 nếu không có id_datphong
        SET @tong_tien_tb = 0;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Update_TrangThaiPhong_1]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--set dateformat dmy
--set dateformat dmy EXEC Dat_Phong 'NV001', 'KH002', 'P004', '06/05/2023 08:22:26', '12/05/2023 08:22:26', 1, N'Theo ngày', 150000 
--update phong set trang_thai = N'Đang sử dụng' where id_phong = 'P004'
--delete from datphong where id_datphong = 'HD001'
--update phong set trang_thai = N'Còn trống'
--SELECT * FROM datphong
--select * from phong


--Cập nhật trạng thái phòng
CREATE PROC [dbo].[Update_TrangThaiPhong_1] @idphong NVARCHAR(100)
AS
UPDATE phong 
SET trang_thai = N'Đang sử dụng'
WHERE id_phong = @idphong;
GO
/****** Object:  StoredProcedure [dbo].[Xoa_chi_tiet_su_dung_dv]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC Them_chi_tiet_su_dung_tb 'HD001', 'TB001', '08/05/2023', 1

--select * from chitietsudungtb
--select * from thietbi
--select * from datphong
--delete from chitietsudungtb where id_datphong = 'HD001' and id_thietbi = 'TB001'


CREATE PROC [dbo].[Xoa_chi_tiet_su_dung_dv]  @iddatphong NVARCHAR(50), @iddv NVARCHAR(50)
AS
DELETE chitietsudungdv 
WHERE id_datphong = @iddatphong and id_dichvu = @iddv;
GO
/****** Object:  StoredProcedure [dbo].[Xoa_chi_tiet_su_dung_tb]    Script Date: 10/12/2023 10:36:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Xoa_chi_tiet_su_dung_tb]  @iddatphong NVARCHAR(50), @idtb NVARCHAR(50)
AS
DELETE chitietsudungtb
WHERE id_datphong = @iddatphong and id_thietbi = @idtb;
GO
USE [master]
GO
ALTER DATABASE [QLKS] SET  READ_WRITE 
GO
