USE [luxoftdatabase]
GO

/****** Object: SqlProcedure [dbo].[incrementLink] Script Date: 8/14/2016 10:20:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[incrementLink]
	@LinkId int
AS
BEGIN TRANSACTION;
  
BEGIN TRY

    update dbo.Links
    set ClicksNumber = ClicksNumber + 1
    where LinkId = @LinkId

    SELECT CAST('<FULLURL>' + fullUrl + '</FULLURL>' as xml) from Links where LinkId = @LinkId


END TRY BEGIN CATCH

SELECT CAST('<ERROR>' + ERROR_MESSAGE() + '</ERROR>' as xml);

IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
END CATCH;
  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;
