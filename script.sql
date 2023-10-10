/*
Created		10/6/2023
Modified		10/6/2023
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

Create Database [CoffeeManagement]
go
use [CoffeeManagement]
go

Create table [User]
(
	[UserId] Integer Identity NOT NULL,
	[Username] Nvarchar(100) NOT NULL,
	[Email] Varchar(100) NOT NULL, UNIQUE ([Email]),
	[Password] Varchar(255) NOT NULL,
	[SDT] Varchar(20) NULL,
	[RoleId] Varchar(10) NOT NULL DEFAULT 'KH',
Primary Key ([UserId])
) 
go

Create table [Product]
(
	[ProductId] Integer Identity NOT NULL,
	[CategoryId] Integer NOT NULL,
	[ProductName] Nvarchar(100) NOT NULL,
	[Image] Varchar(255) NULL,
	[SellPrice] Float NOT NULL,
	[Description] Nvarchar(500) NULL,
Primary Key ([ProductId])
) 
go

Create table [Role]
(
	[RoleId] Varchar(10) NOT NULL,
	[RoleName] Nvarchar(50) NOT NULL,
Primary Key ([RoleId])
) 
go

Create table [ProductCategory]
(
	[CategoryId] Integer Identity NOT NULL,
	[CategoryName] Nvarchar(100) NOT NULL,
Primary Key ([CategoryId])
) 
go

Create table [Invoice]
(
	[InvoiceId] Integer Identity NOT NULL,
	[UserId] Integer NOT NULL,
	[TableId] Integer NULL,
	[TotalPrice] Float NOT NULL,
	[CreatedAt] Datetime NOT NULL,
	[Discount] Float NULL,
	[AfterDiscount] Float NOT NULL,
Primary Key ([InvoiceId])
) 
go

Create table [InvoiceDetail]
(
	[InvoiceId] Integer NOT NULL,
	[ProductId] Integer NOT NULL,
	[Quantity] Integer NOT NULL,
	[Price] Float NOT NULL,
Primary Key ([InvoiceId],[ProductId])
) 
go

Create table [Card]
(
	[CardNumber] Varchar(20) NOT NULL,
	[UserId] Integer NULL,
	[Rank] Nvarchar(50) NULL,
	[Point] Integer NULL,
Primary Key ([CardNumber])
) 
go

Create table [Table]
(
	[TableId] Integer Identity NOT NULL,
	[TableName] Nvarchar(50) NOT NULL,
	[Status] Integer NOT NULL,
Primary Key ([TableId])
) 
go


Alter table [Card] add  foreign key([UserId]) references [User] ([UserId])  on update no action on delete no action 
go
Alter table [Invoice] add  foreign key([UserId]) references [User] ([UserId])  on update no action on delete no action 
go
Alter table [InvoiceDetail] add  foreign key([ProductId]) references [Product] ([ProductId])  on update no action on delete no action 
go
Alter table [User] add  foreign key([RoleId]) references [Role] ([RoleId])  on update no action on delete no action 
go
Alter table [Product] add  foreign key([CategoryId]) references [ProductCategory] ([CategoryId])  on update no action on delete no action 
go
Alter table [InvoiceDetail] add  foreign key([InvoiceId]) references [Invoice] ([InvoiceId])  on update no action on delete no action 
go
Alter table [Invoice] add  foreign key([TableId]) references [Table] ([TableId])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go

INSERT INTO [Role]([RoleId], [RoleName]) VALUES ('QL', N'Quản Lý'), ('NV', N'Nhân Viên'), ('KH', N'Khách Hàng');
