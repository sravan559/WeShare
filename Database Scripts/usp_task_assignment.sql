/****** Object:  StoredProcedure [dbo].[usp_task_assignment]    Script Date: 10/10/2014 14:38:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_task_assignment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_task_assignment]
GO


/****** Object:  StoredProcedure [dbo].[usp_task_assignment]    Script Date: 10/10/2014 14:38:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_task_assignment]
(
@Task_Id INT=NULL,
@User_Id nvarchar(50)=NULL,
@Due_Date DATETIME =NULL,
@Status NVARCHAR(50)=NULL,
@Group_Name NVARCHAR(50)=NULL,
@Action NVARCHAR(20)
)
AS
BEGIN
	IF @Action='C'
		IF EXISTS(SELECT Task_Id from AssignedTasks where Task_Id=@Task_Id)
			UPDATE AssignedTasks SET User_Id=@User_Id,
								 Due_Date=@Due_Date,
								 Status=@Status
								 WHERE Task_Id=@Task_Id
		ELSE
			INSERT INTO AssignedTasks(Task_Id,User_Id,Due_Date,Status)
					VALUES(@Task_Id,@User_Id,@Due_Date,@Status)	
	ELSE IF @Action='UPDATESTATUS'
		 UPDATE AssignedTasks SET Status=@Status WHERE Task_Id=@Task_Id	
		 
	ELSE IF @Action='GETUNASSIGNEDTASKSBYGROUP' 		
		SELECT Task_Id,Task_Title,Task_Description,Points from Tasks where 
		Group_Name=@Group_Name and Task_Id NOT IN (SELECT Task_Id FROM AssignedTasks) 
		
	ELSE IF @Action='GETASSIGNEDTASKS'
		SELECT t.Task_Id,Task_Title,Task_Description,u.User_Id,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		from Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Task_Id
		inner join Users u on at.User_Id=u.User_Id
				
	ELSE IF @Action='GetTasksByEmailId'
		SELECT t.Task_Id,Task_Title,Task_Description,Due_Date,Status 
		from Tasks t INNER JOIN AssignedTasks at ON t.Task_Id=at.Task_Id 
		WHERE at.User_Id=@User_Id
		
	ELSE IF @Action='GetAllTasks'
		SELECT t.Task_Id,Task_Title,Task_Description,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		from Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Task_Id
		inner join Users u on at.User_Id=u.User_Id
				 	 	
		
END

GO


