go
create or alter procedure udp_Bogcha_GetAll
	@userID int
as
Begin
	begin try
		select 
			BogCha_ID,
			Title,
			Description,
			HireDate,
			FireDate,
			Salary,
			IsWorking,
			GroupAmount,
			ZavName,
			UserID
		from Bogcha
		where UserID = @userID
	end try
	begin catch
		print Error_Message() + 'something went wrong in Bogcha Get all'
	end catch
End


go
create or alter procedure udp_Bogcha_GetByID
	@userID int,
	@BogCha_ID int
as
Begin
	begin try
		select 
			BogCha_ID,
			Title,
			Description,
			HireDate,
			FireDate,
			Salary,
			IsWorking,
			GroupAmount,
			ZavName,
			UserID
		from Bogcha
		where UserID = @userID 
		and BogCha_ID = @BogCha_ID
	end try
	begin catch
		print Error_Message() + 'something went wrong in Bogcha Get by id'
	end catch
End


go
create or alter procedure udp_Bogcha_Insert
	@Title NVARCHAR(255),
	@Description NVARCHAR(255),
	@HireDate DATETIME,
	@FireDate DATETIME,
	@Salary DECIMAL(10,2),
	@IsWorking BIT,
	@GroupAmount INT,
	@ZavName NVARCHAR(255),
	@UserID int
as
Begin
	begin try
		insert into Bogcha (Title, Description, HireDate, FireDate, Salary, IsWorking, GroupAmount, ZavName, UserID )
		values (@Title, @Description, @HireDate, @FireDate, @Salary, @IsWorking, @GroupAmount, @ZavName, @UserID)
	end try
	begin catch
		print Error_Message() + 'something went wrong in Bogcha Insert'
	end catch
End


go
create or alter procedure udp_Bogcha_Update
	@BogCha_ID int,
	@Title NVARCHAR(255),
	@Description NVARCHAR(255),
	@HireDate DATETIME,
	@FireDate DATETIME,
	@Salary DECIMAL(10,2),
	@IsWorking BIT,
	@GroupAmount INT,
	@ZavName NVARCHAR(255),
	@UserID int
as
Begin
	begin try
		Update Bogcha
		Set
			Title = @Title,
			Description = @Description,
			HireDate = @HireDate,
			FireDate = @FireDate,
			Salary = @Salary,
			IsWorking = @IsWorking,
			GroupAmount = @GroupAmount,
			ZavName = @ZavName
		Where BogCha_ID = @BogCha_ID
		and UserID = @UserID
	end try
	begin catch
		print Error_Message() + 'something went wrong in Bogcha Update'
	end catch
End



go
create or alter procedure udp_Bogcha_Delete
	@userID int,
	@BogCha_ID int
as
Begin
	begin try
		Delete from Bogcha
		where UserID = @userID 
		and BogCha_ID = @BogCha_ID
	end try
	begin catch
		print Error_Message() + 'something went wrong in Bogcha Delete'
	end catch
End
