USE [EmployeeTravelBookingDB]
GO
/****** Object:  Table [dbo].[CarRentals]    Script Date: 28-02-2025 10:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentals](
	[RentalID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[RentalCompany] [nvarchar](100) NULL,
	[PickupDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[CarType] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_CarRentals] PRIMARY KEY CLUSTERED 
(
	[RentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Flights]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[FlightID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[Airline] [nvarchar](100) NULL,
	[FlightNumber] [nvarchar](50) NULL,
	[DepartureTime] [datetime] NULL,
	[ArrivalTime] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_TravelByFlights] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[HotelName] [nvarchar](100) NULL,
	[CheckInDate] [date] NULL,
	[CheckOutDate] [date] NULL,
	[RoomType] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginTracking]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTracking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ActualToken] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[CreateAt] [datetime] NULL,
 CONSTRAINT [PK_LoginDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TravelRequests]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelRequests](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[TravelType] [nvarchar](50) NULL,
	[Purpose] [nvarchar](255) NULL,
	[FromCity] [nvarchar](100) NULL,
	[FromCountry] [nvarchar](100) NULL,
	[DestinationCity] [nvarchar](100) NULL,
	[DestinationCountry] [nvarchar](100) NULL,
	[DepartureDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[ExpenseAmount] [decimal](10, 2) NULL,
	[Status] [nvarchar](50) NULL,
	[CreateAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[ApprovedBy] [int] NULL,
	[Active] [tinyint] NULL,
 CONSTRAINT [PK_TravelRequests] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Destination] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](20) NULL,
	[DateJoined] [date] NULL,
	[UserTypeID] [int] NULL,
	[ManagerID] [int] NULL,
	[Status] [tinyint] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 28-02-2025 10:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[AccessLevel] [nvarchar](50) NULL,
	[Active] [tinyint] NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [FK__CarRental__Reque__38996AB5] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [FK__CarRental__Reque__38996AB5]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [FK__CarRental__Reque__412EB0B6] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [FK__CarRental__Reque__412EB0B6]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [FK__CarRental__Reque__49C3F6B7] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [FK__CarRental__Reque__49C3F6B7]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [FK__CarRental__Reque__4F7CD00D] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [FK__CarRental__Reque__4F7CD00D]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK__Flights__Request__36B12243] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK__Flights__Request__36B12243]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK__Flights__Request__3F466844] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK__Flights__Request__3F466844]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK__Flights__Request__47DBAE45] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK__Flights__Request__47DBAE45]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK__Flights__Request__4D94879B] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK__Flights__Request__4D94879B]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_TravelByFlights_TravelByFlights] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flights] ([FlightID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_TravelByFlights_TravelByFlights]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK__Hotels__RequestI__37A5467C] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK__Hotels__RequestI__37A5467C]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK__Hotels__RequestI__403A8C7D] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK__Hotels__RequestI__403A8C7D]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK__Hotels__RequestI__48CFD27E] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK__Hotels__RequestI__48CFD27E]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK__Hotels__RequestI__4E88ABD4] FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK__Hotels__RequestI__4E88ABD4]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD FOREIGN KEY([RequestID])
REFERENCES [dbo].[TravelRequests] ([RequestID])
GO
ALTER TABLE [dbo].[LoginTracking]  WITH CHECK ADD  CONSTRAINT [FK__LoginTrac__UserI__3D5E1FD2] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LoginTracking] CHECK CONSTRAINT [FK__LoginTrac__UserI__3D5E1FD2]
GO
ALTER TABLE [dbo].[LoginTracking]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LoginTracking]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LoginTracking]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TravelRequests]  WITH CHECK ADD  CONSTRAINT [FK__TravelReq__Emplo__46E78A0C] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TravelRequests] CHECK CONSTRAINT [FK__TravelReq__Emplo__46E78A0C]
GO
ALTER TABLE [dbo].[TravelRequests]  WITH CHECK ADD  CONSTRAINT [FK__TravelReq__Emplo__4CA06362] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TravelRequests] CHECK CONSTRAINT [FK__TravelReq__Emplo__4CA06362]
GO
ALTER TABLE [dbo].[TravelRequests]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypes] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypes] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserTypes] ([ID])
GO
