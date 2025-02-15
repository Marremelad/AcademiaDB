USE [master]
GO
/****** Object:  Database [AcademiaDB]    Script Date: 2025-01-05 15:35:38 ******/
CREATE DATABASE [AcademiaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcademiaDB', FILENAME = N'C:\Users\Corte\AcademiaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcademiaDB_log', FILENAME = N'C:\Users\Corte\AcademiaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcademiaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcademiaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcademiaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcademiaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcademiaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcademiaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcademiaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcademiaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AcademiaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcademiaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcademiaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcademiaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcademiaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcademiaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcademiaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcademiaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcademiaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AcademiaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcademiaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcademiaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcademiaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcademiaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcademiaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AcademiaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcademiaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AcademiaDB] SET  MULTI_USER 
GO
ALTER DATABASE [AcademiaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcademiaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcademiaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcademiaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AcademiaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcademiaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AcademiaDB] SET QUERY_STORE = OFF
GO
USE [AcademiaDB]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentFirstName] [nvarchar](35) NOT NULL,
	[StudentLastName] [nvarchar](35) NOT NULL,
	[StudentSSN] [varchar](13) NOT NULL,
	[ClassID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseEnrolments]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseEnrolments](
	[EnrolmentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID_FK] [int] NOT NULL,
	[CourseID_FK] [int] NOT NULL,
	[Grade] [char](1) NULL,
	[GradeSetter_FK] [int] NULL,
	[GradingDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrolmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TopGrades]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TopGrades] AS
    SELECT 
        StudentFirstName + ' ' + StudentLastName AS Name,
        Grade        
    FROM CourseEnrolments
JOIN Students ON Students.StudentID = CourseEnrolments.StudentID_FK
WHERE Grade = 'A'
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](35) NOT NULL,
	[EmployeeID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseAssignments]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignments](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID_FK] [int] NOT NULL,
	[CourseID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](35) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeFirstName] [nvarchar](35) NOT NULL,
	[EmployeeLastName] [nvarchar](35) NOT NULL,
	[EmployeeSSN] [char](13) NOT NULL,
	[EmployeeStartDate] [date] NOT NULL,
	[EmployeeSalary] [money] NOT NULL,
	[DepartmentID_FK] [int] NOT NULL,
	[RoleID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2025-01-05 15:35:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](35) NOT NULL,
	[DepartmentID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassID], [ClassName], [EmployeeID_FK]) VALUES (1, N'Class A1', 12)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [EmployeeID_FK]) VALUES (2, N'Class B2', 13)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [EmployeeID_FK]) VALUES (3, N'Class C3', 14)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [EmployeeID_FK]) VALUES (4, N'Class D4', 15)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [EmployeeID_FK]) VALUES (5, N'Class E5', 16)
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseAssignments] ON 

INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (1, 3, 1)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (2, 5, 1)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (3, 2, 2)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (4, 10, 2)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (5, 7, 3)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (6, 8, 3)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (7, 3, 4)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (8, 11, 4)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (9, 9, 5)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [EmployeeID_FK], [CourseID_FK]) VALUES (10, 7, 5)
SET IDENTITY_INSERT [dbo].[CourseAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseEnrolments] ON 

INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (1, 1, 1, N'A', 3, CAST(N'2025-01-05' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (2, 2, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (3, 3, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (4, 4, 1, N'D', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (5, 5, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (6, 6, 1, N'F', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (7, 7, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (8, 8, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (9, 9, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (10, 10, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (11, 11, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (12, 12, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (13, 13, 1, N'F', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (14, 14, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (15, 15, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (16, 16, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (17, 17, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (18, 18, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (19, 19, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (20, 20, 1, N'F', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (21, 21, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (22, 22, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (23, 23, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (24, 24, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (25, 25, 1, N'D', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (26, 26, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (27, 27, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (28, 28, 1, N'A', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (29, 29, 1, N'C', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (30, 30, 1, N'B', 3, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (31, 31, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (32, 32, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (33, 33, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (34, 34, 5, N'D', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (35, 35, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (36, 36, 5, N'F', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (37, 37, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (38, 38, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (39, 39, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (40, 40, 5, N'D', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (41, 41, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (42, 42, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (43, 43, 5, N'F', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (44, 44, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (45, 45, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (46, 46, 5, N'E', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (47, 47, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (48, 48, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (49, 49, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (50, 50, 5, N'F', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (51, 51, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (52, 52, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (53, 53, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (54, 54, 5, N'D', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (55, 55, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (56, 56, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (57, 57, 5, N'E', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (58, 58, 5, N'A', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (59, 59, 5, N'C', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (60, 60, 5, N'B', 9, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (61, 61, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (62, 62, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (63, 63, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (64, 64, 3, N'D', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (65, 65, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (66, 66, 3, N'F', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (67, 67, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (68, 68, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (69, 69, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (70, 70, 3, N'D', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (71, 71, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (72, 72, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (73, 73, 3, N'F', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (74, 74, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (75, 75, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (76, 76, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (77, 77, 3, N'E', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (78, 78, 3, N'D', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (79, 79, 3, N'F', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (80, 80, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (81, 81, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (82, 82, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (83, 83, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (84, 84, 3, N'D', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (85, 85, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (86, 86, 3, N'E', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (87, 87, 3, N'C', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (88, 88, 3, N'A', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (89, 89, 3, N'F', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (90, 90, 3, N'B', 8, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (91, 91, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (92, 92, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (93, 93, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (94, 94, 4, N'D', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (95, 95, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (96, 96, 4, N'F', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (97, 97, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (98, 98, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (99, 99, 4, N'E', 11, CAST(N'2024-12-29' AS Date))
GO
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (100, 100, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (101, 101, 4, N'D', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (102, 102, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (103, 103, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (104, 104, 4, N'F', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (105, 105, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (106, 106, 4, N'E', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (107, 107, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (108, 108, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (109, 109, 4, N'D', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (110, 110, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (111, 111, 4, N'F', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (112, 112, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (113, 113, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (114, 114, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (115, 115, 4, N'D', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (116, 116, 4, N'E', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (117, 117, 4, N'A', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (118, 118, 4, N'C', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (119, 119, 4, N'B', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (120, 120, 4, N'F', 11, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (121, 121, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (122, 122, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (123, 123, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (124, 124, 2, N'F', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (125, 125, 2, N'E', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (126, 126, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (127, 127, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (128, 128, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (129, 129, 2, N'D', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (130, 130, 2, N'F', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (131, 131, 2, N'E', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (132, 132, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (133, 133, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (134, 134, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (135, 135, 2, N'D', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (136, 136, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (137, 137, 2, N'F', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (138, 138, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (139, 139, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (140, 140, 2, N'E', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (141, 141, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (142, 142, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (143, 143, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (144, 144, 2, N'D', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (145, 145, 2, N'E', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (146, 146, 2, N'F', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (147, 147, 2, N'A', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (148, 148, 2, N'C', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (149, 149, 2, N'B', 2, CAST(N'2024-12-29' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (150, 150, 2, N'D', 2, CAST(N'2024-12-29' AS Date))
SET IDENTITY_INSERT [dbo].[CourseEnrolments] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [CourseName], [Active]) VALUES (1, N'Mathematics 101', 1)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [Active]) VALUES (2, N'Introduction to Biology', 1)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [Active]) VALUES (3, N'History of Civilizations', 1)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [Active]) VALUES (4, N'English Literature', 1)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [Active]) VALUES (5, N'Computer Science Basics', 1)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (1, N'Education')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (2, N'Administration')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (3, N'Maintenance')
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName]) VALUES (4, N'Security')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (1, N'David', N'Johnson', N'19640317-1122', CAST(N'2001-04-10' AS Date), 80000.0000, 1, 1)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (2, N'Sophia', N'Martinez', N'19850215-2231', CAST(N'2017-03-01' AS Date), 34000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (3, N'James', N'Taylor', N'19910322-3342', CAST(N'2020-05-15' AS Date), 36000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (4, N'Olivia', N'Williams', N'19870410-4457', CAST(N'2018-09-01' AS Date), 33000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (5, N'Ethan', N'Brown', N'19920405-5561', CAST(N'2019-02-01' AS Date), 35000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (6, N'Charlotte', N'Davis', N'19810925-6671', CAST(N'2016-07-15' AS Date), 37500.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (7, N'Benjamin', N'Miller', N'19830114-7781', CAST(N'2021-11-01' AS Date), 38000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (8, N'Amelia', N'Wilson', N'19950318-8891', CAST(N'2022-01-01' AS Date), 34000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (9, N'Lucas', N'Moore', N'19901211-9901', CAST(N'2020-08-01' AS Date), 35500.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (10, N'Isabella', N'Taylor', N'19890823-1231', CAST(N'2018-06-15' AS Date), 37000.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (11, N'Alexander', N'Clark', N'19940628-2341', CAST(N'2017-10-01' AS Date), 36500.0000, 1, 2)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (12, N'Michael', N'Roberts', N'19800719-2233', CAST(N'2015-03-01' AS Date), 55000.0000, 2, 3)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (13, N'James', N'Walker', N'19910124-3344', CAST(N'2018-06-15' AS Date), 52000.0000, 2, 3)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (14, N'Olivia', N'Morris', N'19851209-4455', CAST(N'2017-09-01' AS Date), 54000.0000, 2, 3)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (15, N'Isabella', N'Johnson', N'19760711-5566', CAST(N'2019-02-20' AS Date), 56000.0000, 2, 3)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (16, N'John', N'Clark', N'19830315-6677', CAST(N'2020-11-01' AS Date), 50000.0000, 2, 3)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (17, N'John', N'Smith', N'19830215-2233', CAST(N'2015-03-01' AS Date), 30000.0000, 3, 4)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (18, N'Olga', N'Kovács', N'19840125-3344', CAST(N'2016-06-10' AS Date), 29000.0000, 3, 4)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (19, N'Laura', N'Andersen', N'19910312-4455', CAST(N'2017-02-20' AS Date), 28000.0000, 3, 4)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (20, N'Martin', N'Meyer', N'19851208-5566', CAST(N'2018-09-01' AS Date), 31000.0000, 3, 4)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (21, N'Carlos', N'Fernandez', N'19860205-2233', CAST(N'2015-07-15' AS Date), 32000.0000, 4, 5)
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeeSSN], [EmployeeStartDate], [EmployeeSalary], [DepartmentID_FK], [RoleID_FK]) VALUES (22, N'Hannah', N'Lewis', N'19920118-3344', CAST(N'2017-11-01' AS Date), 31000.0000, 4, 5)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [DepartmentID_FK]) VALUES (1, N'Principal', 1)
INSERT [dbo].[Roles] ([RoleID], [RoleName], [DepartmentID_FK]) VALUES (2, N'Teacher', 1)
INSERT [dbo].[Roles] ([RoleID], [RoleName], [DepartmentID_FK]) VALUES (3, N'Administrator', 2)
INSERT [dbo].[Roles] ([RoleID], [RoleName], [DepartmentID_FK]) VALUES (4, N'Janitor', 3)
INSERT [dbo].[Roles] ([RoleID], [RoleName], [DepartmentID_FK]) VALUES (5, N'Security', 4)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (1, N'Sophia', N'Johnson', N'20050512-0011', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (2, N'Liam', N'Smith', N'20050523-0022', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (3, N'Olivia', N'Brown', N'20050614-0033', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (4, N'Noah', N'Williams', N'20050725-0044', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (5, N'Emma', N'Jones', N'20050816-0055', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (6, N'James', N'Garcia', N'20050907-0066', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (7, N'Isabella', N'Martinez', N'20051018-0077', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (8, N'Benjamin', N'Hernandez', N'20051129-0088', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (9, N'Mia', N'Lopez', N'20051210-0099', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (10, N'Lucas', N'Gonzalez', N'20051321-0101', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (11, N'Charlotte', N'Perez', N'20051402-0112', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (12, N'Elijah', N'Wilson', N'20051513-0123', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (13, N'Amelia', N'Anderson', N'20051624-0134', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (14, N'Alexander', N'Thomas', N'20051705-0145', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (15, N'Harper', N'Taylor', N'20051816-0156', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (16, N'Jack', N'Moore', N'20051927-0167', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (17, N'Evelyn', N'Jackson', N'20052008-0178', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (18, N'Aiden', N'White', N'20052119-0189', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (19, N'Abigail', N'Harris', N'20052230-0190', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (20, N'Mason', N'Martin', N'20052311-0201', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (21, N'Scarlett', N'Lee', N'20052422-0212', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (22, N'Henry', N'Young', N'20052503-0223', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (23, N'Grace', N'King', N'20052614-0234', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (24, N'Wyatt', N'Wright', N'20052725-0245', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (25, N'Ella', N'Lopez', N'20052806-0256', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (26, N'Sebastian', N'Hill', N'20052917-0267', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (27, N'Victoria', N'Scott', N'20053028-0278', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (28, N'Maverick', N'Adams', N'20053109-0289', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (29, N'Sophie', N'Baker', N'20053220-0290', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (30, N'Nathan', N'Davis', N'20053301-0301', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (31, N'Ethan', N'Brown', N'20050712-0012', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (32, N'Charlotte', N'Müller', N'20050823-0023', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (33, N'Jack', N'Lopez', N'20050914-0034', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (34, N'Amelia', N'Zhang', N'20051005-0045', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (35, N'Lucas', N'Martínez', N'20051116-0056', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (36, N'Grace', N'Hansen', N'20051207-0067', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (37, N'Benjamin', N'Nguyen', N'20051318-0078', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (38, N'Mia', N'Rossi', N'20051409-0089', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (39, N'Aiden', N'Schmidt', N'20051530-0090', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (40, N'Abigail', N'Santos', N'20051621-0102', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (41, N'Evelyn', N'Tanaka', N'20051712-0113', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (42, N'Sophie', N'Kovács', N'20051823-0124', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (43, N'Liam', N'Johnson', N'20051904-0135', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (44, N'Chloe', N'O’Connor', N'20052015-0146', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (45, N'Noah', N'Pérez', N'20052126-0157', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (46, N'Ella', N'Vega', N'20052207-0168', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (47, N'Henry', N'Patel', N'20052318-0179', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (48, N'Isabella', N'Dubois', N'20052409-0190', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (49, N'Leo', N'Garcia', N'20052530-0191', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (50, N'Scarlett', N'Ivanov', N'20052621-0202', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (51, N'Victoria', N'Lozano', N'20052702-0213', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (52, N'Mason', N'Martínez', N'20052813-0224', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (53, N'Ava', N'Klein', N'20052924-0235', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (54, N'Oliver', N'Wang', N'20053005-0246', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (55, N'James', N'Bauer', N'20053116-0257', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (56, N'Amelia', N'Takahashi', N'20053207-0268', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (57, N'Jack', N'Jensen', N'20053318-0279', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (58, N'Sophia', N'Novak', N'20053409-0290', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (59, N'Maverick', N'López', N'20053530-0291', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (60, N'Lena', N'Serrano', N'20053621-0302', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (61, N'Olivia', N'Smith', N'20051001-0012', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (62, N'Ethan', N'Jones', N'20051102-0023', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (63, N'Liam', N'Miller', N'20051203-0034', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (64, N'Charlotte', N'Davis', N'20051304-0045', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (65, N'Mason', N'Rodriguez', N'20051405-0056', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (66, N'Sophia', N'Martinez', N'20051506-0067', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (67, N'Benjamin', N'Garcia', N'20051607-0078', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (68, N'Isabella', N'Hernandez', N'20051708-0089', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (69, N'Aiden', N'Lopez', N'20051809-0100', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (70, N'Emma', N'Taylor', N'20051910-0102', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (71, N'Lucas', N'Wilson', N'20052011-0113', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (72, N'Amelia', N'Moore', N'20052112-0124', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (73, N'Henry', N'Jackson', N'20052213-0135', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (74, N'Evelyn', N'Martin', N'20052314-0146', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (75, N'James', N'Thompson', N'20052415-0157', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (76, N'Abigail', N'White', N'20052516-0168', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (77, N'Mia', N'Harris', N'20052617-0179', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (78, N'Noah', N'Clark', N'20052718-0190', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (79, N'Harper', N'Lewis', N'20052819-0201', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (80, N'Sebastian', N'Walker', N'20052920-0202', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (81, N'Grace', N'Hall', N'20053021-0213', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (82, N'Scarlett', N'Allen', N'20053122-0224', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (83, N'Luca', N'Young', N'20053223-0235', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (84, N'Ella', N'King', N'20053324-0246', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (85, N'Ava', N'Scott', N'20053425-0257', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (86, N'Wyatt', N'Green', N'20053526-0268', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (87, N'Victoria', N'Adams', N'20053627-0279', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (88, N'Jack', N'Baker', N'20053728-0289', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (89, N'Leo', N'Nelson', N'20053829-0290', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (90, N'Zoe', N'Roberts', N'20053930-0302', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (91, N'Jackson', N'Brown', N'20054001-0011', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (92, N'Amelia', N'Davis', N'20054102-0022', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (93, N'Liam', N'Hernandez', N'20054203-0033', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (94, N'Emma', N'Gonzalez', N'20054304-0044', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (95, N'Noah', N'Martinez', N'20054405-0055', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (96, N'Olivia', N'Taylor', N'20054506-0066', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (97, N'Aiden', N'Roberts', N'20054607-0077', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (98, N'Sophia', N'Lopez', N'20054708-0088', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (99, N'Ethan', N'Clark', N'20054809-0099', 4)
GO
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (100, N'Mia', N'Lewis', N'20054910-0101', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (101, N'Benjamin', N'Walker', N'20055011-0112', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (102, N'Charlotte', N'Young', N'20055112-0123', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (103, N'Isabella', N'Allen', N'20055213-0134', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (104, N'Lucas', N'Scott', N'20055314-0145', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (105, N'Grace', N'King', N'20055415-0156', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (106, N'Sebastian', N'Adams', N'20055516-0167', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (107, N'Scarlett', N'Nelson', N'20055617-0178', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (108, N'Ava', N'Roberts', N'20055718-0189', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (109, N'Wyatt', N'Baker', N'20055819-0190', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (110, N'Harper', N'Green', N'20055920-0201', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (111, N'Mason', N'Hall', N'20056021-0212', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (112, N'Victoria', N'Johnson', N'20056122-0223', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (113, N'James', N'Taylor', N'20056223-0234', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (114, N'Zoe', N'Nelson', N'20056324-0245', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (115, N'Leo', N'Adams', N'20056425-0256', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (116, N'Ella', N'Lee', N'20056526-0267', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (117, N'Jack', N'Baker', N'20056627-0278', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (118, N'Luca', N'Roberts', N'20056728-0289', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (119, N'Abigail', N'Davis', N'20056829-0290', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (120, N'Henry', N'Clark', N'20056930-0301', 4)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (121, N'Mia', N'Martinez', N'20057001-0011', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (122, N'Noah', N'Johnson', N'20057102-0022', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (123, N'Olivia', N'Wilson', N'20057203-0033', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (124, N'Liam', N'Moore', N'20057304-0044', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (125, N'Emma', N'Taylor', N'20057405-0055', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (126, N'Sophia', N'Anderson', N'20057506-0066', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (127, N'Benjamin', N'Thomas', N'20057607-0077', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (128, N'Aiden', N'Jackson', N'20057708-0088', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (129, N'Isabella', N'White', N'20057809-0099', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (130, N'Elijah', N'Harris', N'20057910-0101', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (131, N'Charlotte', N'Clark', N'20058011-0112', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (132, N'Ethan', N'Lewis', N'20058112-0123', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (133, N'Amelia', N'Young', N'20058213-0134', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (134, N'Sebastian', N'King', N'20058314-0145', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (135, N'Ava', N'Adams', N'20058415-0156', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (136, N'Mason', N'Scott', N'20058516-0167', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (137, N'Harper', N'Nelson', N'20058617-0178', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (138, N'Lucas', N'Roberts', N'20058718-0189', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (139, N'Jack', N'Walker', N'20058819-0190', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (140, N'Abigail', N'Green', N'20058920-0201', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (141, N'Grace', N'Baker', N'20059021-0212', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (142, N'Scarlett', N'Hernandez', N'20059122-0223', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (143, N'Henry', N'Adams', N'20059223-0234', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (144, N'Zoe', N'Taylor', N'20059324-0245', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (145, N'Victoria', N'Martinez', N'20059425-0256', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (146, N'Leo', N'Roberts', N'20059526-0267', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (147, N'Ella', N'Johnson', N'20059627-0278', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (148, N'Wyatt', N'Moore', N'20059728-0289', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (149, N'James', N'Wilson', N'20059829-0290', 5)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (150, N'Luca', N'Baker', N'20059930-0301', 5)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([EmployeeID_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD FOREIGN KEY([CourseID_FK])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD FOREIGN KEY([EmployeeID_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([CourseID_FK])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([GradeSetter_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([StudentID_FK])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([DepartmentID_FK])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([RoleID_FK])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([DepartmentID_FK])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([ClassID_FK])
REFERENCES [dbo].[Classes] ([ClassID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD CHECK  (([Grade]='F' OR [Grade]='E' OR [Grade]='D' OR [Grade]='C' OR [Grade]='B' OR [Grade]='A'))
GO
/****** Object:  StoredProcedure [dbo].[GetStudentInfo]    Script Date: 2025-01-05 15:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentInfo]
    @StudentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        StudentId,
        StudentFirstName,
		StudentLastName,
		StudentSSN,
		ClassID_FK
    FROM 
        Students
    WHERE 
        StudentId = @StudentId;
END;
GO
USE [master]
GO
ALTER DATABASE [AcademiaDB] SET  READ_WRITE 
GO
