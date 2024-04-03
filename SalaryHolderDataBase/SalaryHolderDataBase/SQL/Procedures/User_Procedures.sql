go

create or alter procedure udp_User_GetAll
as
Begin
	begin try
		Select  
			UserID,
			UserName,
			UserPassword
		from UsersList
	end try
	begin catch
		print Error_Message() + 'something went wrong in users Get all'
	end catch
End

go
create or alter procedure udp_User_GetById
(
	@userID int
)
as
Begin
	begin try
		Select  
			UserID,
			UserName,
			UserPassword
		from UsersList
		where UserID = @userID
	end try
	begin catch
		print Error_Message() + 'something went wrong in users Get by id'
	end catch
End


go
create or alter procedure udp_User_Insert
(
	@User_Name NVARCHAR(255),
	@User_Password NVARCHAR(16)
)
as
Begin
	begin try
		insert into UsersList (UserName, UserPassword)
		values (@User_Name, @User_Password)
	end try
	begin catch
		print Error_Message() + 'something went wrong in users insert'
	end catch
End



go
create or alter procedure udp_User_Update
(
	@User_ID int,
	@User_Name NVARCHAR(255),
	@User_Password NVARCHAR(16)
)
as
Begin
	begin try
		 Update UsersList
		 Set
			UserName = @User_Name,
			UserPassword = @User_Password
		 where UserID = @User_ID
	end try
	begin catch
		print Error_Message() + 'something went wrong in users update'
	end catch
End

go
create or alter procedure udp_User_Delete
(
	@userID int
)
as
Begin
	begin try
		Delete from UsersList
		where UserID = @userID
	end try
	begin catch
		print Error_Message() + 'something went wrong in users Delete'
	end catch
End