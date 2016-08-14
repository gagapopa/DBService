USE [luxoftdatabase]
GO

/****** Object: SqlProcedure [dbo].[getUserLinks] Script Date: 8/14/2016 9:45:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[getUserLinks]
	@userIdent nvarchar(max)
AS

  
BEGIN TRY
    declare @Ident UNIQUEIDENTIFIER = CONVERT(UNIQUEIDENTIFIER, @userIdent)

    select 
        *, 
        (SELECT dbo.fnBase36(l.LinkId) as 'LinkId',l.UserId,l.FullUrl,l.ClicksNumber from dbo.Links l where l.UserId = u.UserId for xml PATH('Link'), TYPE, elements xsinil)
    from dbo.Users u
    where u.Identifier = @Ident
    for xml PATH('User'), ELEMENTS XSINIL

END TRY BEGIN CATCH

SELECT CAST('<ERROR>' + ERROR_MESSAGE() + '</ERROR>' as xml)

END CATCH;
