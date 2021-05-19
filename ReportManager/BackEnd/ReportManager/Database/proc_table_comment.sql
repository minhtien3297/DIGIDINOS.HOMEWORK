use REPORT_MANAGER
go

-- đặt tên proc: 
-- proc_<chức năng>_<tên bảng>
create procedure proc_CRUD_comments
	-- type data phải trùng với data type đã tạo trong file table.sql
	-- các đối số luôn phải đặt là null, tiết kiệm thời gian nhập dữ liệu 
	@select int = null, -- select này để phân các chức năng như  search, insert, update, delete...
	
	@id int = null,
	@contents nvarchar(max) = null,
	@dates date = null,
	@accounts_id int = null,
	@reports_id int = null
as 
begin
	if(@select = 1)	-- insert
	begin 
		insert into comments
		(
			contents,
			dates,
			accounts_id,
			reports_id
		)
		values 
		(
			@contents,
			@dates,
			@accounts_id,
			@reports_id
		)

		if @@rowcount > 0 -- rowcount: kiểm tra thay đổi trong bảng, nếu nó có thay đổi thì trả về 1 table[0][0] = 'insert'
			select 'insert'
		else 
			select 'bảng chưa được thêm mới'
	end

	if(@select = 2) -- delete
	begin 
		delete from comments
		where comments.id = @id
	end

	if(@select = 3) --select by id
	begin 
		select * 
		from comments
		where comments.reports_id = @id
	end
end
go