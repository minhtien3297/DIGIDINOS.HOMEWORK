use REPORT_MANAGER
go

-- đặt tên proc: 
-- proc_<chức năng>_<tên bảng>
alter procedure proc_CRUD_reports
	-- type data phải trùng với data type đã tạo trong file table.sql
	-- các đối số luôn phải đặt là null, tiết kiệm thời gian nhập dữ liệu 
	@select int = null, -- select này để phân các chức năng như  search, insert, update, delete...
	
	@id int = null,
	@done nvarchar(max) = null,
	@problem nvarchar(max) = null,
	@solution nvarchar(max) = null,
	@link nvarchar(max) = null,
	@dates date = null,
	@accounts_id int = null,
	@accounts_name nvarchar(max) = NULL,
	@teams_name nvarchar(max) = NULL,
	@teams_id int = null
as 
begin
	IF (@select = 1) -- search by searchstring
  BEGIN

    SELECT DISTINCT
      *
    FROM reports
    WHERE (@done IS NULL
    OR reports.done LIKE '%' + NCHAR(UNICODE(@done)) + '%')

    AND (@dates IS NULL
    OR reports.dates LIKE @dates)

    AND (@accounts_id IS NULL
    OR reports.accounts_id = (SELECT
							  accounts.id
							FROM accounts
							WHERE accounts.username LIKE '%' + NCHAR(UNICODE(@accounts_name)) + '%'))

    AND (@teams_id IS NULL
    OR reports.teams_id = (SELECT
						  teams.id
						FROM teams
						WHERE teams.name LIKE NCHAR(UNICODE(@teams_name))))

  END

	if(@select = 2)	-- insert
	begin 
		insert into reports
		(
			done,
			problem,
			solution,
			link,
			dates,
			accounts_id,
			teams_id
		)
		values 
		(
			@done,
			@problem,
			@solution,
			@link,
			@dates,
			@accounts_id,
			@teams_id
		)

		if @@rowcount > 0 -- rowcount: kiểm tra thay đổi trong bảng, nếu nó có thay đổi thì trả về 1 table[0][0] = 'insert'
			select 'insert'
		else 
			select 'bảng chưa được thêm mới'
	end

	if(@select = 3) -- update
	begin 
		update reports
		set
			done = @done,
			problem = @problem,
			solution = @solution,
			link = @link,
			dates = @dates,
			accounts_id = @accounts_id,
			teams_id = @teams_id
		where id = @id

		if @@rowcount = 0
			print 'bảng chưa được cập nhật'

		select 'update'
	end

	if(@select = 4) -- delete
	begin 
		delete from reports
		where reports.id = @id
	end

	if(@select = 5) --select all
	begin 
		select * 
		from reports
	end

	if(@select = 6) --select by id
	begin 
		select * 
		from reports
		where reports.id = @id
	end

if(@select = 7) --select by Account id
	begin
		select *
		from reports
		where reports.accounts_id = @id
	end

end

