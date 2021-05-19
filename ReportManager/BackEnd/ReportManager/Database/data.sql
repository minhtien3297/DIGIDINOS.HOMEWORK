use REPORT_MANAGER
go

-- insert data

-- table team
insert into teams
	(
		name
	)
	values
	(
		'Thực tập sinh'
	)
	go

insert into teams
	(
		name
	)
	values
	(
		'Học việc'
	)
	go

insert into teams
	(
		name
	)
	values
	(
		'Font-End'
	)
	go

insert into teams
	(
		name
	)
	values
	(
		'Back-End'
	)
	go

insert into teams
	(
		name
	)
	values
	(
		'Database'
	)
	go

-- table account
exec proc_CRUD_accounts 
	@select = 2,
	@username = 'vux',
	@passwords = 'vux',
	@age = 21,
	@addresss = N'thái bình',
	@roles = 1 ,
	@first_name = 'Vu',
	@last_name = 'Doan',
	@mail = 'vanvux99@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 2
go

exec proc_CRUD_accounts 
	@select = 2,
	@username = 'huy',
	@passwords = 'huy',
	@age = 218,
	@addresss = N'Sao Hỏa',
	@roles = 1 ,
	@first_name = 'Huy',
	@last_name = 'Quang',
	@mail = 'quanghuy20@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 3
go

exec proc_CRUD_accounts 
	@select = 2,
	@username = 'huy',
	@passwords = 'huy',
	@age = 218,
	@addresss = N'Sao Hỏa',
	@roles = 1 ,
	@first_name = 'Huy',
	@last_name = 'Van',
	@mail = 'vanhuy2000@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 3
go

exec proc_CRUD_accounts 
	@select = 2,
	@username = 'vux',
	@passwords = 'vux',
	@age = 21,
	@addresss = N'thái bình',
	@roles = 1 ,
	@first_name = 'Vu',
	@last_name = 'Doan',
	@mail = 'vanvux99@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 1
go

exec proc_CRUD_accounts 
	@select = 2,
	@username = 'huy',
	@passwords = 'huy',
	@age = 218,
	@addresss = N'Sao Hỏa',
	@roles = 1 ,
	@first_name = 'Huy',
	@last_name = 'Quang',
	@mail = 'quanghuy20@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 1
go

exec proc_CRUD_accounts 
	@select = 2,
	@username = 'huy',
	@passwords = 'huy',
	@age = 218,
	@addresss = N'Sao Hỏa',
	@roles = 1 ,
	@first_name = 'Huy',
	@last_name = 'Van',
	@mail = 'vanhuy2000@gmail.com',
	@sex = 1,
	@statuss = 1,
	@teams_id = 1
go

-- table reports
insert into reports (
	done, --nvarchar(max),
	problem, --nvarchar(max)
	solution ,--nvarchar(max),
	link, --varchar(max),
	dates, --date,
	accounts_id, --int,
	teams_id --int
) values (
	'Phân chia công việc cho team',
	'ăn chuối bỏ vỏ',
	'ăn dua hấu',
	'http://localhost:3000/listReport',
	'2020-05-05',
	3,
	1
) 
go

insert into reports (
	done, --nvarchar(max),
	problem, --nvarchar(max)
	solution ,--nvarchar(max),
	link, --varchar(max),
	dates, --date,
	accounts_id, --int,
	teams_id --int
) values (
	'làm database',
	'không',
	'không',
	'http://localhost:3000',
	'2020-05-05',
	4,
	2
)
go

insert into reports (
	done, --nvarchar(max),
	problem, --nvarchar(max)
	solution ,--nvarchar(max),
	link, --varchar(max),
	dates, --date,
	accounts_id, --int,
	teams_id --int
) values (
	'sửa comment của anh tiến',
	'không',
	'không',
	'http://localhost:3000',
	'2020-05-05',
	5,
	4
)
go

insert into reports (
	done, --nvarchar(max),
	problem, --nvarchar(max)
	solution ,--nvarchar(max),
	link, --varchar(max),
	dates, --date,
	accounts_id, --int,
	teams_id --int
) values (
	'sửa comment của chú kim',
	'không',
	'không',
	'http:okokokok.com',
	'2020-05-05',
	4,
	3
)
go

insert into reports (
	done, --nvarchar(max),
	problem, --nvarchar(max)
	solution ,--nvarchar(max),
	link, --varchar(max),
	dates, --date,
	accounts_id, --int,
	teams_id --int
) values (
	'ngồi chơi',
	'không',
	'không',
	'http:123.com',
	'2020-05-05',
	3,
	3
)
go

-- table comments 
insert into comments
(
	contents, -- nvarchar(max),
	dates, -- date,
	reports_id, -- int,
	accounts_id -- int
)
values
(
	'vote xiên',
	'2020-05-05',
	4,
	4
)
go

insert into comments
(
	contents, -- nvarchar(max),
	dates, -- date,
	reports_id, -- int,
	accounts_id -- int
)
values
(
	'là người anh em tốt -)))',
	'2020-05-05',
	5,
	8
)
go

insert into comments
(
	contents, -- nvarchar(max),
	dates, -- date,
	reports_id, -- int,
	accounts_id -- int
)
values
(
	'chè khô chè khô',
	'2020-05-05',
	6,
	5
)
go





