USE [luxoftdatabase]
GO

/****** Object: SqlProcedure [dbo].[insertLinkOrCreateUser] Script Date: 8/14/2016 8:37:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[insertLinkOrCreateUser]
	@fullLink nvarchar(max),
	@UserId int = null
AS
BEGIN TRANSACTION;
  
  
BEGIN TRY
if @UserId is not null and exists(select top 1 * from dbo.Users where UserId = @UserId)
    begin
        insert INTO dbo.Links VALUES(@UserId,@fullLink,0)


        select 
            *, 
            (SELECT dbo.fnBase36(l.LinkId) as 'LinkId',l.UserId,l.FullUrl,l.ClicksNumber from dbo.Links l where l.UserId = u.UserId for xml PATH('Link'), TYPE, elements xsinil)
        from dbo.Users u
        where u.UserId = @UserId
        for xml PATH('User'), ELEMENTS XSINIL
    end
else
    begin
        INSERT INTO dbo.Users VALUES(DEFAULT)

        DECLARE @newUserId int = (select top 1 UserId from dbo.Users order by UserId desc)

        INSERT INTO dbo.Links VALUES(@newUserId,@fullLink,0)

        select 
            *, 
            (SELECT dbo.fnBase36(l.LinkId) as 'LinkId',l.UserId,l.FullUrl,l.ClicksNumber from dbo.Links l where l.UserId = u.UserId for xml PATH('Link'), TYPE, elements xsinil)
        from dbo.Users u
        where u.UserId = @newUserId
        for xml PATH('User'), ELEMENTS XSINIL
    end

END TRY BEGIN CATCH

SELECT CAST('<ERROR>' + ERROR_MESSAGE() + '</ERROR>' as xml);

IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
END CATCH;
  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;
