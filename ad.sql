use master
go

if exists(select * from sys.databases where name='db_ad')
drop database db_ad
go
create database db_ad
on primary 
(
	name='db_ad_mdf',
	filename='E:\Ad_db\db_ad.mdf',
	size=10,
	maxsize=50,
	filegrowth=15%
)
log on
(
	name='db_ad_ldf',
	filename='E:\Ad_db\db_ad.ldf',
	size=10,
	maxsize=50,
	filegrowth=15%
)
go
use db_ad
go
--新闻类型表
if exists(select * from sys.objects where name='t_ad_type')
drop table t_ad_type
go
create table t_ad_type
(
	id int primary key identity(1,1) not null,      --分类编号
	type_name varchar(30)  null,             		--类型名称
	type_father_id int  null                 		--父级编号
)
go
--服务类型表
if exists(select * from sys.objects where name='t_type')
drop table t_type
go
create table t_type
(
	id int primary key identity(1,1) not null,      --分类编号
	type_name varchar(30)  null,             		--类型名称
)
go
--新闻信息表
if exists(select * from sys.objects where name='t_ad_news')
drop table t_ad_news
go
create table t_ad_news
(
	id int primary key identity(1,1) not null,  					--新闻编号
	type_id int not null,											--类型编号
	new_title varchar(300) null,									--新闻标题
	new_Summary text null,                      					--内容概要
	new_info text null,												--新闻内容
	new_img varchar(200) null,										--新闻展示图片路径
	new_time datetime default(getdate()) null,					    --发布时间
	new_admin varchar(50) default('admin') null,			        --发布人
	new_num int default(0)                                          --访问量
	
)
go
--广告(其他)数据表
if exists(select * from sys.objects where name='t_ad_ad')
drop table t_ad_ad
go
create table t_ad_ad
(
	id int primary key identity(1,1) not null,
	ad_name text null,
	ad_img varchar(200) null,
    ad_num int	null,
    ad_weizhi int null, 
	ad_text text null
)
go
--关键字
if exists(select * from sys.objects where name='t_ad_keys')
drop table t_ad_keys
go
create table t_ad_keys
(
	id int primary key identity(1,1) not null,
	key_keys varchar(600),
	key_back varchar(500)
)

--后台帐号表
if exists(select * from sys.objects where name='t_ad_user')
drop table t_ad_user
go
create table t_ad_user
(
	id int primary key  identity(1,1) not null,
	user_name varchar(20) not null,
	user_pwd varchar(50) not null,
	user_back varchar(200)
)
go

--团队展示表
if exists(select * from sys.objects where name='t_ad_team')
drop table t_ad_team
go
create table t_ad_team
(
	id int primary key identity(1,1) not null,                 --编号
	team_name      varchar(300),                               --名称
	post_job       varchar(500),							   --职务
	post_summary   varchar(500),                               --概要
	post_info      text,									   --介绍
	post_img       varchar(200),	                           --图片
	post_time      datetime default(getdate())				   --发布时间
)
go

--案例表
if exists(select * from sys.objects where name='t_ad_case')
drop table t_ad_case
go
create table t_ad_case
(
	id int primary key identity(1,1) not null,                 --编号
	type_id        varchar   (300),                                --服务类型
	case_name      varchar(300),                               --公司名称
	post_job       varchar(500),							   --案例首页小图
	post_summary   varchar(500),                               --案例全图
	post_info      text,									   --介绍
	post_time      datetime default(getdate())				   --发布时间
)
go
--首页图片展示
if exists(select * from sys.objects where name ='t_ad_img')
drop table t_ad_img
go
create table t_ad_img
(
	id int primary key identity(1,1) not null,
	path_img1 varchar(100) null,
	path_img2 varchar(100) null,
	path_img3 varchar(100) null,
	path_img4 varchar(100) null,
	path_img5 varchar(100) null
)
go
--留言表
if exists(select * from sys.objects where name='t_ad_leave')
drop table t_ad_leave
go
create table t_ad_leave
(
	id int primary key identity(1,1) not null,
	name varchar(20) null,
	phone varchar(20) null,
	email varchar(100) null,
	back varchar(500) null
)
go


