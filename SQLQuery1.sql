
Create table tb_Technology
(
Id int not null primary key  identity(10000,1),--���
NumId nvarchar(100) not null UNIQUE,--���
Title nvarchar(500),--����
SubTitle nvarchar(500),--������
TypeId int not null foreign key references tb_Category(Id),--���
Describe ntext,--����
ImgUrl nvarchar(500),--չʾͼƬ
Explain ntext,--��ϸ��Ϣ
IsHot int not null default(1),--����
IsRec int not null default(1),--�Ƽ�
IsIndex int not null default(1),--��ҳ
StateInfo int not null default(1),--״̬
SortNum int not null default(1000),--����
Remark ntext--��ע
)
