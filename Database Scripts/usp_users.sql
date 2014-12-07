/****** Object:  StoredProcedure [dbo].[usp_users]    Script Date: 10/10/2014 14:19:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_users]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_users]
GO

/****** Object:  StoredProcedure [dbo].[usp_users]    Script Date: 10/10/2014 14:19:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sravan
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_users] 
	(
	@User_Id nvarchar(50)=NULL,
	@First_Name nvarchar(50)=NULL,
	@Last_Name nvarchar(50)=NULL,
	@Contact_Number nvarchar(20) = NULL,
	@Password nvarchar(20) = NULL,
	@Action nvarchar(20) = NULL,
	@Next_Recurrence_Date datetime =NULL,
	@Recurrence_Start_Date datetime=NULL,
	@Group_Name nvarchar(50) =NULL,
	@Points_To_Add decimal(18,2)=NULL
	)
AS
BEGIN
	IF @Action = 'C' -- create/save user details
		BEGIN		
		IF NOT EXISTS (SELECT First_Name FROM Users WHERE User_Id=@User_Id)
			INSERT INTO Users (User_Id, First_Name, Last_Name, Contact_Number, [Password])
			   VALUES (@User_Id, @First_Name,@Last_Name,@Contact_Number,@Password)
		END		   
	ELSE IF @Action = 'R'
		SELECT User_Id,First_Name+', '+Last_Name as 'Name', First_Name, Last_Name, Contact_Number FROM Users
		
	ELSE IF @Action = 'D'
		DELETE FROM Users WHERE User_Id=@User_Id
	
	ELSE IF @Action= 'UPDATEUSER' -- UPDATE THE DATA CORRESPONDING TO A SPECIFIC USER BASED ON THE User_Id	
		UPDATE Users SET First_Name=@First_Name,
						 Last_Name=@Last_Name,
						 Contact_Number=@Contact_Number
					WHERE User_Id=@User_Id	
										
	ELSE IF @Action = 'VALIDATEUSER' -- VERIFIES THE PASSWORD ENTERED BY THE USER
		BEGIN --@Action = 'VALIDATEUSER'
			IF EXISTS (SELECT USER_ID from Users where User_Id=@User_Id AND password=@Password)
				BEGIN --begin valid user
					SET @Group_name=(select top 1 group_name from UsersInGroups where User_Id=@User_Id)
					SET @Next_Recurrence_Date =(select Next_Recurrence_Date from UsersInGroups where User_Id=@User_Id and Group_Name=@Group_Name)
					DECLARE @Effective_System_date datetime
					SET @Effective_System_date= (select DATEADD(day,cast((select value from Appconfiguration where [KEY]='DATE_INCREMENT_VALUE')as int),GETDATE()))
					IF(DATEDIFF(day,@Next_Recurrence_Date,@Effective_System_date)>-1)
						BEGIN -- start update weekly points
							declare @Weekly_Points decimal(18,2)
							set @Weekly_Points=(select Weekly_Points from UsersInGroups where User_Id=@User_Id and Group_Name=@Group_Name)
							declare @DaysDifference int
							set @DaysDifference= (select DATEDIFF(day,@Next_Recurrence_Date,@Effective_System_date))
							declare @Effective_Weeks int
							SET @Effective_Weeks= (@DaysDifference/7+1)
							declare @New_Recurrence_Date datetime
							set @New_Recurrence_Date=(select dateadd(day,(@DaysDifference/7+1)*7,@Next_Recurrence_Date))		
							
							set @Points_To_Add=(select (@DaysDifference/7+1)*@Weekly_Points)
							UPDATE UsersInGroups set Points_Due=Points_Due + @Points_To_Add,
													Next_Recurrence_Date=@New_Recurrence_Date						
													where User_Id=@User_Id and Group_Name=@Group_Name				
						END--end update weekly points	
					SELECT 'TRUE' as 'RESULT'
					
				END--end valid user						 
		END --@Action = 'VALIDATEUSER'
END
GO


