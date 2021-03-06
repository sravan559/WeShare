/****** Object:  StoredProcedure [dbo].[usp_groups]    Script Date: 12/03/2014 21:08:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_groups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_groups]
GO

/****** Object:  StoredProcedure [dbo].[usp_groups]    Script Date: 12/03/2014 21:08:24 ******/
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
	@User_Id NVARCHAR(50)=NULL,
	@Weekly_Points DECIMAL(18,2)=NULL,
	@Points_Due decimal (18,2)=NULL,
	@Task_Points decimal(18,2)=NULL,
	@Recurrence_Start_Date DATETIME = NULL,
	@Action NVARCHAR(50)
)
AS
BEGIN
	IF @Action = 'C' -- create/save group details
		BEGIN
			IF NOT EXISTS (SELECT Group_Name FROM Groups WHERE Group_Name in (@Group_Name,@New_Group_Name))
			BEGIN
				BEGIN TRAN
				
				INSERT INTO Groups(Group_Name) VALUES (@New_Group_Name)
				INSERT INTO UsersInGroups (Group_Name,User_Id,Weekly_Points,Points_Due) VALUES(@New_Group_Name,@User_Id,40,40)
				IF(@@ERROR>0)
					ROLLBACK TRAN
				ELSE 
					COMMIT TRAN	
			END	
		END	
	
	ELSE IF @Action = 'U'
		BEGIN
		 if not exists (select Group_Name from Groups where Group_Name=@New_Group_Name)
			 BEGIN
				 UPDATE Groups SET Group_Name=@New_Group_Name
									 WHERE Group_Name=@Group_Name
				
				 UPDATE UsersInGroups set Group_Name=@New_Group_Name	WHERE Group_Name=@Group_Name
			 END
		END
	
	ELSE IF @Action = 'R'
		SELECT Group_Name from UsersInGroups where User_Id=@User_Id
		
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
			INSERT INTO UsersInGroups(Group_Name,User_Id,Weekly_Points,Recurrence_Start_Date,Next_Recurrence_Date) VALUES (@Group_Name,@User_Id,@Weekly_Points,@Recurrence_Start_Date,@Recurrence_Start_Date)
			IF EXISTS (select USER_ID from  UsersInGroups WHERE Group_Name=@Group_Name and User_Id=@User_Id ) 
			UPDATE UsersInGroups SET Weekly_Points=@Weekly_Points,Recurrence_Start_Date=@Recurrence_Start_Date,Next_Recurrence_Date=@Recurrence_Start_Date WHERE Group_Name=@Group_Name and User_Id=@User_Id
		END
	ELSE IF @Action = 'GETUSERSINGROUP'
		SELECT ug.USER_ID, First_Name+', '+Last_Name as 'Name',Weekly_Points,Recurrence_Start_Date
		FROM UsersInGroups ug left join Users u on u.User_Id=ug.User_Id 
		WHERE Group_Name=@Group_Name
		
	ELSE IF @Action = 'GETACTIVEUSERSINGROUP' -- List of users who are already registered on the site
		SELECT u.USER_ID, First_Name+', '+Last_Name as 'Name', Weekly_Points,Recurrence_Start_Date
		FROM UsersInGroups ug inner join Users u on u.User_Id=ug.User_Id  
		WHERE Group_Name=@Group_Name	
		
	ELSE IF @Action = 'GETPOINTSDUE'
		SELECT Top 1 Points_Due FROM UsersInGroups WHERE User_Id=@User_Id;
		
	ELSE IF @Action = 'UPDATEPOINTSDUE' -- Reduce the points due once the user completes a task
		UPDATE UsersInGroups SET Points_Due = Points_Due-@Task_Points 
		where User_Id=@User_Id 
		--and Group_Name=@Group_Name;  
END


GO


