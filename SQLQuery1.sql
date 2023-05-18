CREATE TABLE [dbo].[st_fees] (
    [f_id]    INT          IDENTITY (1, 1) NOT NULL,
    [f_month] VARCHAR (50) NULL,
    [f_date]  VARCHAR (50) NULL,
    [f_fees]  INT          NULL,
  
    [s_id]    INT          NULL,
    PRIMARY KEY CLUSTERED ([f_id] ASC),
  
    FOREIGN KEY ([s_id]) REFERENCES [dbo].[std_info] ([s_id])
);

