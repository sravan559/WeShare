GO

/****** Object:  StoredProcedure [dbo].[usp_users]    Script Date: 10/10/2014 14:19:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_users]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_users]
GO

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
	@Action nvarchar(10) = NULL
	)
AS
BEGIN
	IF @Action = 'C' -- create/save user details
		IF EXISTS(SELECT First_name from Users where User_Id=@User_Id)
			UPDATE Users SET First_Name=@First_Name,
							 Last_Name=@Last_Name,
							 Contact_Number=@Contact_Number							 
							 WHERE User_Id=@User_Id
		ELSE
			INSERT INTO Users (User_Id, First_Name, Last_Name, Contact_Number, [Password])
				   VALUES (@User_Id, @First_Name,@Last_Name,@Contact_Number,@Password)
				   
	ELSE IF @Action = 'R'
		SELECT User_Id,First_Name+', '+Last_Name as 'Name', First_Name, Last_Name, Contact_Number FROM Users
		
	ELSE IF @Action = 'D'
		DELETE FROM Users WHERE User_Id=@User_Id
	
	ELSE IF @Action= 'UPDATEUSER' -- UPDATE THE DATA CORRESPONDING TO A SPECIFIC USER BASED ON THE User_Id	
		UPDATE Users SET First_Name=@First_Name,
						 Last_Name=@Last_Name,
						 Contact_Number=@Contact_Number
					WHERE User_Id=@User_Id						
	ELSE IF @Action = 'CHECK_USER' -- VERIFIES THE PASSWORD ENTERED BY THE USER
		SELECT [Password] from Users where User_Id=@User_Id					 
	END
	
GO


