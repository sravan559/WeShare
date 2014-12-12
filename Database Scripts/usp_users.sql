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
	@Next_Recurrence_Date datetime =NULL,
	@Recurrence_Start_Date datetime=NULL,
	@Group_Name nvarchar(50) =NULL,
	@Points_To_Add decimal(18,2)=NULL,
	@Date_Offset INT =0,
	@Effective_Date datetime=NULL,
	@Action nvarchar(50) = NULL
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
	ELSE IF @Action='SAVEDATEOFFSET'
		BEGIN
			DECLARE @NEW_EFFECTIVE_DATE DATETIME
			DECLARE @CURRENT_EFFECTIVE_DATE DATETIME			
			declare @Current_Offset int
			SET @NEW_EFFECTIVE_DATE= (select DATEADD(day,isnull(@DATE_OFFSET,0),GETDATE()))			
			IF EXISTS(SELECT VALUE FROM AppConfiguration where [KEY]='DATE_OFFSET')
				BEGIN -- BEGIN UPDATE
					set @Current_Offset=(SELECT VALUE FROM AppConfiguration WHERE [KEY]='DATE_OFFSET')										
					--set @CURRENT_EFFECTIVE_DATE = (SELECT Effective_System_Date FROM AppConfiguration WHERE [KEY]='DATE_OFFSET')		
					--set @CURRENT_EFFECTIVE_DATE = (select DATEADD(day,isnull(@Current_Offset,0),GETDATE())) --current date will be system date + offset
					--above line needs to be tested
					IF(ISNULL(DATEDIFF(DAY,GETDATE(),@NEW_EFFECTIVE_DATE),0)>= 0) -- CHECK IF USER IS TRYING TO GO BACKTO AN EARLIER DATE
						BEGIN -- begin isnull
							UPDATE AppConfiguration SET VALUE=@Date_Offset
												WHERE [KEY]='DATE_OFFSET'
							EXEC USP_USERS @User_Id=@User_Id,@Action='CALCULATEWEEKLYPOINTS'					
						END -- end isnull
												
				END --END UPDATE				
			ELSE
				INSERT INTO APPCONFIGURATION([KEY],VALUE) VALUES('DATE_OFFSET',@DATE_OFFSET)
		END
	ELSE IF @Action='GETDATEOFFSET'
		SELECT VALUE FROM AppConfiguration WHERE [KEY]='DATE_OFFSET'				
										
	ELSE IF @Action = 'VALIDATEUSER' -- VERIFIES THE PASSWORD ENTERED BY THE USER
		BEGIN --@Action = 'VALIDATEUSER'
			IF EXISTS (SELECT USER_ID from Users where User_Id=@User_Id AND password=@Password)
				BEGIN --begin valid user
					EXEC USP_USERS 	@User_Id=@User_Id, @Action='CALCULATEWEEKLYPOINTS'
					SELECT 'TRUE' as 'RESULT'
				END--end valid user						 
		END --@Action = 'VALIDATEUSER'
	ELSE IF @Action='CALCULATEWEEKLYPOINTS' 
		BEGIN --@Action='CALCULATEWEEKLYPOINTS'
			SET @Group_name=(select top 1 group_name from UsersInGroups where User_Id=@User_Id)
			SET @Next_Recurrence_Date =(select Next_Recurrence_Date from UsersInGroups where User_Id=@User_Id and Group_Name=@Group_Name)
			DECLARE @Effective_System_date datetime
			SET @Effective_System_date= (select DATEADD(day,isnull(cast((select value from Appconfiguration where [KEY]='DATE_OFFSET')as int),0),GETDATE()))
			--set @Next_Recurrence_Date=(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, @Next_Recurrence_Date)))
			--set @Effective_System_date=(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, @Effective_System_date)))
			
			IF(DATEDIFF(day,@Next_Recurrence_Date,@Effective_System_date)>-1)
				BEGIN -- start update weekly points
					DECLARE @Weekly_Points decimal(18,2)
					SET @Weekly_Points=(select Weekly_Points from UsersInGroups where User_Id=@User_Id and Group_Name=@Group_Name)
					DECLARE @DaysDifference int
					SET @DaysDifference= (select DATEDIFF(day,@Next_Recurrence_Date,@Effective_System_date))
					DECLARE @Effective_Weeks int
					SET @Effective_Weeks= (@DaysDifference/7+1)
					DECLARE @New_Recurrence_Date datetime
					SET @New_Recurrence_Date=(select dateadd(day,(@DaysDifference/7+1)*7,@Next_Recurrence_Date))		
					
					SET @Points_To_Add=(select (@DaysDifference/7+1)*@Weekly_Points)
					set @New_Recurrence_Date=(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, @New_Recurrence_Date)))
					UPDATE UsersInGroups SET Points_Due=Points_Due + @Points_To_Add,
											Next_Recurrence_Date=@New_Recurrence_Date						
											where User_Id=@User_Id and Group_Name=@Group_Name
														
				END--end update weekly points
		END	--@Action='CALCULATEWEEKLYPOINTS'
		
END
GO


