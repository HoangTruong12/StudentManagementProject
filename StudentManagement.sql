
create table Classes
(
	ClassID int primary key identity(1,1),
	ClassName nvarchar(100),
)

go

create table Students
(
	StudentID int primary key identity(1,1),
	StudentName nvarchar(100),
	Age int,
	ClassID int foreign key(ClassID) references Classes(ClassID),
)

go

create table Subjects
(
	SubjectID int primary key identity(1,1),
	SubjectName nvarchar(100)
)

go

create table Scores
(
	SubjectID int,
	StudentID int,
	CONSTRAINT PK_Score PRIMARY KEY (SubjectID,StudentID),
	foreign key(SubjectID) references Subjects(SubjectID),
	foreign key(StudentID) references Students(StudentID),
	AvgScores float
)