--初始化后台登录数据
insert into t_ad_user (user_name,user_pwd,user_back) values('admin','admin','')
insert into t_ad_type (type_name,type_father_id) values('团队介绍',0)
insert into t_ad_type (type_name,type_father_id) values('专业服务',0)
insert into t_ad_type (type_name,type_father_id) values('成功案例',0)
insert into t_ad_type (type_name,type_father_id) values('联系我们',0)
insert into t_ad_type (type_name,type_father_id) values('东山动态',0)



select * from t_ad_user; --后台用户表
select * from t_ad_news; --新闻信息表
select * from t_ad_team;  --团队信息表
select * from t_ad_ad;    --广告表
select * from t_ad_case;  --成功案例表
select * from t_ad_img;   --首页图片
select * from t_ad_keys;  --关键字信息表
select * from t_ad_leave; --留言表
select * from t_ad_type;  --新闻类型表
select * from t_type;     --服务类型

go
--添加关键字
create procedure [p-key-text]
@key text,
@context text
as
insert into t_ad_keys (key_keys,key_back) values(@key,@context);
go
create PROCEDURE [dbo].[UP_PaginationAnyOrderCount]

    	@tblName   varchar(500),            -- 表名
	@strGetFields varchar(1000) = '*',  -- 需要返回的列 
	@fldName varchar(255)='',           -- 主键
	@PageSize   int = 10,               -- 页尺寸
	@PageIndex  int = 1,                -- 页码	
	@strOrder varchar(1000) = '',      -- *****排序子句(注意: 不要加 order by) 
	@strWhere  varchar(1500) = '' ,      -- 查询条件 (注意: 不要加 where)
             @Count int output	                -- 返回记录总数

AS
	declare @strSQL   varchar(5000)     -- 主语句

    if @strOrder != '' 
		set @strOrder = ' order by ' + @strOrder
		
		
	if @PageIndex = 1
		begin
			if @strWhere != '' 
				set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ '  from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder
			else
				set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ '  from ['+ @tblName + '] '+ @strOrder					
			--如果是第一页就执行以上代码，这样会加快执行速度
		end
	else
		begin

		--以下代码赋予了@strSQL以真正执行的SQL代码
		                                                                   
		set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ '  from [' + @tblName + '] where [' + @fldName + '] not in (select top ' + str((@PageIndex-1)*@PageSize) + ' ['+ @fldName + '] from [' + @tblName + '] ' + @strOrder + ') '  + @strOrder
		if @strWhere != ''
			set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ '  from [' + @tblName + '] where '  + @strWhere + ' and [' + @fldName + '] not in (select top ' + str((@PageIndex-1)*@PageSize) + ' ['+ @fldName + '] from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder + ') ' + @strOrder
		end 
	

	exec (@strSQL)

	DECLARE @strSQLCount nvarchar(3000)
	if @strWhere != ''
		begin
			SET @strSQLCount = N'SET @Count=(SELECT count(*) from [' + @tblName + ']'+' where ' + @strWhere +')'
			EXEC sp_executesql @strSQLCount,N'@tblName nvarchar(255),@strWhere nvarchar(1500),@Count int output',@tblName,@strWhere,@Count output
		end 	
	else
		begin
			SET @strSQLCount = N'SET @Count=(SELECT count(*) from [' + @tblName + '])'
			EXEC sp_executesql @strSQLCount,N'@tblName nvarchar(255),@Count int output',@tblName,@Count output
		end
go
		
		

