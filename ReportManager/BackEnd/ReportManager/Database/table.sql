-- đoạn sau use này các bác thay bằng tên database mà mình tạo trước đó nhé.
use REPORT_MANAGER
go

-- bảng nhóm
create table teams 
(
	id int identity(1,1) primary key,
	name nvarchar(max)
)
go

-- bảng tài khoản
create table accounts 
(
	id int identity(1, 1) primary key,
	username varchar(20) not null,
	passwords varchar(20) not null,
	age int,
	addresss nvarchar(max),
	roles nvarchar(20),
	first_name nvarchar(100),
	last_name nvarchar(100),
	mail varchar(50),
	sex int,
	statuss int,
	teams_id int

	constraint fk_teams_accounts 
		foreign key (teams_id) 
		references teams (id) 
)
go

-- bảng báo cáo
create table reports 
(
	id int identity(1,1) primary key,
	done nvarchar(max),
	problem nvarchar(max),
	solution nvarchar(max),
	link varchar(max),
	dates date,
	accounts_id int,
	teams_id int

	constraint fk_accounts_reports 
		foreign key (accounts_id) 
		references accounts (id),

	constraint fk_teams_reports 
		foreign key (teams_id) 
		references teams (id)
)
go

-- bảng bình luận
create table comments 
(
	id int identity(1,1) primary key,
	contents nvarchar(max),
	dates date,
	reports_id int,
	accounts_id int

	constraint fk_accounts_comments 
		foreign key (accounts_id) 
		references accounts (id),

	constraint fk_reports_comments 
		foreign key (reports_id) 
		references reports (id)
)
go

ALTER TABLE accounts
ALTER COLUMN roles int


