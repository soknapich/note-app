/*
 Navicat Premium Data Transfer

 Source Server         : SQL Express Server
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : localhost\SQLEXPRESS:1433
 Source Catalog        : NotesDb
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 15/08/2025 08:03:12
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250809065920_CreateTable', N'9.0.8')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250810114857_CreateRoleTable', N'9.0.8')
GO


-- ----------------------------
-- Table structure for Note
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Note]') AND type IN ('U'))
	DROP TABLE [dbo].[Note]
GO

CREATE TABLE [dbo].[Note] (
  [Id] uniqueidentifier  NOT NULL,
  [Title] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Content] text COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [CreatedAt] datetime2(7)  NOT NULL,
  [UpdatedAt] datetime2(7)  NOT NULL,
  [UserId] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[Note] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Note
-- ----------------------------
INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'3ED31AE6-D08F-4D74-9B1C-00691BEB0C2A', N'ee', N'eee', N'2025-08-13 11:31:18.3133333', N'2025-08-13 11:31:18.3133333', N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'4BD48C24-A5E4-4C12-AF86-3D0EC849DAB4', N'MMMello', N'meta', N'2025-08-13 11:14:58.7500000', N'2025-08-13 11:15:05.3000000', N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'896DEA14-F0E3-4D94-AE36-545FC3A3C5DB', N'សួរស្តី', N'Hello World', N'2025-08-13 16:06:39.4933333', N'2025-08-13 16:13:06.5433333', N'63AC863B-A8BE-410B-09B8-08DDD723A943')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'45636BFB-FDB5-45FB-A786-71942699B282', N'Testing', N'testing', N'2025-08-15 07:32:41.2900000', N'2025-08-15 07:32:41.2900000', N'77483E65-149C-4316-09B7-08DDD723A943')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'67AD022E-D198-4109-82AD-7BAC5134A522', N'XLLL', N'ld,d,,d', N'2025-08-13 11:31:13.6066667', N'2025-08-13 11:31:13.6066667', N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'BE88424A-EE01-41DA-9F2D-81108E09929A', N'eee', N'ddd', N'2025-08-13 11:31:25.6166667', N'2025-08-13 11:31:25.6166667', N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'EBDC7568-81CF-4AC3-BC02-8FBDD1EED589', N'333', N'333', N'2025-08-13 11:31:21.7100000', N'2025-08-13 11:31:21.7100000', N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'BB53E3AB-7352-425B-A3A5-A85138B8992A', N'Another one', N'Another one', N'2025-08-13 16:13:19.8500000', N'2025-08-13 16:13:19.8500000', N'63AC863B-A8BE-410B-09B8-08DDD723A943')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'EA0C92BF-A3EF-424D-B7B3-C4D9195E0B0F', N'EEEE Esting', N'Hello', N'2025-08-13 08:57:23.9000000', N'2025-08-13 16:11:14.4366667', N'63AC863B-A8BE-410B-09B8-08DDD723A943')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'74D6147D-160D-4975-9AC6-CBEB8C6B0FEA', N'មើសើដដើ', N'MOMO', N'2025-08-13 16:06:04.8533333', N'2025-08-14 20:06:09.0300000', N'63AC863B-A8BE-410B-09B8-08DDD723A943')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'73FAE40C-77A8-455D-B9E5-E3F2CAB31703', N'Kongkaro', N'momg', N'2025-08-13 11:20:52.1600000', N'2025-08-13 11:20:52.1600000', N'AA725176-BF50-4551-635E-08DDDA1F1586')
GO

INSERT INTO [dbo].[Note] ([Id], [Title], [Content], [CreatedAt], [UpdatedAt], [UserId]) VALUES (N'D0405095-D4DF-4F3C-A60F-FFC8B05AF01A', N'Pong Pong', N'Ping', N'2025-08-13 09:01:49.2833333', N'2025-08-13 16:12:57.9533333', N'63AC863B-A8BE-410B-09B8-08DDD723A943')
GO


-- ----------------------------
-- Table structure for Role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type IN ('U'))
	DROP TABLE [dbo].[Role]
GO

CREATE TABLE [dbo].[Role] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Role] ON
GO

INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (N'1', N'Admin')
GO

INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (N'2', N'User')
GO

SET IDENTITY_INSERT [dbo].[Role] OFF
GO


-- ----------------------------
-- Table structure for RolePermission
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RolePermission]') AND type IN ('U'))
	DROP TABLE [dbo].[RolePermission]
GO

CREATE TABLE [dbo].[RolePermission] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ResourceKey] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [RoleId] int  NOT NULL,
  [ResourceController] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[RolePermission] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of RolePermission
-- ----------------------------
SET IDENTITY_INSERT [dbo].[RolePermission] ON
GO

INSERT INTO [dbo].[RolePermission] ([Id], [ResourceKey], [RoleId], [ResourceController]) VALUES (N'1', N'Read', N'1', N'Note')
GO

INSERT INTO [dbo].[RolePermission] ([Id], [ResourceKey], [RoleId], [ResourceController]) VALUES (N'2', N'Read', N'2', N'Note')
GO

INSERT INTO [dbo].[RolePermission] ([Id], [ResourceKey], [RoleId], [ResourceController]) VALUES (N'3', N'Create', N'1', N'Note')
GO

INSERT INTO [dbo].[RolePermission] ([Id], [ResourceKey], [RoleId], [ResourceController]) VALUES (N'5', N'Create', N'2', N'Note')
GO

INSERT INTO [dbo].[RolePermission] ([Id], [ResourceKey], [RoleId], [ResourceController]) VALUES (N'6', N'Read', N'2', N'User')
GO

SET IDENTITY_INSERT [dbo].[RolePermission] OFF
GO


-- ----------------------------
-- Table structure for User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type IN ('U'))
	DROP TABLE [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
  [Id] uniqueidentifier  NOT NULL,
  [Username] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [PasswordHash] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Role] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [RefreshToken] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RefreshTokenExpiryTime] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'77483E65-149C-4316-09B7-08DDD723A943', N'kaka', N'AQAAAAIAAYagAAAAEN9e7KDv/NJHk2RoyBlrP/QHIvrFPiozRMqfMM22KNs+VlWZ27jDg8p1YPJqWqfJow==', N'Admin', N'Xv29Qn7mTwbtkk10HblXI2xGhfAfITPzeir8kh+XDzw=', N'2025-08-22 00:03:09.8523743')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'63AC863B-A8BE-410B-09B8-08DDD723A943', N'sokna', N'AQAAAAIAAYagAAAAEN7+gDBIceQrYQWeV4Bo2DelWMudj6nNfsN4O53W8jsbj9Nwuh3xIMjtlRvCJO2RQg==', N'User', N'JsEnHS9GXOgtFKgHO4C+MC7sQDqTNBv5m04+IA4BTSA=', N'2025-08-21 12:57:17.6672258')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'A6225ABF-DA0D-4910-635B-08DDDA1F1586', N'mong', N'AQAAAAIAAYagAAAAEO9ZP4glFD+ztNZ2R1iqUi1Sh5GgP3t9V0+hXTjRXAYa0nahlsGlPMjGo4plldcOTw==', N'User', NULL, NULL)
GO

INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'EA97C6D8-A3C9-48CE-635C-08DDDA1F1586', N'meta', N'AQAAAAIAAYagAAAAEHmKE1EjooooWWoq7q8hOal1dkCjH1WlCpF6k9uPO1xzm/MPmVmovr7snHUiBMlqQw==', N'User', N'e9JuSHM3jnGbe2GVzyXTueskM8GsDCP/OvjPWe2MYrQ=', N'2025-08-20 04:30:55.9178411')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'CA7BAC57-FB9E-47FD-635D-08DDDA1F1586', N'toto', N'AQAAAAIAAYagAAAAEDllhqNZvE7zkExeAhOPeu2NDJA1QlW2PdJMgg5htzJyVsOmBhxqyhqrxL+EWiyyUg==', N'User', NULL, NULL)
GO

INSERT INTO [dbo].[User] ([Id], [Username], [PasswordHash], [Role], [RefreshToken], [RefreshTokenExpiryTime]) VALUES (N'AA725176-BF50-4551-635E-08DDDA1F1586', N'momo', N'AQAAAAIAAYagAAAAEDfTPS6v1uSZZX+Ue3w03SZ5+s70uT9d5ERzTLhogsM06KMCyoC2VEK9Hegwp5sIMw==', N'User', N'7quVFdh2d3p5pc22F7umLa1b0OSlu3v/bz/OLym/w88=', N'2025-08-20 04:20:39.3160493')
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table Note
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Note_UserId]
ON [dbo].[Note] (
  [UserId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Note
-- ----------------------------
ALTER TABLE [dbo].[Note] ADD CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Role
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Role]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for RolePermission
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[RolePermission]', RESEED, 6)
GO


-- ----------------------------
-- Indexes structure for table RolePermission
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_RolePermission_RoleId]
ON [dbo].[RolePermission] (
  [RoleId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table RolePermission
-- ----------------------------
ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Note
-- ----------------------------
ALTER TABLE [dbo].[Note] ADD CONSTRAINT [FK_Note_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table RolePermission
-- ----------------------------
ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