--删除数据的方法
create procedure [p-delete-id]
@id varchar(10),
@filename varchar(30),
@tablename varchar(50)
as
 declare @sql varchar(400)
 set @sql= 'delete from '+@tablename +' where '+@filename +'='+@id;
 exec(@sql)
 go
 
 --创建查询新闻类型表的视图
 alter view [p-type-all-view]
 as
 select a.id,a.type_name as atype_name,a.type_father_id,b.type_name as btype_name from t_ad_type a left join 
 t_ad_type b on b.type_father_id=a.id
 go
 --删除数据
 alter procedure [p-table-delete-id]
 @id varchar(10),
 @tabname varchar(50)
 as
   declare @sql varchar(2000)
   set @sql='delete from '+ @tabname+' where id='+@id;
   exec(@sql)
 go
--修改新闻类型表
create procedure [p-sys-update-type-id]
@id int,
@type_name varchar(20)
as
update t_ad_type set  [type_name]=@type_name where id=@id
go

--查询新闻信息
alter view [v-sys-select-new-type]
as
select a.id as aid,new_admin,new_img,new_info,new_num,new_Summary,new_time,new_title,type_name from t_ad_news a
left join t_ad_type b on a.type_id= b.id;
go

--添加新闻
create procedure [p-sys-in-new]
@type_id int,
@title varchar(500),
@summary varchar(500),
@info text,
@img varchar(300),
@name varchar(50)
as
insert into t_ad_news (type_id, new_title, new_Summary, new_info, new_img, new_time, new_admin, new_num) values
(@type_id,@title,@summary,@info,@img,GETDATE(),@name,default)
go
--修改新闻
alter procedure [p-sys-up-new]
@id int,
@type_id int,
@title varchar(500),
@summary varchar(500),
@info text,
@img varchar(200),
@num int
as
update t_ad_news set new_title=@title,new_Summary=@summary,
new_info=@info,new_img=@img,new_time=GETDATE(),new_num=@num where id=@id
go

create procedure [p-sel-new-id]
@id int
as
select * from t_ad_news where id=@id;
go

--查询具体团队信息
create procedure [p-sys-team-id]
@id int
as
select * from t_ad_team where id=@id;
go
--修改团队信息
alter procedure [p-sys-up-team-id]
@id int,
@team_name varchar(100),
@post_job    varchar(200),
@post_summary varchar(500),
@post_info   text,
@post_img    varchar(200)
as
update t_ad_team set post_img=@post_img,post_info=@post_info,post_job=@post_job,
post_summary=@post_summary,post_time=GETDATE(),team_name=@team_name where id=@id
go
--查询图片路径
alter procedure [p-sys-delete-img]
@id varchar(10),
@filename varchar(20),
@tablename varchar(50)
as
  declare @sql varchar(500)
  set @sql='select '+@filename+' from '+@tablename+' where id='+@id;
exec(@sql)
go

--添加团队信息
alter procedure [p-sys-in-team]
@team_name varchar(100),
@post_job    varchar(200),
@post_summary varchar(500),
@post_info   text,
@post_img    varchar(200)
as
insert into t_ad_team (team_name, post_job, post_summary, post_info, post_img, post_time) 
values(@team_name,@post_job,@post_summary,@post_info,@post_img,GETDATE())
go

--查询广告的详细信息
create procedure [p-sys-ad-all]
@id int
as
select * from t_ad_ad where id=@id
go

--修改广告信息
alter procedure [p-sys-up-ad-id]
@id int,
@ad_name text,
@ad_img varchar(200),
@ad_num int,
@ad_text text
as
update t_ad_ad set ad_name=@ad_name,ad_img=@ad_img,ad_num=@ad_num,ad_text=@ad_text where id=@id
go

--添加广告信息
alter procedure [p-sys-in-ad]
@ad_name text,
@ad_img varchar(200),
@ad_text text,
@ad_weizhi int
as
insert into t_ad_ad ( ad_name, ad_img, ad_num, ad_text,ad_weizhi)
values(@ad_name,@ad_img,default,@ad_text,@ad_weizhi)
GO


