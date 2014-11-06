
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
	@Group_Name NVARCHAR(50)=NULL,
	@New_Group_Name nvarchar(50)=NULL,
	@Action NVARCHAR(20)=NULL,
	@User_Id NVARCHAR(50)=NULL
)
AS
BEGIN
	IF @Action = 'C' -- create/save group details
		BEGIN
			IF NOT EXISTS (SELECT Group_Name FROM Groups WHERE Group_Name in (@Group_Name,@New_Group_Name))
			BEGIN
				BEGIN TRAN
				
				INSERT INTO Groups(Group_Name) VALUES (@Group_Name)
				INSERT INTO UsersInGroups (Group_Name,User_Id) VALUES(@Group_Name,@User_Id)
				IF(@@ERROR>0)
					ROLLBACK TRAN
				ELSE 
					COMMIT TRAN	
			END	
		END	
	
	ELSE IF @Action = 'U'
		UPDATE Groups SET Group_Name=@New_Group_Name
						 WHERE Group_Name=@Group_Name
	
	ELSE IF @Action = 'R'
		SELECT Group_Name FROM Groups
		
	ELSE IF @Action = 'D'
		BEGIN
			IF NOT EXISTS (select USER_ID from UsersInGroups where Group_Name=@Group_Name)
				DELETE FROM Groups WHERE Group_Name=@Group_Name;
		END
	ELSE IF @Action = 'DELETEUSERINGROUP'
		DELETE FROM UsersInGroups WHERE Group_Name=@Group_Name AND User_Id=@User_Id;
		
	ELSE IF @Action = 'ADDUSERTOGROUP'
		BEGIN
		IF NOT EXISTS(SELECT USER_ID FROM UsersInGroups WHERE Group_Name=@Group_Name and User_Id=@User_Id)
		INSERT INTO UsersInGroups(Group_Name,User_Id) VALUES (@Group_Name,@User_Id);
		END
	ELSE IF @Action = 'GETUSERSINGROUP'
		SELECT USER_ID FROM UsersInGroups WHERE Group_Name=@Group_Name
		
	ELSE IF @Action = 'GETACTIVEUSERSINGROUP' -- List of users who are already registered on the site
		SELECT USER_ID FROM UsersInGroups WHERE Group_Name=@Group_Name	
END

GO


