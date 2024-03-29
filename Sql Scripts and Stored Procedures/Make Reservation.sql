USE [AirBB]
GO
/****** Object:  StoredProcedure [dbo].[MakeReservation]    Script Date: 3/9/2024 9:57:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MakeReservation]
	-- Add the parameters for the stored procedure here

	
	--declare
@Email nvarchar(100) = 'a@gmail.com',
	@Phone nvarchar(50) = null
	
AS
Begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF OBJECT_ID('tempdb..#ClientTempEmail') IS NOT NULL DROP TABLE #ClientTempEmail
	IF OBJECT_ID('tempdb..#ClientTempPhone') IS NOT NULL DROP TABLE #ClientTempPhone


    -- Insert statements for procedure here
	SELECT m.Id
	into #ClientTempEmail
	from MyClient m
	where Trim(m.Email) = Trim(@Email)

		SELECT m.Id
	into #ClientTempPhone
	from MyClient m
	where Trim(m.Phone) = Trim(@Phone)

	if (Exists(

	select *
	from #ClientTempEmail
	) )
	
	Begin

	Declare @ClientId bigint = (Select top (1) cte.Id From #clientTempEmail cte)
	--find available room

	Declare @RoomId int = (Select top (1) mr.Id From MyRoom mr Where mr.BeingUsed = 0)
	--already a user
		If (@RoomId is not null)
		Begin
			Begin Try
			Begin Tran
			Insert into MyReservation(ClientId, RoomId)
			Values(@ClientId , @RoomId)

			UPDATE myrm
			Set myrm.BeingUsed = 1
			From MyRoom myrm
			Where myrm.Id = @RoomId
			Commit

			
			Select 'Good Insert By Email'[Message], mc.Id[ClientId], mc.FirstName, 
			mc.LastName, mc.Phone, mc.Email, 
			mr.BeingUsed, mr.RoomNumber, mres.Id[ReservationId]
			From MyClient mc
			Join MyReservation mres on mres.ClientId = mc.Id
			Join MyRoom mr on mr.Id = mres.RoomId

			End Try
			Begin Catch
				rollback
				Select 'Error occurred by email. Try again to make a reservation'[Message], null, null,
				null, null, null,
				null, null, null
			End Catch
		End -- end if @room is not null
		Else
		Begin
			
			Select 'No room available by email'[Message], @ClientId, null,
			null, null, null,
			null, null, null
		End
	End
	Else
	Begin
	 --Is the phone number a match?
	 If (Exists(Select * from #ClientTempPhone))
	 Begin
		Declare @ClientIdPh bigint = (select top (1) cte.Id From #ClientTempPhone cte)
		--find available room

		Declare @RoomIdPh int = (Select top (1) mr.Id From MyRoom mr Where mr.BeingUsed = 0)
		if (@RoomId is not null)
		Begin
			Begin Try
				Begin Tran
				Insert Into MyReservation(ClientId, RoomId)
				Values(@ClientId , @RoomId)

				UPDATE myrm
				Set myrm.BeingUsed = 1
				From MyRoom myrm
				Where myrm.Id = @RoomId
				Commit
				Select 'Good Insert By Phone'[Message], mc.Id[ClientId], mc.FirstName, 
				mc.LastName, mc.Phone, mc.Email, 
				mr.BeingUsed, mr.RoomNumber, mres.Id[ReservationId]
				From MyClient mc
				Join MyReservation mres on mres.ClientId = mc.Id
				Join MyRoom mr on mr.Id = mres.RoomId


			End Try
			Begin Catch
				rollback
				Select 'Error occurred by phone. Try again to make a reservation'[Message], null, null,
				null, null, null,
				null, null, null
			End Catch
		End -- end if @room is not null
		Else
		Begin
			Select 'No room available by phone'[Message], @ClientId, null,
			null, null, null,
			null, null, null
		End
	 End
	 Else
		Begin
			Select 'Create a client with an email address or phone number before creating reservation'[Message], null, null,
			null, null, null,
			null, null, null
		End
	End
End
