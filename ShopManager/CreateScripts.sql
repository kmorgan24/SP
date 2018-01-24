-- Script Date: 1/23/2018 1:51 PM  - ErikEJ.SqlCeScripting version 3.5.2.74
CREATE TABLE [Cars] (
  [Id] INTEGER  NOT NULL
, [Make] text NOT NULL
, [Model] text NOT NULL
, [Year] bigint  NOT NULL
, [Vin] text NOT NULL
, [State] text NOT NULL
, [Plate] text NOT NULL
, [Owner] bigint  NOT NULL
, [ProdDate] text NULL
, CONSTRAINT [sqlite_master_PK_Cars] PRIMARY KEY ([Id])
);

CREATE TABLE [Customer] (
  [Id] INTEGER NOT NULL
, [FName] TEXT NOT NULL
, [LName] TEXT NOT NULL
, [SpouseID] INTEGER NULL
, [CompanyName] TEXT NULL
, CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);

CREATE TABLE [Address] (
  [Id] INTEGER NOT NULL
, [CustomerID] INTEGER NOT NULL
, [LineOne] TEXT NOT NULL
, [LineTwo] TEXT NULL
, [City] TEXT NOT NULL
, [State] TEXT NOT NULL
, [Zip] TEXT NOT NULL
, CONSTRAINT [PK_Address] PRIMARY KEY ([Id])
);

CREATE TABLE [PhoneNumbers] (
  [Id] INTEGER NOT NULL
, [CustomerID] INTEGER NOT NULL
, [Number] TEXT NOT NULL
, [Type] INTEGER NOT NULL
, CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY ([Id])
);

CREATE TABLE [Appointment] (
  [Id] INTEGER NOT NULL
, [CustomerID] INTEGER NOT NULL
, [CarID] INTEGER NOT NULL
, CONSTRAINT [PK_Appointment] PRIMARY KEY ([Id])
);

CREATE TABLE [Problems] (
  [Id] INTEGER NOT NULL
, [AppointmentID] INTEGER NOT NULL
, [ProblemDescription] TEXT NOT NULL
, CONSTRAINT [PK_Problems] PRIMARY KEY ([Id])
);

CREATE TABLE [Notes] (
  [Id] INTEGER NOT NULL
, [AppointmentID] INTEGER NULL
, [CustomerID] INTEGER NULL
, [CarID] INTEGER NULL
, [Description] TEXT NOT NULL
, [Active] INTEGER NOT NULL
, [Visible] INTEGER NOT NULL
, CONSTRAINT [PK_Notes] PRIMARY KEY ([Id])
);

CREATE TABLE [Labor] (
  [Id] INTEGER NOT NULL
, [AppointmentID] INTEGER NOT NULL
, [Hours] INTEGER NOT NULL
, [Description] TEXT NOT NULL
, [Complete] INTEGER NOT NULL
, CONSTRAINT [PK_Labor] PRIMARY KEY ([Id])
);

CREATE TABLE [Dates] (
  [Id] INTEGER NOT NULL
, [AppointmentID] INTEGER NOT NULL
, [Date] TEXT NOT NULL
, [Hours] INTEGER NOT NULL
, CONSTRAINT [PK_Dates] PRIMARY KEY ([Id])
);

CREATE TABLE [Part] (
  [Id] INTEGER NOT NULL
, [PartNumber] TEXT NOT NULL
, [PartName] TEXT NOT NULL
, [PartDescription] TEXT NOT NULL
, [InStock] INTEGER NOT NULL
, [Supplier] TEXT NOT NULL
, [WorkOrderID] INTEGER NOT NULL
, CONSTRAINT [PK_Part] PRIMARY KEY ([Id])
);


CREATE TABLE [Recomendations] (
  [Id] INTEGER NOT NULL
, [Description] TEXT NOT NULL
, [Active] INTEGER NOT NULL
, CONSTRAINT [PK_Recomendations] PRIMARY KEY ([Id])
);

CREATE TABLE [User] (
  [Id] INTEGER NOT NULL
, [Name] TEXT NOT NULL
, [LoginName] TEXT NOT NULL
, [Password] TEXT NOT NULL
, [LoggedIn] INTEGER NOT NULL
, [Active] INTEGER NOT NULL
, [Skill] INTEGER NOT NULL
, [TargetHours] INTEGER NOT NULL
, CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

CREATE TABLE [WorkOrder] (
  [Id] INTEGER NOT NULL
, [AppointmentID] INTEGER NOT NULL
, [TechnicianID] INTEGER NOT NULL
, CONSTRAINT [PK_WorkOrder] PRIMARY KEY ([Id])
);