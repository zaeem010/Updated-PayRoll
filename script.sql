USE [sad]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACGroup]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACGroup](
	[GroupID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[TimeZone1] [smallint] NULL,
	[TimeZone2] [smallint] NULL,
	[TimeZone3] [smallint] NULL,
	[holidayvaild] [bit] NULL,
	[verifystyle] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTimeZones]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTimeZones](
	[TimeZoneID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[SunStart] [datetime] NULL,
	[SunEnd] [datetime] NULL,
	[MonStart] [datetime] NULL,
	[MonEnd] [datetime] NULL,
	[TuesStart] [datetime] NULL,
	[TuesEnd] [datetime] NULL,
	[WedStart] [datetime] NULL,
	[WedEnd] [datetime] NULL,
	[ThursStart] [datetime] NULL,
	[ThursEnd] [datetime] NULL,
	[FriStart] [datetime] NULL,
	[FriEnd] [datetime] NULL,
	[SatStart] [datetime] NULL,
	[SatEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TimeZoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACUnlockComb]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACUnlockComb](
	[UnlockCombID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[Group01] [smallint] NULL,
	[Group02] [smallint] NULL,
	[Group03] [smallint] NULL,
	[Group04] [smallint] NULL,
	[Group05] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[UnlockCombID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlarmLog]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlarmLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Operator] [varchar](20) NULL,
	[EnrollNumber] [varchar](30) NULL,
	[LogTime] [datetime] NULL,
	[MachineAlias] [varchar](20) NULL,
	[AlarmType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignRoasters]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignRoasters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](max) NULL,
	[Roasterid] [int] NOT NULL,
	[Shiftid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AssignRoasters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttParam]    Script Date: 2021-07-19 11:33:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttParam](
	[PARANAME] [varchar](20) NOT NULL,
	[PARATYPE] [varchar](2) NULL,
	[PARAVALUE] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PARANAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditedExc]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditedExc](
	[AEID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CheckTime] [datetime] NOT NULL,
	[NewExcID] [int] NULL,
	[IsLeave] [smallint] NULL,
	[UName] [varchar](20) NULL,
	[UTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUTHDEVICE]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTHDEVICE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[MachineID] [int] NOT NULL,
 CONSTRAINT [AUTHKEY] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[MachineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BCode] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Banks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[BLogo] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[BCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Branches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHECKEXACT]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHECKEXACT](
	[EXACTID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NULL,
	[CHECKTIME] [datetime] NULL,
	[CHECKTYPE] [varchar](2) NULL,
	[ISADD] [smallint] NULL,
	[YUYIN] [varchar](25) NULL,
	[ISMODIFY] [smallint] NULL,
	[ISDELETE] [smallint] NULL,
	[INCOUNT] [smallint] NULL,
	[ISCOUNT] [smallint] NULL,
	[MODIFYBY] [varchar](20) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [EXACTID] PRIMARY KEY CLUSTERED 
(
	[EXACTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHECKINOUT]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHECKINOUT](
	[USERID] [int] NOT NULL,
	[CHECKTIME] [datetime2](7) NOT NULL,
	[CHECKTYPE] [varchar](1) NULL,
	[VERIFYCODE] [int] NULL,
	[SENSORID] [varchar](5) NULL,
	[Memoinfo] [varchar](30) NULL,
	[WorkCode] [varchar](24) NULL,
	[sn] [varchar](20) NULL,
	[UserExtFmt] [smallint] NULL,
 CONSTRAINT [USERCHECKTIME] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[CHECKTIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dates]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dates](
	[Date] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Dates] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Days]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departmentes]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departmentes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Comid] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Departmentes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEPARTMENTS]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTMENTS](
	[DEPTID] [int] IDENTITY(1,1) NOT NULL,
	[DEPTNAME] [varchar](30) NULL,
	[SUPDEPTID] [int] NOT NULL,
	[InheritParentSch] [smallint] NULL,
	[InheritDeptSch] [smallint] NULL,
	[InheritDeptSchClass] [smallint] NULL,
	[AutoSchPlan] [smallint] NULL,
	[InLate] [smallint] NULL,
	[OutEarly] [smallint] NULL,
	[InheritDeptRule] [smallint] NULL,
	[MinAutoSchInterval] [int] NULL,
	[RegisterOT] [smallint] NULL,
	[DefaultSchId] [int] NOT NULL,
	[ATT] [smallint] NULL,
	[Holiday] [smallint] NULL,
	[OverTime] [smallint] NULL,
 CONSTRAINT [DEPTID] PRIMARY KEY CLUSTERED 
(
	[DEPTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeptUsedSchs]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeptUsedSchs](
	[DeptId] [int] NOT NULL,
	[SchId] [int] NOT NULL,
 CONSTRAINT [DEPT_USED_SCH] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC,
	[SchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Comid] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Designations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmOpLog]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmOpLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[OperateTime] [datetime] NOT NULL,
	[manipulationID] [int] NULL,
	[Params1] [int] NULL,
	[Params2] [int] NULL,
	[Params3] [int] NULL,
	[Params4] [int] NULL,
	[SensorId] [varchar](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttendanceApprovals]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttendanceApprovals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Managerid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[CheckInDatetime] [datetime2](7) NOT NULL,
	[CheckOutDatetime] [datetime2](7) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.EmployeeAttendanceApprovals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttendanceReports]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttendanceReports](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Calenderid] [int] NOT NULL,
	[Date] [nvarchar](max) NULL,
	[DateName] [nvarchar](max) NULL,
	[DateTimeIn] [datetime2](7) NOT NULL,
	[DateTimeout] [datetime2](7) NOT NULL,
	[CheckIn] [nvarchar](max) NULL,
	[CheckOut] [nvarchar](max) NULL,
	[Final] [nvarchar](max) NULL,
	[OverTime] [int] NOT NULL,
	[ShiftName] [nvarchar](max) NULL,
	[ShiftStartTime] [datetime2](7) NOT NULL,
	[ShiftEndTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeAttendanceReports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttendances]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttendances](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Comid] [int] NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Datetime] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.EmployeeAttendances] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[FName] [nvarchar](max) NULL,
	[DOB] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[BloodGroup] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Cnic] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[EmerPhone] [nvarchar](max) NULL,
	[Branchid] [int] NOT NULL,
	[Departid] [int] NOT NULL,
	[Designationid] [int] NOT NULL,
	[Managerid] [int] NOT NULL,
	[Roasterid] [int] NOT NULL,
	[overTime] [bit] NOT NULL,
	[JoiningDate] [nvarchar](max) NULL,
	[idDetail] [nvarchar](max) NULL,
	[LeaveCal] [nvarchar](max) NULL,
	[salaryid] [int] NOT NULL,
	[BankInfo] [nvarchar](max) NULL,
	[PaymentTransfertype] [nvarchar](max) NULL,
	[offDay] [nvarchar](max) NULL,
	[NumberOfleaves] [nvarchar](max) NULL,
	[AttendanceSandwitch] [nvarchar](max) NULL,
	[comid] [int] NOT NULL,
	[EmployeeAcc] [int] NOT NULL,
	[GeneCode] [int] NOT NULL,
	[BankAcc] [nvarchar](max) NULL,
	[EmployeeStatus] [nvarchar](max) NULL,
	[ResignDate] [nvarchar](max) NULL,
	[BlockNote] [nvarchar](max) NULL,
	[EmpQualification] [nvarchar](max) NULL,
	[PerHourSalary] [decimal](18, 2) NOT NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXCNOTES]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCNOTES](
	[USERID] [int] NULL,
	[ATTDATE] [datetime] NULL,
	[NOTES] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FaceTemp]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaceTemp](
	[TEMPLATEID] [int] IDENTITY(1,1) NOT NULL,
	[USERNO] [varchar](24) NULL,
	[SIZE] [int] NULL,
	[pin] [int] NULL,
	[FACEID] [int] NULL,
	[VALID] [int] NULL,
	[RESERVE] [int] NULL,
	[ACTIVETIME] [int] NULL,
	[VFCOUNT] [int] NULL,
	[TEMPLATE] [image] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TEMPLATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOLIDAYS]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOLIDAYS](
	[HOLIDAYID] [int] IDENTITY(1,1) NOT NULL,
	[HOLIDAYNAME] [varchar](20) NULL,
	[HOLIDAYYEAR] [smallint] NULL,
	[HOLIDAYMONTH] [smallint] NULL,
	[HOLIDAYDAY] [smallint] NULL,
	[STARTTIME] [datetime] NULL,
	[DURATION] [smallint] NULL,
	[HOLIDAYTYPE] [smallint] NULL,
	[XINBIE] [varchar](4) NULL,
	[MINZU] [varchar](50) NULL,
	[DeptID] [smallint] NULL,
	[timezone] [int] NULL,
 CONSTRAINT [HOLID] PRIMARY KEY CLUSTERED 
(
	[HOLIDAYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveClass]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveClass](
	[LeaveId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveName] [varchar](20) NOT NULL,
	[MinUnit] [float] NOT NULL,
	[Unit] [smallint] NOT NULL,
	[RemaindProc] [smallint] NOT NULL,
	[RemaindCount] [smallint] NOT NULL,
	[ReportSymbol] [varchar](4) NOT NULL,
	[Deduct] [float] NOT NULL,
	[Color] [int] NOT NULL,
	[Classify] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveClass1]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveClass1](
	[LeaveId] [int] IDENTITY(999,1) NOT NULL,
	[LeaveName] [varchar](20) NOT NULL,
	[MinUnit] [float] NOT NULL,
	[Unit] [smallint] NOT NULL,
	[RemaindProc] [smallint] NOT NULL,
	[RemaindCount] [smallint] NOT NULL,
	[ReportSymbol] [varchar](4) NOT NULL,
	[Deduct] [float] NOT NULL,
	[LeaveType] [smallint] NOT NULL,
	[Color] [int] NOT NULL,
	[Classify] [smallint] NOT NULL,
	[Calc] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveRequests]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeAcc] [int] NOT NULL,
	[Managerid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[StDate] [nvarchar](max) NULL,
	[EnDate] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Narration] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LeaveRequests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MachineAlias] [varchar](20) NOT NULL,
	[ConnectType] [int] NOT NULL,
	[IP] [varchar](20) NULL,
	[SerialPort] [int] NULL,
	[Port] [int] NULL,
	[Baudrate] [int] NULL,
	[MachineNumber] [int] NOT NULL,
	[IsHost] [bit] NULL,
	[Enabled] [bit] NULL,
	[CommPassword] [varchar](12) NULL,
	[UILanguage] [smallint] NULL,
	[DateFormat] [smallint] NULL,
	[InOutRecordWarn] [smallint] NULL,
	[Idle] [smallint] NULL,
	[Voice] [smallint] NULL,
	[managercount] [smallint] NULL,
	[usercount] [smallint] NULL,
	[fingercount] [smallint] NULL,
	[SecretCount] [smallint] NULL,
	[FirmwareVersion] [varchar](20) NULL,
	[ProductType] [varchar](20) NULL,
	[LockControl] [smallint] NULL,
	[Purpose] [smallint] NULL,
	[ProduceKind] [int] NULL,
	[sn] [varchar](20) NULL,
	[PhotoStamp] [varchar](20) NULL,
	[IsIfChangeConfigServer2] [int] NULL,
	[IsAndroid] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NUM_RUN]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NUM_RUN](
	[NUM_RUNID] [int] IDENTITY(1,1) NOT NULL,
	[OLDID] [int] NULL,
	[NAME] [varchar](30) NOT NULL,
	[STARTDATE] [datetime] NULL,
	[ENDDATE] [datetime] NULL,
	[CYLE] [smallint] NULL,
	[UNITS] [smallint] NULL,
 CONSTRAINT [NUMID] PRIMARY KEY CLUSTERED 
(
	[NUM_RUNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NUM_RUN_DEIL]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NUM_RUN_DEIL](
	[NUM_RUNID] [smallint] NOT NULL,
	[STARTTIME] [datetime] NOT NULL,
	[ENDTIME] [datetime] NULL,
	[SDAYS] [smallint] NOT NULL,
	[EDAYS] [smallint] NULL,
	[SCHCLASSID] [int] NULL,
	[OverTime] [int] NULL,
 CONSTRAINT [NUMID2] PRIMARY KEY CLUSTERED 
(
	[NUM_RUNID] ASC,
	[SDAYS] ASC,
	[STARTTIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgCalenders]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgCalenders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StDate] [nvarchar](max) NULL,
	[EnDate] [nvarchar](max) NULL,
	[OT] [nvarchar](max) NULL,
	[OTMBy] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrgCalenders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OTRequests]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OTRequests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeAcc] [int] NOT NULL,
	[Managerid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[StDate] [nvarchar](max) NULL,
	[EnDate] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Narration] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OTRequests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayRollCalenders]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayRollCalenders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StDate] [nvarchar](max) NULL,
	[EnDate] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PayRollCalenders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportItem]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportItem](
	[RIID] [int] IDENTITY(1,1) NOT NULL,
	[RIIndex] [int] NULL,
	[ShowIt] [smallint] NULL,
	[RIName] [varchar](12) NULL,
	[UnitName] [varchar](6) NULL,
	[Formula] [image] NOT NULL,
	[CalcBySchClass] [smallint] NULL,
	[StatisticMethod] [smallint] NULL,
	[CalcLast] [smallint] NULL,
	[Notes] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[RIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestdayUpdates]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestdayUpdates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Restday] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Comid] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.RestdayUpdates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roasters]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roasters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Roasters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoasterUpdates]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoasterUpdates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Roasterid] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Comid] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.RoasterUpdates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RsAssignChilds]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RsAssignChilds](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RsAssignid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[EmpCode] [nvarchar](max) NULL,
	[LeaveDay] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.RsAssignChilds] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RsAssigns]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RsAssigns](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RsAssignid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[Shiftid] [int] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.RsAssigns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryPackages]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryPackages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BasicSalary] [nvarchar](max) NULL,
	[MedicalAllowance] [nvarchar](max) NULL,
	[HouseRent] [nvarchar](max) NULL,
	[Total] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SalaryPackages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchClass]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchClass](
	[schClassid] [int] IDENTITY(1,1) NOT NULL,
	[schName] [varchar](20) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[LateMinutes] [int] NULL,
	[EarlyMinutes] [int] NULL,
	[CheckIn] [int] NULL,
	[CheckOut] [int] NULL,
	[CheckInTime1] [datetime] NULL,
	[CheckInTime2] [datetime] NULL,
	[CheckOutTime1] [datetime] NULL,
	[CheckOutTime2] [datetime] NULL,
	[Color] [int] NULL,
	[AutoBind] [smallint] NULL,
	[WorkDay] [float] NULL,
	[SensorID] [varchar](5) NULL,
	[WorkMins] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[schClassid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SECURITYDETAILS]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SECURITYDETAILS](
	[SECURITYDETAILID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NULL,
	[DEPTID] [smallint] NULL,
	[SCHEDULE] [smallint] NULL,
	[USERINFO] [smallint] NULL,
	[ENROLLFINGERS] [smallint] NULL,
	[REPORTVIEW] [smallint] NULL,
	[REPORT] [varchar](10) NULL,
	[ReadOnly] [bit] NULL,
	[FullControl] [bit] NULL,
 CONSTRAINT [NAMEID2] PRIMARY KEY CLUSTERED 
(
	[SECURITYDETAILID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServerLog]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServerLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EVENT] [varchar](30) NOT NULL,
	[USERID] [int] NOT NULL,
	[EnrollNumber] [varchar](30) NULL,
	[parameter] [smallint] NULL,
	[EVENTTIME] [datetime] NOT NULL,
	[SENSORID] [varchar](5) NULL,
	[OPERATOR] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHIFT]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIFT](
	[SHIFTID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](20) NULL,
	[USHIFTID] [int] NULL,
	[STARTDATE] [datetime] NOT NULL,
	[ENDDATE] [datetime] NULL,
	[RUNNUM] [smallint] NULL,
	[SCH1] [int] NULL,
	[SCH2] [int] NULL,
	[SCH3] [int] NULL,
	[SCH4] [int] NULL,
	[SCH5] [int] NULL,
	[SCH6] [int] NULL,
	[SCH7] [int] NULL,
	[SCH8] [int] NULL,
	[SCH9] [int] NULL,
	[SCH10] [int] NULL,
	[SCH11] [int] NULL,
	[SCH12] [int] NULL,
	[CYCLE] [smallint] NULL,
	[UNITS] [smallint] NULL,
 CONSTRAINT [SHIFTS] PRIMARY KEY CLUSTERED 
(
	[SHIFTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shiftes]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shiftes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StTime] [datetime] NOT NULL,
	[EnTime] [datetime] NOT NULL,
	[EarlyStTimeinMin] [nvarchar](max) NULL,
	[LateStTimeinMin] [nvarchar](max) NULL,
	[EarlyEnTimeinMin] [nvarchar](max) NULL,
	[LateEnTimeinMin] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
	[ShiftHours] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Shiftes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Operator] [varchar](20) NULL,
	[LogTime] [datetime] NULL,
	[MachineAlias] [varchar](20) NULL,
	[LogTag] [smallint] NULL,
	[LogDescr] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBKEY]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBKEY](
	[PreName] [varchar](12) NULL,
	[ONEKEY] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBSMSALLOT]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBSMSALLOT](
	[REFERENCE] [int] NOT NULL,
	[SMSREF] [int] NOT NULL,
	[USERREF] [int] NOT NULL,
	[GENTM] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[REFERENCE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBSMSINFO]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBSMSINFO](
	[REFERENCE] [int] NOT NULL,
	[SMSID] [varchar](16) NOT NULL,
	[SMSINDEX] [int] NOT NULL,
	[SMSTYPE] [int] NULL,
	[SMSCONTENT] [text] NULL,
	[SMSSTARTTM] [varchar](32) NULL,
	[SMSTMLENG] [int] NULL,
	[GENTM] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[REFERENCE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEMPLATE]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEMPLATE](
	[TEMPLATEID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[FINGERID] [int] NOT NULL,
	[TEMPLATE] [image] NOT NULL,
	[TEMPLATE2] [image] NULL,
	[TEMPLATE3] [image] NULL,
	[BITMAPPICTURE] [image] NULL,
	[BITMAPPICTURE2] [image] NULL,
	[BITMAPPICTURE3] [image] NULL,
	[BITMAPPICTURE4] [image] NULL,
	[USETYPE] [smallint] NULL,
	[EMACHINENUM] [varchar](3) NULL,
	[TEMPLATE1] [image] NULL,
	[Flag] [smallint] NULL,
	[DivisionFP] [smallint] NULL,
	[TEMPLATE4] [image] NULL,
 CONSTRAINT [TEMPLATED] PRIMARY KEY CLUSTERED 
(
	[TEMPLATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThirdLevels]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThirdLevels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [int] NOT NULL,
	[Headid] [int] NOT NULL,
	[SubHeadid] [int] NOT NULL,
	[SecondHeadid] [int] NOT NULL,
	[AccountTitle] [nvarchar](max) NULL,
	[AccountType] [nvarchar](max) NULL,
	[Dr] [decimal](18, 2) NOT NULL,
	[Cr] [decimal](18, 2) NOT NULL,
	[Comid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ThirdLevels] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_OF_RUN]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_OF_RUN](
	[USERID] [int] NOT NULL,
	[NUM_OF_RUN_ID] [int] NOT NULL,
	[STARTDATE] [datetime] NOT NULL,
	[ENDDATE] [datetime] NOT NULL,
	[ISNOTOF_RUN] [int] NULL,
	[ORDER_RUN] [int] NULL,
 CONSTRAINT [USER_ST_NUM] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[NUM_OF_RUN_ID] ASC,
	[STARTDATE] ASC,
	[ENDDATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_SPEDAY]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_SPEDAY](
	[USERID] [int] NOT NULL,
	[STARTSPECDAY] [datetime] NOT NULL,
	[ENDSPECDAY] [datetime] NULL,
	[DATEID] [smallint] NOT NULL,
	[YUANYING] [varchar](200) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [USER_SEP] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[STARTSPECDAY] ASC,
	[DATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_TEMP_SCH]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_TEMP_SCH](
	[USERID] [int] NOT NULL,
	[COMETIME] [datetime] NOT NULL,
	[LEAVETIME] [datetime] NOT NULL,
	[OVERTIME] [int] NOT NULL,
	[TYPE] [smallint] NULL,
	[FLAG] [smallint] NULL,
	[SCHCLASSID] [int] NULL,
 CONSTRAINT [USER_TEMP] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[COMETIME] ASC,
	[LEAVETIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccesses]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccesses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Form_id] [int] NOT NULL,
	[SubForm_id] [int] NOT NULL,
	[SuperForm_id] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[Username] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserAccesses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserACMachines]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserACMachines](
	[UserID] [int] NOT NULL,
	[Deviceid] [int] NOT NULL,
 CONSTRAINT [UserAC_Machines] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[Deviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserACPrivilege]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserACPrivilege](
	[UserID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[ACGroupID] [int] NULL,
	[IsUseGroup] [bit] NULL,
	[TimeZone1] [int] NULL,
	[TimeZone2] [int] NULL,
	[TimeZone3] [int] NULL,
	[verifystyle] [int] NULL,
 CONSTRAINT [pk_privilege] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[DeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERINFO]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERINFO](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[BADGENUMBER] [varchar](24) NULL,
	[SSN] [varchar](20) NULL,
	[NAME] [varchar](40) NULL,
	[GENDER] [varchar](8) NULL,
	[TITLE] [varchar](20) NULL,
	[PAGER] [varchar](20) NULL,
	[BIRTHDAY] [datetime] NULL,
	[HIREDDAY] [datetime] NULL,
	[STREET] [varchar](80) NULL,
	[CITY] [varchar](2) NULL,
	[STATE] [varchar](2) NULL,
	[ZIP] [varchar](12) NULL,
	[OPHONE] [varchar](20) NULL,
	[FPHONE] [varchar](20) NULL,
	[VERIFICATIONMETHOD] [smallint] NULL,
	[DEFAULTDEPTID] [smallint] NULL,
	[SECURITYFLAGS] [smallint] NULL,
	[ATT] [smallint] NULL,
	[INLATE] [smallint] NULL,
	[OUTEARLY] [smallint] NULL,
	[OVERTIME] [smallint] NULL,
	[SEP] [smallint] NULL,
	[HOLIDAY] [smallint] NULL,
	[MINZU] [varchar](8) NULL,
	[PASSWORD] [varchar](50) NULL,
	[LUNCHDURATION] [smallint] NULL,
	[MVerifyPass] [varchar](10) NULL,
	[PHOTO] [image] NULL,
	[Notes] [image] NULL,
	[privilege] [int] NULL,
	[InheritDeptSch] [smallint] NULL,
	[InheritDeptSchClass] [smallint] NULL,
	[AutoSchPlan] [smallint] NULL,
	[MinAutoSchInterval] [int] NULL,
	[RegisterOT] [smallint] NULL,
	[InheritDeptRule] [smallint] NULL,
	[EMPRIVILEGE] [smallint] NULL,
	[CardNo] [varchar](20) NULL,
	[FaceGroup] [int] NULL,
	[AccGroup] [int] NULL,
	[UseAccGroupTZ] [int] NULL,
	[VerifyCode] [int] NULL,
	[Expires] [int] NULL,
	[ValidCount] [int] NULL,
	[ValidTimeBegin] [datetime] NULL,
	[ValidTimeEnd] [datetime] NULL,
	[TimeZone1] [int] NULL,
	[TimeZone2] [int] NULL,
	[TimeZone3] [int] NULL,
 CONSTRAINT [USERIDS] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Comid] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserLogins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersMachines]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersMachines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[DEVICEID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUpdates]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUpdates](
	[UpdateId] [int] IDENTITY(1,1) NOT NULL,
	[BadgeNumber] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[UpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUsedSClasses]    Script Date: 2021-07-19 11:33:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUsedSClasses](
	[UserId] [int] NOT NULL,
	[SchId] [int] NOT NULL,
 CONSTRAINT [USER_USED_SCL] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[SchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone1]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone2]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone3]
