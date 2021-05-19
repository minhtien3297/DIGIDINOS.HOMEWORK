use REPORT_MANAGER
go

-- đặt tên proc: 
-- proc_<chức năng>_<tên bảng>
create procedure proc_CRUD_teams
	-- type data phải trùng với data type đã tạo trong file table.sql
	-- các đối số luôn phải đặt là null, tiết kiệm thời gian nhập dữ liệu 
	@select int = null, -- select này để phân các chức năng như  search, insert, update, delete...
	
	@id int = null,
	@name nvarchar(max) = null
as 
begin
	if(@select = 1) -- search by name
	begin 
		select * 
		from teams
		where teams.name like '%' + @name + '%'

		select 'search'
	end
	
	if(@select = 2)	-- insert
	begin 
		insert into teams
		(
			name
		)
		values 
		(
			@name
		)

		if @@rowcount > 0 -- rowcount: kiểm tra thay đổi trong bảng, nếu nó có thay đổi thì trả về 1 table[0][0] = 'insert'
			select 'insert'
		else 
			select 'bảng chưa được thêm mới'
	end

	if(@select = 3) -- update
	begin 
		update teams
		set
			name = @name
		where id = @id

		if @@rowcount = 0
			print 'bảng chưa được cập nhật'

		select 'update'
	end

	if(@select = 4) -- delete
	begin 
		delete from teams
		where teams.id = @id

		select 'delete'
	end

	if(@select = 5) --select all
	begin 
		select * 
		from teams
	end

	if(@select = 6) --select by id
	begin 
		select * 
		from teams
		where teams.id = @id
	end
end
go