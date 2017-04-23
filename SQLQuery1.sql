
Create table tb_Technology
(
Id int not null primary key  identity(10000,1),--编号
NumId nvarchar(100) not null UNIQUE,--编号
Title nvarchar(500),--名称
SubTitle nvarchar(500),--副标题
TypeId int not null foreign key references tb_Category(Id),--类别
Describe ntext,--描述
ImgUrl nvarchar(500),--展示图片
Explain ntext,--详细信息
IsHot int not null default(1),--热门
IsRec int not null default(1),--推荐
IsIndex int not null default(1),--首页
StateInfo int not null default(1),--状态
SortNum int not null default(1000),--排序
Remark ntext--备注
)
