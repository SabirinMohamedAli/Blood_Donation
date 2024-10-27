drop database BDSDatabase

create database BDSDatabase
drop database BDSDatabase
--------------create user table---------------

create table users (UserID int primary key, FirstName varchar(30) not null,
LastName varchar(30) not null,Phone varchar(50) not null,Address varchar(50)not null,UserName varchar (40)not null,
Password int ,Email varchar(40),BirthDate date  ,Gender varchar(10),
UserType nvarchar(50)not null);
insert into users values (1,'sabrin','Ahmed','6128888','wadajir','sabi',123,'sabirin@gmail.com','12-17-2020','female','Admin');

select*from Staff_TBL;
--------------create Registration of Hospital table---------------

create table hosp_TBL (HospNo int Primary key, HospName varchar(50)not null,Email varchar(40)not null
,[Address] varchar(50)not null,City Varchar(50)not null,State varchar(40)not null);



--------------create Department Hosp table---------------

create table Departments (DepNo int primary key ,DepName varchar(50)not null,[Location] varchar(50)not null,HospNo int,
constraint fk_HosID_hosp_TBL foreign key (HospNo)references hosp_TBL(HospNo));






--------------create Staff of Hosp table---------------
select GETDATE()

create table Staff_TBL (StafID int primary key ,[firstName] varchar(20)not null,
[lastName] varchar(20)not null,Phone varchar(50)not null,Email varchar(100)not null ,Gender varchar(10)not null,Title varchar(30)not null,
BirthDate date check(BirthDate>='1980-1-12' and BirthDate <='2000-12-11' )not null,
hired_date date check (hired_date>='2024-1-25' and hired_date <='2024-3-12')not null,DepNo int ,
Constraint fk_DepNo_Staff_TBL foreign key(DepNo)references Departments(DepNo));


--------------create Category of Blood table---------------



 --------------create Donor table---------------
create table Donors(DonorID int primary key  ,first_name varchar(30) not null ,last_name varchar(30)not null,
Phone varchar(50)not null,Email varchar(100)not null,Gender varchar(10)not null,Blood_Type varchar(10)not null ,
 BloodUnit int  ,StafID int ,
[Address] varchar(30)not null,Region varchar(30)not null,Town varchar(50)not null,
Registed_Date Date check(Registed_Date>='2024-1-25' and Registed_Date <='2024-3-12')not null,
birthdate date  check(birthdate>='1980-1-12' and  birthdate<='2010-12-11' )not null,
Constraint fk_Staff_ID_Staff_TBL foreign key(StafID)references Staff_TBL(StafID));

drop table Donors
select * from Donors;

 --------------create Recipients of Hosp table---------------

 create table Recipients (RecpNo int primary key ,First_name varchar(20)not null,last_name varchar(20)not null
,Phone varchar(40)not null,gender varchar(10)not null,Email varchar(50)not null,BloodUnits int not null, 
[BirdDate] date  check(BirdDate>='1980-1-12' and BirdDate<='2020-1-13' )not null,[StafID] int not null,
DonorID int not null,[Type] varchar(10)not null,
Constraint fk_StafID_Staff_TBL foreign key (StafID)references Staff_TBL(StafID),
Constraint fk_DonorID_DonorsTBL foreign key (DonorID)references Donors(DonorID));



---Create store table
Create table store (DonorId int ,RecpNo int,BloodUnit int  not null   DEFAULT 0,
Constraint fk_DonorID_Donors foreign key (DonorId)references Donors(DonorID),
Constraint fk__RecpNo foreign key (RecpNo )references Recipients(RecpNo));


---View Staff
Create view Staffs
as
select Staff_TBL.StafID as ID , firstName+' '+lastName as fullname ,
phone, Staff_TBL.Email,Gender, DATEDIFF(year,BirthDate ,getdate()) AS age,Title,HospName as Hospital,
DepName as Department,hired_date,BirthDate from hosp_TBL inner join 
Departments on hosp_TBL.HospNo=Departments.HospNo
inner join
Staff_TBL on departments.DepNo =Staff_TBL.DepNo;



----DONOR VIWE
Create view DonorView
as
select Donors.DonorID as ID ,firstName +' '+lastName as Name,Donors.phone, Donors.Email,Donors.Address,Donors.Gender,
DATEDIFF(year,Donors.birthdate ,getdate()) AS age, HospName as Hospital , DepName as Department ,Staff_TBL.firstName+
' '+Staff_TBL.lastName as Doctor,
Blood_Type ,BloodUnit as donatedUnit  ,Region,Town , Registed_Date ,Donors.birthdate
from  hosp_TBL inner join 
 Departments on hosp_TBL.HospNo= Departments.HospNo
