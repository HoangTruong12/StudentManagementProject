create table Classes
(
	ClassID int primary key identity(1,1),
	-- ClassID int primary key,
	ClassName nvarchar(100),
)


go

create table Students
(
    StudentID int primary key identity(1,1),
	-- StudentID int primary key,
	StudentName nvarchar(100),
	Age int,
	ClassID int foreign key(ClassID) references Classes(ClassID)
	on update cascade
	on delete cascade
)

go

create table Subjects
(
	SubjectID int primary key identity(1,1),
	--SubjectID int primary key,
	SubjectName nvarchar(100)
)

go

create table ExamResults
(
	ResultID int identity(1,1) primary key,
	-- ResultID int primary key,
	SubjectID int,
	StudentID int,
	foreign key(SubjectID) references Subjects(SubjectID)
	on update cascade
	on delete cascade,
	foreign key(StudentID) references Students(StudentID)
	on update cascade
	on delete cascade,
	StartTermPoint float,
	MidTermPoint float,
	EndTermPoint float
)

select *
from dbo.Students 

delete from dbo.Students
where ClassID is NULL


----------------Store Proceduce----------------------------------


create proc GetClassName
as 
begin
	select distinct ClassName
	from dbo.Classes
end

exec GetClassName

alter proc GetAllSearchInfo
as
begin
	select st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
	from dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
	where st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
	group by st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
	order by AvgScore DESC
end

exec GetAllSearchInfo

alter proc GetStudentsByClassName @ClassName nvarchar(100)
as
begin
	set nocount on;
	select st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
	from dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
	where st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null and c.ClassName LIKE '%' + @ClassName + '%'
	group by st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
	order by AvgScore DESC
end

exec GetStudentsByClassName 'A1'

alter proc GetStudentsByStudentName @StudentName nvarchar(100)
as
begin
	set nocount on;
	select st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
	from dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
	where st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null and st.StudentName LIKE N'%' + @StudentName + '%'
	group by st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
	order by AvgScore DESC
end

exec GetStudentsByStudentName Sơn



	select st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
	from dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
	where st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID and st.StudentName LIKE N'%Thúy%'
	group by st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
	order by AvgScore DESC


select *
from dbo.ExamResults

ALTER PROC GetStudentsInfoByRating @Rating nvarchar(20)
AS
BEGIN
	IF(@Rating = N'Yếu')
	BEGIN
		SELECT st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
		FROM  dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
		WHERE st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
		GROUP BY st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
		HAVING (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 < 5 
		ORDER BY AvgScore DESC
	END
	ELSE IF(@Rating = N'Trung bình')
		BEGIN
			SELECT st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
			FROM  dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
			WHERE st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
			GROUP BY st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
			HAVING (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 >= 5 AND (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 < 6.5
			ORDER BY AvgScore DESC
		END
	ELSE IF(@Rating = N'Khá')
		BEGIN
			SELECT st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
			FROM  dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
			WHERE st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
			GROUP BY st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
			HAVING (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 >= 6.5 AND (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 <= 8
			ORDER BY AvgScore DESC
		END
	ELSE IF(@Rating = N'Giỏi')
		BEGIN
			SELECT st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
			FROM  dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
			WHERE st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
			GROUP BY st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
			HAVING (AVG(e.StartTermPoint) + AVG(e.MidTermPoint) + AVG(e.EndTermPoint))/3 > 8 
			ORDER BY AvgScore DESC
		END
END


EXEC GetStudentsInfoByRating Giỏi
EXEC GetStudentsInfoByRating 'Khá'
EXEC GetStudentsInfoByRating 'Trung bình'
EXEC GetStudentsInfoByRating Yếu

alter proc GetStudentsTop10
as 
begin
	select TOP 10 st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint, (AVG(StartTermPoint) + AVG(MidTermPoint) + AVG(EndTermPoint))/3 as AvgScore
	from dbo.Students as st, dbo.Classes as c, dbo.ExamResults as e, dbo.Subjects as su
	where st.ClassID = c.ClassID and e.StudentID = st.StudentID and e.SubjectID = su.SubjectID  and e.StartTermPoint is not null and e.MidTermPoint is not null and e.EndTermPoint is not null
	group by st.StudentName, st.Age, c.ClassName, su.SubjectName, e.StartTermPoint, e.MidTermPoint, e.EndTermPoint
	order by AvgScore DESC
end

exec GetStudentsTop10