GO
ALTER TABLE [dbo].[AlarmLog] ADD  DEFAULT (getdate()) FOR [LogTime]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [USERID]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [CHECKTIME]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [CHECKTYPE]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISADD]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISMODIFY]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISDELETE]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [INCOUNT]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISCOUNT]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ('Temp-Supervisor') FOR [MODIFYBY]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  CONSTRAINT [DF__CHECKINOU__CHECK__7B5B524B]  DEFAULT (getdate()) FOR [CHECKTIME]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  CONSTRAINT [DF__CHECKINOU__CHECK__7C4F7684]  DEFAULT ('I') FOR [CHECKTYPE]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  CONSTRAINT [DF__CHECKINOU__VERIF__7D439ABD]  DEFAULT ((0)) FOR [VERIFYCODE]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  CONSTRAINT [DF__CHECKINOU__WorkC__1F63A897]  DEFAULT ((0)) FOR [WorkCode]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  CONSTRAINT [DF__CHECKINOU__UserE__318258D2]  DEFAULT ((0)) FOR [UserExtFmt]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [SUPDEPTID]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritParentSch]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptSch]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptSchClass]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [AutoSchPlan]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InLate]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [OutEarly]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptRule]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((24)) FOR [MinAutoSchInterval]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [RegisterOT]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [DefaultSchId]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [ATT]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [Holiday]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [OverTime]
GO
ALTER TABLE [dbo].[EmployeeAttendanceReports] ADD  CONSTRAINT [DF__EmployeeA__Shift__6BAEFA67]  DEFAULT ('1900-01-01T00:00:00.000') FOR [ShiftStartTime]
GO
ALTER TABLE [dbo].[EmployeeAttendanceReports] ADD  CONSTRAINT [DF__EmployeeA__Shift__6CA31EA0]  DEFAULT ('1900-01-01T00:00:00.000') FOR [ShiftEndTime]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [PerHourSalary]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [SIZE]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [pin]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [FACEID]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [VALID]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [RESERVE]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [ACTIVETIME]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [VFCOUNT]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((1)) FOR [HOLIDAYDAY]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((1)) FOR [DeptID]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((0)) FOR [timezone]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [MinUnit]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [Unit]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [RemaindProc]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [RemaindCount]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ('-') FOR [ReportSymbol]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Deduct]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Color]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Classify]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((1)) FOR [MinUnit]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Unit]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((2)) FOR [RemaindProc]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((1)) FOR [RemaindCount]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ('_') FOR [ReportSymbol]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Deduct]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [LeaveType]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Color]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Classify]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [SerialPort]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [Port]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [MachineNumber]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [UILanguage]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [DateFormat]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [InOutRecordWarn]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [Idle]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [Voice]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [managercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [usercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [fingercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [SecretCount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [LockControl]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [Purpose]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [ProduceKind]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [PhotoStamp]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [IsIfChangeConfigServer2]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [IsAndroid]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((-1)) FOR [OLDID]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ('2000-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ('2099-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((1)) FOR [CYLE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((1)) FOR [UNITS]
GO
ALTER TABLE [dbo].[NUM_RUN_DEIL] ADD  DEFAULT ((-1)) FOR [SCHCLASSID]
GO
ALTER TABLE [dbo].[RsAssigns] ADD  CONSTRAINT [DF__RsAssigns__DateT__66EA454A]  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateTime]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [CheckIn]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [CheckOut]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((16715535)) FOR [Color]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [AutoBind]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [WorkDay]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((0)) FOR [WorkMins]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((-1)) FOR [USHIFTID]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ('1900-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ('1900-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [RUNNUM]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH1]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH2]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH3]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH4]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH5]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH6]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH7]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH8]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH9]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH10]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH11]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH12]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [CYCLE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [UNITS]
GO
ALTER TABLE [dbo].[Shiftes] ADD  DEFAULT ((0)) FOR [ShiftHours]
GO
ALTER TABLE [dbo].[SystemLog] ADD  DEFAULT (getdate()) FOR [LogTime]
GO
ALTER TABLE [dbo].[TEMPLATE] ADD  DEFAULT ((1)) FOR [Flag]
GO
ALTER TABLE [dbo].[TEMPLATE] ADD  DEFAULT ((0)) FOR [DivisionFP]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ('1900-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ('2099-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ((0)) FOR [ISNOTOF_RUN]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ('1900-1-1') FOR [STARTSPECDAY]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ('2099-12-31') FOR [ENDSPECDAY]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ((-1)) FOR [DATEID]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((0)) FOR [OVERTIME]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((0)) FOR [TYPE]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((1)) FOR [FLAG]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((-1)) FOR [SCHCLASSID]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__DEFAUL__17C286CF]  DEFAULT ((1)) FOR [DEFAULTDEPTID]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__ATT__18B6AB08]  DEFAULT ((1)) FOR [ATT]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__INLATE__19AACF41]  DEFAULT ((1)) FOR [INLATE]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__OUTEAR__1A9EF37A]  DEFAULT ((1)) FOR [OUTEARLY]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__OVERTI__1B9317B3]  DEFAULT ((1)) FOR [OVERTIME]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__SEP__1C873BEC]  DEFAULT ((1)) FOR [SEP]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__HOLIDA__1D7B6025]  DEFAULT ((1)) FOR [HOLIDAY]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__LUNCHD__1E6F845E]  DEFAULT ((1)) FOR [LUNCHDURATION]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__privil__1F63A897]  DEFAULT ((0)) FOR [privilege]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Inheri__2057CCD0]  DEFAULT ((1)) FOR [InheritDeptSch]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Inheri__214BF109]  DEFAULT ((1)) FOR [InheritDeptSchClass]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__AutoSc__22401542]  DEFAULT ((1)) FOR [AutoSchPlan]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__MinAut__2334397B]  DEFAULT ((24)) FOR [MinAutoSchInterval]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Regist__24285DB4]  DEFAULT ((1)) FOR [RegisterOT]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Inheri__251C81ED]  DEFAULT ((1)) FOR [InheritDeptRule]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__EMPRIV__2610A626]  DEFAULT ((0)) FOR [EMPRIVILEGE]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__FaceGr__2704CA5F]  DEFAULT ((0)) FOR [FaceGroup]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__AccGro__27F8EE98]  DEFAULT ((1)) FOR [AccGroup]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__UseAcc__28ED12D1]  DEFAULT ((1)) FOR [UseAccGroupTZ]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Verify__29E1370A]  DEFAULT ((0)) FOR [VerifyCode]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__Expire__2AD55B43]  DEFAULT ((0)) FOR [Expires]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__ValidC__2BC97F7C]  DEFAULT ((0)) FOR [ValidCount]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__TimeZo__2CBDA3B5]  DEFAULT ((1)) FOR [TimeZone1]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__TimeZo__2DB1C7EE]  DEFAULT ((0)) FOR [TimeZone2]
GO
ALTER TABLE [dbo].[USERINFO] ADD  CONSTRAINT [DF__USERINFO__TimeZo__2EA5EC27]  DEFAULT ((0)) FOR [TimeZone3]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