inner join
Staff_TBL on Departments.DepNo =Staff_TBL.DepNo
inner join Donors on Staff_TBL.StafID =Donors.StafID
inner join 
store on Donors.DonorID =store.DonorId

select*from DonorView
--- Recipient Views

Create view RecipientView
as

select distinct (Recipients.RecpNo)as ID ,Recipients.first_name +' '+Recipients.last_name
as fulName,Recipients.phone ,Recipients.Email , 
Recipients.gender ,DATEDIFF(year,Recipients.BirdDate ,getdate()) AS age
,Type as Bloodtype,store.BloodUnit,Blood_Type as transfusion ,firstName +' '+lastName as Donor,HospName as Hospital,
 DepName as Department,Staff_TBL.firstName+' '+Staff_TBL.lastName as Doctor,Donors.Email as Donoremail ,Registed_Date AS Date
 from hosp_TBL inner join Departments on hosp_TBL.HospNo =Departments.HospNo
 inner join 
 Staff_TBL on Departments.DepNo =Staff_TBL.DepNo
inner join Donors on Staff_TBL.StafID =Donors.StafID
inner join 
store on Donors.DonorID =store.DonorId
inner join
Recipients on Staff_TBL.StafID =Recipients.StafID
select *
drop view RecipientView

select * from RecipientView
 
 create view DepartemntsView
 as
 select distinct(Departments.DepNo) as ID ,DepName as Department ,Location  as Address, City , 
 State ,firstName+' '+lastName as StaffName from hosp_TBL 
 inner join Departments on hosp_TBL.HospNo =Departments.HospNo
 inner join Staff_TBL on Staff_TBL.DepNo =Departments.DepNo


 select*from DepartemntsView
 drop view DepartemntsView
 



 --1-BloodA
create view BloodA
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='A' 

--2-BloodA
create view BloodB
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='B' 

--3-Blood-A
create view BloodNegA
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='A-' 
select*from Recipients
--4-Blood-B
create view BloodNegB
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='B-' 

--5-BloodAB
create view BloodAB
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='AB' 

--6-Blood-AB
create view BloodNegAB
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='AB-' 

--7-BloodO
create view BloodO
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='O' 

--8-Blood-O
create view BloodNegO
as
select (BloodUnit) from store
inner join Donors on store.DonorId =Donors.DonorID
where Blood_Type='O-'










----- another part
---
create view DepartemntsView
 as
 select Departments.DepNo as ID ,DepName as Department ,Location  as Address, City , 
 State ,firstName+' '+lastName as Staffname from hosp_TBL 
 inner join Departments on hosp_TBL.HospNo =Departments.HospNo
 inner join Staff_TBL on Staff_TBL.DepNo =Departments.DepNo
 order by DepName asc

 

 Create view RecipientView
as
select distinct (Recipients.RecpNo)as ID ,Recipients.first_name +' '+Recipients.last_name as fulName,Recipients.phone ,Recipients.Email , Recipients.gender ,DATEDIFF(year,Recipients.BirdDate ,getdate()) AS age
,Type as Bloodtype,store.BloodUnit,Blood_Type as transfusion ,firstName +' '+lastName as Donor,HospName as Hospital,
 DepName as Department,Staff_TBL.firstName+' '+Staff_TBL.lastName as Doctor,Donors.Email as [Donoremail] ,Registed_Date AS Date
 from hosp_TBL inner join Departments on hosp_TBL.HospNo =Departments.HospNo
 inner join 
 Staff_TBL on Departments.DepNo =Staff_TBL.DepNo
inner join Donors on Staff_TBL.StafID =Donors.StafID
inner join 
store on Donors.DonorID =store.DonorId
inner join
Recipients on Staff_TBL.StafID =Recipients.StafID





 create view RecipientViewGene as
 select RecpNo,Recipients.first_name as [First Name],Recipients.last_name as [Last Name],Recipients.phone,Recipients.Gender,Donors.first_name as [Donor Name],Staff_TBL.firstName as [Staff Name],Recipients.Email,type from Recipients
 inner join Donors on Recipients.DonorID=Donors.DonorID
 inner join Staff_TBL on Donors.DonorID=Staff_TBL.DepNo ;
 



