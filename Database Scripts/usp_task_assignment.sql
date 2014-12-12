
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
@Date_Completed DATETIME =NULL,
@Status NVARCHAR(50)=NULL,
@Points_Assigned DECIMAL(18,2)=NULL,
@Group_Name NVARCHAR(50)=NULL,
@Action NVARCHAR(50)
)
AS
BEGIN
	IF @Action='C' -- Creates an instance of the task being assigned in the Assigned Tasks table
		BEGIN	
			SET @Points_Assigned=(SELECT Top 1 Points FROM Tasks where Task_Id=@Parent_Task_Id)
			INSERT INTO AssignedTasks(Parent_Task_Id,User_Id,Due_Date,Status,Points_Assigned)
					VALUES(@Parent_Task_Id,@User_Id,@Due_Date,@Status,@Points_Assigned)	
		END					
	ELSE IF @Action='MARKTASKASCOMPLETE'
		BEGIN --@Action='MARKTASKASCOMPLETE'
		 BEGIN TRAN	
		 UPDATE AssignedTasks SET Status=@Status ,
								Date_Completed= @Date_Completed											    
								WHERE Task_Id=@Task_Id
		 SET @Points_Assigned=(SELECT Points_Assigned FROM AssignedTasks where Task_Id=@Task_Id)	
		 SET @User_Id = (SELECT User_Id FROM AssignedTasks where Task_Id=@Task_Id)
		 SET @Parent_Task_Id= (SELECT Parent_Task_Id FROM AssignedTasks where Task_Id=@Task_Id)
		 SET @Group_Name= (SELECT Group_Name FROM Tasks where Task_Id= @Parent_Task_Id)	
		 						
		 UPDATE UsersInGroups SET Points_Due = Points_Due-@Points_Assigned 
									where User_Id=@User_Id and Group_Name=@Group_Name; 	
		 --recursive task implementation
		 declare @Is_Task_Recursive bit
		 set @Is_Task_Recursive =(SELECT IS_TASK_RECURSIVE FROM TASKS where Task_Id= @Parent_Task_Id)	
		 IF(@Is_Task_Recursive=1) --task is recursive so adding another taskinstance	
			begin --(@Is_Task_Recursive=1)
			 DECLARE @Task_Type nvarchar(50)
			 
			 set @Task_Type =(SELECT Task_Type FROM TASKS where Task_Id= @Parent_Task_Id)
			 set @Due_Date =(SELECT Due_Date FROM AssignedTasks where Task_Id= @Task_Id)
			 if(@Task_Type='Weekly')
				 SET @Due_Date= (select DATEADD(day,7,@due_date))
			 else if (@Task_Type='Montly')
				 SET @Due_Date= (select DATEADD(month,1,@due_date))
			
			INSERT INTO AssignedTasks(Parent_Task_Id,User_Id,Due_Date,Status,Points_Assigned)
					VALUES(@Parent_Task_Id,@User_Id,@Due_Date,'Pending',@Points_Assigned)	
			 				
			end	--(@Is_Task_Recursive=1)								
		 IF @@ERROR>0
			ROLLBACK
		 ELSE 
			COMMIT												
		END --@Action='MARKTASKASCOMPLETE'
	ELSE IF @Action='GETUNASSIGNEDTASKSBYGROUP' 		
		SELECT Task_Id,Task_Title,Task_Description,Points FROM Tasks where 
		Group_Name=@Group_Name and Task_Id NOT IN (SELECT Parent_Task_Id FROM AssignedTasks where Status<>'Completed') 
				
	ELSE IF @Action='GETASSIGNEDTASKSBYGROUP'
		SELECT t.Task_Id,Task_Title,Task_Description,u.User_Id,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		FROM Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Parent_Task_Id
		inner join Users u on at.User_Id=u.User_Id where t.Group_Name=@Group_Name and Status<>'Completed' 
					
	ELSE IF @Action='GETTASKSBYEMAILID'
		SELECT at.Task_Id,Task_Title,Points,Task_Description,Due_Date,Status 
		FROM Tasks t INNER JOIN AssignedTasks at ON t.Task_Id=at.Parent_Task_Id 
		WHERE at.User_Id=@User_Id and Status <> 'Completed'
		ORDER BY Due_Date 
	
	ELSE IF @Action = 'GETTASKPOINTS' 
		SELECT Points FROM Tasks t INNER JOIN AssignedTasks at ON t.Task_Id=at.Parent_Task_Id  WHERE Parent_Task_Id=@Parent_Task_Id
		
	ELSE IF @Action='GETROOMMATESTASKS'
		SELECT at.Task_Id,Task_Title,Task_Description,First_Name+', '+Last_Name as 'User_Name', Due_Date,Status 
		FROM Tasks t inner join AssignedTasks at 
		on t.Task_Id=at.Parent_Task_Id
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