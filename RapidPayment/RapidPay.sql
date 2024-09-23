USE [RapidPay]
GO

/****** Object:  Table [dbo].[tblCardDetails]    Script Date: 9/23/2024 1:28:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCardDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[Address] [varchar](300) NULL,
	[City] [varchar](300) NULL,
	[Zipcode] [varchar](300) NULL,
	[CardNo] [varchar](20) NULL,
	[Cvv] [varchar](3) NULL,
	[ValiddateRange] [varchar](10) NULL,
	[Balance] [float] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCardDetails] ADD  DEFAULT ((0.0)) FOR [Balance]
GO

ALTER TABLE [dbo].[tblCardDetails] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO


--------------------------------------------------------------------------------------------------------------
USE [RapidPay]
GO

/****** Object:  Table [dbo].[tblCardTransacationDetails]    Script Date: 9/23/2024 1:28:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCardTransacationDetails](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[Transddate] [datetime] NULL,
	[Category] [varchar](100) NULL,
	[Payment] [float] NULL,
	[Paymentfees] [float] NULL,
	[Id] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCardTransacationDetails] ADD  DEFAULT ((0.0)) FOR [Payment]
GO

ALTER TABLE [dbo].[tblCardTransacationDetails] ADD  DEFAULT ((0.0)) FOR [Paymentfees]
GO

ALTER TABLE [dbo].[tblCardTransacationDetails]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[tblCardDetails] ([Id])
GO





