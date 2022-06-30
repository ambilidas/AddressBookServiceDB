create procedure InsertIntoTable_SP
(
	@FirstName varchar(200),
	@LastName varchar(200),
	@Address varchar(200),
	@City varchar(200),
	@State varchar(200),
	@Zip bigint,
	@PhoneNumber bigint,
	@Email varchar(200),
	@name varchar(200),
	@Type varchar(200)
)
as
begin
 insert into AddressBook values(@FirstName,
	@LastName,
	@Address,
	@City,
	@State,
	@Zip,
	@PhoneNumber,
	@Email,
	@name,
	@Type);
end
