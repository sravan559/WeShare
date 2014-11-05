
/****** Object:  StoredProcedure [dbo].[usp_groups]    Script Date: 11/04/2014 19:03:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_groups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_groups]
GO



/****** Object:  StoredProcedure [dbo].[usp_groups]    Script Date: 11/04/2014 19:03:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Varsha
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_groups] 
(
	@Group_Id NVARCHAR(50)=NULL,
	@Group_Name NVARCHAR(50)=NULL,
	@Action NVARCHAR(10)=NULL,
	@User_Id NVARCHAR(50)=NULL
)
AS
BEGIN
	IF @Action = 'C' -- create/save group details
		INSERT INTO Groups(Group_Name)
				   VALUES (@Group_Name)
	
	ELSE IF @Action = 'U'
		UPDATE Groups SET Group_Name=@Group_Name
						 WHERE Group_Id=@Group_Id
	
	ELSE IF @Action = 'R'
		SELECT Group_Id, Group_Name FROM Groups
		
	ELSE IF @Action = 'D'
		DELETE FROM Groups WHERE Group_Id=@Group_Id;
	
	ELSE IF @Action = 'DELETEUSERINGROUP'
		DELETE FROM UsersInGroups WHERE Group_Id=@Group_Id AND User_Id=@User_Id;
		
	ELSE IF @Action = 'ADDUSERINGROUP'
		INSERT INTO UsersInGroups(Group_Id,User_Id) VALUES (@Group_Id,@User_Id);
		
	ELSE IF @Action = 'GETUSERSINGROUP'
		SELECT USER_ID FROM UsersInGroups WHERE Group_Id=@Group_Id;
END

GO


