USE [EvolentHealth]
GO

/****** Object: Table [dbo].[PatientContacts] Script Date: 05-04-2020 13:28:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatientContacts] (
    [PatientId]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [LastName]     NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]  NVARCHAR (MAX) NOT NULL,
    [EmailAddress] NVARCHAR (MAX) NOT NULL,
    [Status]       BIT            NOT NULL
);


