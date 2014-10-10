
/****** Object:  StoredProcedure [dbo].[usp_task]    Script Date: 10/10/2014 14:37:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_task]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_task]
GO


/****** Object:  StoredProcedure [dbo].[usp_task]    Script Date: 10/10/2014 14:37:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Varsha
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_task] 
(
	@Task_Id NVARCHAR(50)=NULL,
	@Task_Title NVARCHAR(50)=NULL,
	@Task_Description NVARCHAR(50)=NULL,
	@Points NVARCHAR(20) = NULL,
	@Action NVARCHAR(10) = NULL
)
AS
BEGIN
	IF @Action = 'C' -- create/save task details
		INSERT INTO Tasks ( Task_Title, Task_Description, Points)
				   VALUES ( @Task_Title,@Task_Description,@Points)
	ELSE IF @Action = 'U'
		UPDATE Tasks SET Task_Title=@Task_Title,
						 Task_Description=@Task_Description,
						 Points=@Points
						 WHERE Task_Id=@Task_Id
	ELSE IF @Action = 'R'
		SELECT Task_Id, Task_Title, Task_Description, Points FROM Tasks
		
	ELSE IF @Action = 'D'
		DELETE FROM Tasks WHERE Task_Id=@Task_Id
	
	ELSE IF @Action= 'UPDATETASK' -- UPDATE THE DATA CORRESPONDING TO A SPECIFIC TASK BASED ON THE TASK_ID	
		UPDATE Tasks SET Points=@Points,
						 Task_Title=@Task_Title,
						 Task_Description=@Task_Description
					WHERE Task_Id=@Task_Id	
END

GO


