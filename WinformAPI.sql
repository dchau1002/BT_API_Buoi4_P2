use DemoCRUD

create table StudentsTb
(
StudentID int identity(1,1) primary key,
Name Nvarchar(50),
FatherName Nvarchar(30),
RollNumber varchar(50),
Address Nvarchar(50),
Mobile varchar(15)
)

Insert into StudentsTb(Name,FatherName,RollNumber,Address,Mobile)values(N'Vo? Minh',N'Quân','1071083',N'?ô?ng Nai','0909165154')
Insert into StudentsTb(Name,FatherName,RollNumber,Address,Mobile)values(N'Ha? Nhâ?t',N'Huy','1071043',N'Bi?nh ?i?nh','0646234364')
Insert into StudentsTb(Name,FatherName,RollNumber,Address,Mobile)values(N'Vo? Phi',N'Quân','1071082',N'An Giang','0932434343')
Insert into StudentsTb(Name,FatherName,RollNumber,Address,Mobile)values(N'Nguyê?n Thanh',N'Qui','1071086',N'???k L??k','0818074158')
Insert into StudentsTb(Name,FatherName,RollNumber,Address,Mobile)values(N'?oa?n Tri?',N'Linh','1071031',N'Bi?nh ?i?nh','0458485458')

select*
from StudentsTb

drop table StudentsTb