go
create or alter procedure udp_SalTable_GetAll
	@userID int
as
Begin
	begin try
		select 
			Sal_ID,
			SalaryDate,
			SalaryAmount,
			Description,
			BogCha_ID
		from SalaryTable
		where UserID = @userID
		order by Sal_ID desc
	end try
	begin catch
		print Error_Message() + 'something went wrong in SalTable Get all'
	end catch
End


go
create or alter procedure udp_SalTable_GetByID
	@userID int,
	@Sal_ID int
as
Begin
	begin try
		select 
			Sal_ID,
			SalaryDate,
			SalaryAmount,
			Description,
			BogCha_ID
		from SalaryTable
		where UserID = @userID 
		and Sal_ID = @Sal_ID
	end try
	begin catch
		print Error_Message() + 'something went wrong in SalTable Get by id'
	end catch
End


go
create or alter procedure udp_SalTable_Insert
	@SalaryDate DATETIME,
	@SalaryAmount DECIMAL(10, 2),
	@Description NVARCHAR(200),
	@BogCha_ID INT,
	@UserID INT
as
Begin
	begin try
		Insert into SalaryTable (SalaryDate, SalaryAmount, Description, BogCha_ID, UserID)
		values (@SalaryDate, @SalaryAmount, @Description, @BogCha_ID, @UserID)
	end try
	begin catch
		print Error_Message() + 'something went wrong in SalTable Insert'
	end catch
End


go
create or alter procedure udp_SalTable_Update
	@Sal_ID int,
	@SalaryDate DATETIME,
	@SalaryAmount DECIMAL(10, 2),
	@Description NVARCHAR(200),
	@BogCha_ID INT,
	@UserID INT
as
Begin
	begin try
		Update SalaryTable
		Set
			SalaryDate = @SalaryDate,
			SalaryAmount = @SalaryAmount,
			Description = @Description,
			BogCha_ID = @BogCha_ID
		Where Sal_ID = @Sal_ID
		and UserID = @UserID
	end try
	begin catch
		print Error_Message() + 'something went wrong in SalTable Update'
	end catch
End



go
create or alter procedure udp_SalTable_Delete
	@userID int,
	@Sal_ID int
as
Begin
	begin try
		Delete from SalaryTable
		where UserID = @userID 
		and Sal_ID = @Sal_ID
	end try
	begin catch
		print Error_Message() + 'something went wrong in SalTable Delete'
	end catch
End
