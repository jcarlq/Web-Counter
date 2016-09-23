CREATE TABLE [dbo].[Count] (
    [Count]       INT      NOT NULL,
    [Update_Date] DATETIME CONSTRAINT [DF_Count_Update_Date] DEFAULT (getdate()) NOT NULL 
);

