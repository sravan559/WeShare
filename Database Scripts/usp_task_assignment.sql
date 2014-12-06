
/****** Object:  StoredProcedure [dbo].[usp_task_assignment]    Script Date: 12/05/2014 21:48:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_task_assignment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_task_assignment]
GO

/****** Object:  StoredProcedure [dbo].[usp_task_assignment]    Script Date: 12/05/2014 21:48:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:	Sravan	
-- Create date: 
-- Description:	Used to handle requests related to the task assignment to the users
-- =============================================
CREATE PROCEDURE [dbo].[usp_task_assignment]
(
@Task_Id INT=NULL,
@Parent_Task_Id INT =NULL,
@User_Id nvarchar(50)=NULL,
@Due_Date DATETIME =NULL,
@Status NVARCHAR(50)=NULL,
@Points_Assigned DECIMAL(18,2)=NULL,
@Group_Name NVARCHAR(50)=NULL,
@Action NVARCHAR(50)
)
AS
BEGIN
	IF @Action='C' -- Creates an instance of the task being assigned in the Assigned Tasks table
		BEGIN	
			SET @Points_Assigned=(select Top 1 Points from Tasks where Task_Id=@Parent_Task_Id)
			INSERT INTO AssignedTasks(Parent_Task_Id,User_Id,Due_Date,Status,Points_Assigned)
					VALUES(@Parent_Task_Id,@User_Id,@Due_Date,@Status,@Points_Assigned)	
		END					
	ELSE IF @Action='UPDATESTATUS'
		 UPDATE AssignedTasks SET Status=@Status ,
								Date_Completed= CASE WHEN (@Status='Completed') then GetDate()
											    ELSE NULL END
								WHERE Task_Id=@Task_Id	
		 
	ELSE IF @Action='GETUNASSIGNEDTASKSBYGROUP' 		
		SELECT Task_Id,Task_Title,Task_Description,Points from Tasks where 
		Group_Name=@Group_Name and Task_Id NOT IN (SELECT Task_Id FROM AssignedTasks) 
				
	ELSE IF @Action='GETASSIGNEDTASKSBYGROUP'
		SELECT t.Task_Id,Task_Title,Task_Description,u.User_Id,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		from Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Task_Id
		inner join Users u on at.User_Id=u.User_Id where t.Group_Name=@Group_Name
					
	ELSE IF @Action='GETTASKSBYEMAILID'
		SELECT t.Task_Id,Task_Title,Points,Task_Description,Due_Date,Status 
		from Tasks t INNER JOIN AssignedTasks at ON t.Task_Id=at.Task_Id 
		WHERE at.User_Id=@User_Id and Status <> 'Completed'
		ORDER BY Due_Date 
		
	ELSE IF @Action='GETROOMMATESTASKS'
		SELECT t.Task_Id,Task_Title,Task_Description,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		from Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Task_Id
		INNER JOIN Users u on at.User_Id=u.User_Id
		where u.User_Id <> @User_Id
		
	ELSE IF @Action='REASSIGNTASK'
		UPDATE 	AssignedTasks SET User_Id=@User_Id,
								  Due_Date = CASE WHEN (@Due_Date IS NULL or @Due_Date = '')then Due_Date
											 ELSE @Due_Date	
											 END											 
									WHERE Task_Id=@Task_Id
		
END

GO