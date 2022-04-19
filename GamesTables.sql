CREATE SCHEMA Games;
GO

/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE Games.titles (
    [gameID] INT NOT NULL PRIMARY KEY IDENTITY,
    [title] NVARCHAR (255) NOT NULL,
    [genre] NVARCHAR (255) NOT NULL
)

/*******************************************************************************
   DROP Tables
********************************************************************************/

-- DROP TABLE Games.titles;

/*******************************************************************************
    Populate Table
********************************************************************************/

INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Heart of Darkness', N'Roleplaying');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Fable', N'Roleplaying');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Halo', N'Shooter');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Call of Duty', N'Shooter');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Forza', N'Racing');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Need for Speed', N'Racing');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Microsoft Flight Simulator', N'Simulator');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'American Truck Simulator', N'Simulator');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'World of Warcraft', N'Massive Online Multiplayer');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Lost Ark', N'Massive Online Multiplayer');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'StarCraft', N'Real-time Strategy');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Dead by Daylight', N'Surv-Horror');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Rust', N'Survival');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'Ark', N'Survival');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'League of Legends', N'MOBA');
INSERT INTO [Games].[titles] ([title], [genre]) VALUES (N'DOTA2', N'MOBA');