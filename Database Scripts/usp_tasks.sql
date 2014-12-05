
/****** Object:  StoredProcedure [dbo].[usp_tasks]    Script Date: 10/10/2014 14:37:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_tasks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_tasks]
GO


/****** Object:  StoredProcedure [dbo].[usp_tasks]    Script Date: 10/10/2014 14:37:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Varsha
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_tasks] 
(
	@Task_Id NVARCHAR(50)=NULL,
	@Task_Title NVARCHAR(50)=NULL,
	@Task_Description NVARCHAR(50)=NULL,
	@Points DECIMAL(18,2) = NULL,	
	@Task_Type NVARCHAR(50)= NULL,
	@Is_Task_Recursive NVARCHAR(50)=NULL,
	@Group_Name NVARCHAR(50)=NULL,
	@Action NVARCHAR(20) 
)
AS
BEGIN
	IF @Action = 'C' -- create/save task details
		INSERT INTO Tasks ( Task_Title, Task_Description, Points, Task_Type, Is_Task_Recursive,Group_Name)
				   VALUES ( @Task_Title,@Task_Description,@Points,@Task_Type,@Is_Task_Recursive,@Group_Name)
	
	ELSE IF @Action = 'U'
		UPDATE Tasks SET Task_Title=@Task_Title,
						 Task_Description=@Task_Description,
						 Points=@Points,
						 Task_Type=@Task_Type,
						 Is_Task_Recursive=@Is_Task_Recursive
						 WHERE Task_Id=@Task_Id
	
	ELSE IF @Action = 'R'
		SELECT Task_Id, Task_Title, Task_Description, Points,Task_Type,Is_Task_Recursive FROM Tasks
	
	ELSE IF @Action='GETTASKSBYGROUP'	
		SELECT Task_Id, Task_Title, Task_Description, Points,Task_Type,Is_Task_Recursive FROM Tasks
		WHERE Group_Name=@Group_Name
		
	ELSE IF @Action = 'D'
		BEGIN
			IF NOT EXISTS (SELECT Task_Id from AssignedTasks where Task_Id=@Task_Id)
				DELETE FROM Tasks WHERE Task_Id=@Task_Id
		END
	
	ELSE IF @Action= 'UPDATETASK' -- UPDATE THE DATA CORRESPONDING TO A SPECIFIC TASK BASED ON THE TASK_ID	
		UPDATE Tasks SET Points=@Points,
						 Task_Title=@Task_Title,
						 Task_Description=@Task_Description
					WHERE Task_Id=@Task_Id	
	
	ELSE IF @Action = 'UPDATEDTASKPOINTS'
		UPDATE Tasks SET Points=@Points WHERE Task_Id=@Task_Id;
		
END

GO


