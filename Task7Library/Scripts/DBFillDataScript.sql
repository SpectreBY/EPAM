USE Task7DB;

INSERT INTO Specialities (Id, Name) VALUES ('0','Инженер-программист');
INSERT INTO Specialities (Id, Name) VALUES ('1','Инженер-системный программист');

INSERT INTO Teachers (Id, FullName, Gender) VALUES ('0','Зиновьев Георгий Сергеевич','М');
INSERT INTO Teachers (Id, FullName, Gender) VALUES ('1','Морозова София Вадимовна','Ж');
INSERT INTO Teachers (Id, FullName, Gender) VALUES ('2','Петренко Борис Максимович','М');
INSERT INTO Teachers (Id, FullName, Gender) VALUES ('3','Котовска Олеся Григорьевна','Ж');
INSERT INTO Teachers (Id, FullName, Gender) VALUES ('4','Суханов Давид Петровичч','М');

INSERT INTO Sessions (Id, EducationPeriodStart, EducationPeriodEnd, Semestr) VALUES ('0','2018','2019','1');
INSERT INTO Sessions (Id, EducationPeriodStart, EducationPeriodEnd, Semestr) VALUES ('1','2018','2019','2');
INSERT INTO Sessions (Id, EducationPeriodStart, EducationPeriodEnd, Semestr) VALUES ('2','2019','2020','1');
INSERT INTO Sessions (Id, EducationPeriodStart, EducationPeriodEnd, Semestr) VALUES ('3','2019','2020','2');

INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('0','ИТ-11','0');
INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('1','ИТ-21','0');
INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('2','ИТ-31','0');
INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('3','ИТ-41','0');
INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('4','ИТП-11','1');
INSERT INTO Groups (Id, Name, SpecialityId) VALUES ('5','ИТП-21','1');

INSERT INTO Subjects (Id, Name) VALUES ('0','ПСП');
INSERT INTO Subjects (Id, Name) VALUES ('1','КСКР');
INSERT INTO Subjects (Id, Name) VALUES ('2','ООП');
INSERT INTO Subjects (Id, Name) VALUES ('3','ОАИП');
INSERT INTO Subjects (Id, Name) VALUES ('4','ОС');

INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('0','0','3');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('1','1','2');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('2','1','4');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('3','2','1');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('4','3','0');

INSERT INTO Exams (Id, SessionId, ExamDate, SubjectsOfGroupId, TeacherId) VALUES ('0','0','21.12.2019','4','1');
INSERT INTO Exams (Id, SessionId, ExamDate, SubjectsOfGroupId, TeacherId) VALUES ('1','1','23.12.2019','3','4');
INSERT INTO Exams (Id, SessionId, ExamDate, SubjectsOfGroupId, TeacherId) VALUES ('2','2','17.12.2018','2','3');
INSERT INTO Exams (Id, SessionId, ExamDate, SubjectsOfGroupId, TeacherId) VALUES ('3','3','20.05.2019','1','2');
INSERT INTO Exams (Id, SessionId, ExamDate, SubjectsOfGroupId, TeacherId) VALUES ('4','3','22.05.2019','0','0');

INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('0','Масловский Сергей Витальевич','М','07.02.1996','3');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('1','Иванова Мария Олеговна','Ж','01.05.1998','2');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('2','Гринь Валерий Анатольевич','М','11.07.1998','1');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('3','Шаповалова Дарья Анатольевна','Ж','02.08.1998','1');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('4','Иванов Юстин Романович','М','09.01.2000','0');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('5','Тихонов Юлиан Кириллович','М','17.02.2001','0');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('6','Гусева Алика Германовна','Ж','15.11.1998','2');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('7','Лапина Клавдия Прокловна','Ж','23.12.1995','3');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('8','Кудряшов Гордей Лукьевич','М','14.09.1999','1');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('9','Марков Афанасий Семёнович','М','06.06.1996','3');

INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('0','0','4','8');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('1','1','1','7');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('2','2','2','3');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('3','3','1','2');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('4','4','4','5');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('5','5','4','2');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('6','6','1','10');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('7','7','4','2');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('8','8','2','6');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('9','9','4','10');