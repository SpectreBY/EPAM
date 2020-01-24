INSERT INTO Sessions (Id, EducationPeriod, Semestr) VALUES ('0','2018-2019','1');
INSERT INTO Sessions (Id, EducationPeriod, Semestr) VALUES ('1','2018-2019','2');
INSERT INTO Sessions (Id, EducationPeriod, Semestr) VALUES ('2','2019-2020','1');
INSERT INTO Sessions (Id, EducationPeriod, Semestr) VALUES ('3','2019-2020','2');

INSERT INTO Groups (Id, Name) VALUES ('0','ИТ-11');
INSERT INTO Groups (Id, Name) VALUES ('1','ИТ-12');
INSERT INTO Groups (Id, Name) VALUES ('2','ИТ-21');
INSERT INTO Groups (Id, Name) VALUES ('3','ИТ-22');
INSERT INTO Groups (Id, Name) VALUES ('4','ИТ-31');
INSERT INTO Groups (Id, Name) VALUES ('5','ИТ-32');
INSERT INTO Groups (Id, Name) VALUES ('6','ИТ-41');
INSERT INTO Groups (Id, Name) VALUES ('7','ИТ-42');

INSERT INTO Subjects (Id, Name) VALUES ('0','ПСП');
INSERT INTO Subjects (Id, Name) VALUES ('1','КСКР');
INSERT INTO Subjects (Id, Name) VALUES ('2','ОАК');
INSERT INTO Subjects (Id, Name) VALUES ('3','ООП');
INSERT INTO Subjects (Id, Name) VALUES ('4','ОМИМОД');
INSERT INTO Subjects (Id, Name) VALUES ('5','ОАИП');
INSERT INTO Subjects (Id, Name) VALUES ('6','ОС');

INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('0','0','5');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('1','0','6');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('2','1','5');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('3','1','6');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('4','2','3');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('5','3','3');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('6','4','1');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('7','5','1');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('8','4','2');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('9','5','2');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('10','6','0');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('11','6','4');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('12','7','0');
INSERT INTO SubjectsOfGroups (Id, GroupId, SubjectId) VALUES ('13','7','4');

INSERT INTO Exams (Id, ExamType, SessionId, ExamDate, SubjectsOfGroupId) VALUES ('0','Экзамен','2','21.12.2019','6');
INSERT INTO Exams (Id, ExamType, SessionId, ExamDate, SubjectsOfGroupId) VALUES ('1','Экзамен','2','23.12.2019','7');

INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('0','Масловский Сергей Витальевич','0','07.02.1997','2');
INSERT INTO Students (Id, FullName, Gender, DateOfBirth, GroupId) VALUES ('1','Иванова Мария Олеговна','1','01.05.1998','2');

INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('0','0','0','8');
INSERT INTO ResultsOfExams (Id, StudentId, ExamId, Result) VALUES ('1','1','1','8');