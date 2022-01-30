USE [TrainingPortal]
GO

INSERT INTO [dbo].[Tests] ([Name]) 
VALUES ('Test "Layout designer"'),
('Test "ASP.NET developer"'),
('Test "Frontend developer"'),
('Test "Python developer"'),
('Test "PHP developer"')

GO
INSERT INTO [dbo].[Questions] ([TestId], [Question]) 
VALUES (1, 'First Layout question'),
(1, 'Second Layout question'),
(1, 'Third Layout question'),
(2, 'First ASP question'),
(2, 'Second ASP question'),
(2, 'Third ASP question'),
(2, 'Fourth ASP question'),
(2, 'Fifth ASP question'),
(2, 'Sixth ASP question'),
(2, 'Seventh ASP question'),
(3, 'First Frontend question'),
(3, 'Second Frontend question'),
(3, 'Third Frontend question'),
(3, 'Fourth Frontend question'),
(3, 'Fifth Frontend question'),
(3, 'Sixth Frontend question'),
(4, 'First Python question'),
(4, 'Second Python question'),
(4, 'Third Python question'),
(4, 'Fourth Python question'),
(4, 'Fifth Python question'),
(5, 'First PHP question'),
(5, 'Second PHP question'),
(5, 'Third PHP question'),
(5, 'Fourth PHP question')

GO
INSERT INTO [dbo].[Answers] ([QuestionId], [Answer], [IsRightAnswer]) 
VALUES (1, 'First answer for First Layout question (right)', 1),
(1, 'Second answer for First Layout question', 0),
(1, 'Third answer for First Layout question', 0),
(2, 'First answer for Second Layout question', 0),
(2, 'Second answer for Second Layout question (right)', 1),
(3, 'First answer for Third Layout question', 0),
(3, 'Second answer for Third Layout question', 0),
(3, 'Third answer for Third Layout question (right)', 1),
(3, 'Fourth answer for Third Layout question (right)', 1),
(4, 'First answer for First ASP question (right)', 1),
(4, 'Second answer for First ASP question', 0),
(4, 'Third answer for First ASP question (right)', 1),
(4, 'Fourth answer for First ASP question (right)', 1),
(4, 'Fifth answer for First ASP question (right)', 1),
(5, 'First answer for Second ASP question (right)', 1),
(5, 'Second answer for Second ASP question (right)', 1),
(5, 'Third answer for Second ASP question', 0),
(6, 'First answer for Third ASP question', 0),
(6, 'Second answer for Third ASP question (right)', 1),
(6, 'Third answer for Third ASP question (right)', 1),
(7, 'First answer for Fourth ASP question (right)', 1),
(7, 'Second answer for Fourth ASP question (right)', 1),
(7, 'Third answer for Fourth ASP question (right)', 1),
(8, 'First answer for Fifth ASP question (right)', 1),
(8, 'Second answer for Fifth ASP question', 0),
(8, 'Third answer for Fifth ASP question', 0),
(9, 'First answer for Sixth ASP question', 0),
(9, 'Second answer for Sixth ASP question (right)', 1),
(9, 'Third answer for Sixth ASP question', 0),
(10, 'First answer for Seventh ASP question', 0),
(10, 'Second answer for Seventh ASP question', 0),
(10, 'Third answer for Seventh ASP question (right)', 1),
(11, 'First answer for First Frontend question (right)', 1),
(11, 'Second answer for First Frontend question', 0),
(11, 'Third answer for First Frontend question', 0),
(12, 'First answer for Second Frontend question', 0),
(12, 'Second answer for Second Frontend question (right)', 1),
(12, 'Third answer for Second Frontend question', 0),
(13, 'First answer for Third Frontend question', 0),
(13, 'Second answer for Third Frontend question', 0),
(13, 'Third answer for Third Frontend question (right)', 1),
(14, 'First answer for Fourth Frontend question (right)', 1),
(14, 'Second answer for Fourth Frontend question', 0),
(14, 'Third answer for Fourth Frontend question', 0),
(15, 'First answer for Fifth Frontend question', 0),
(15, 'Second answer for Fifth Frontend question (right)', 1),
(15, 'Third answer for Fifth Frontend question', 0),
(16, 'First answer for Sixth Frontend question', 0),
(16, 'Second answer for Sixth Frontend question', 0),
(16, 'Third answer for Sixth Frontend question (right)', 1),
(17, 'First answer for First Python question (right)', 1),
(17, 'Second answer for First Python question', 0),
(17, 'Third answer for First Python question', 0),
(18, 'First answer for Second Python question', 0),
(18, 'Second answer for Second Python question (right)', 1),
(18, 'Third answer for Second Python question', 0),
(19, 'First answer for Third Python question', 0),
(19, 'Second answer for Third Python question', 0),
(19, 'Third answer for Third Python question (right)', 1),
(20, 'First answer for Fourth Python question (right)', 1),
(20, 'Second answer for Fourth Python question', 0),
(20, 'Third answer for Fourth Python question', 0),
(21, 'First answer for Fifth Python question', 0),
(21, 'Second answer for Fifth Python question (right)', 1),
(21, 'Third answer for Fifth Python question', 0),
(22, 'First answer for First PHP question (right)', 1),
(22, 'Second answer for First PHP question', 0),
(22, 'Third answer for First PHP question', 0),
(23, 'First answer for Second PHP question', 0),
(23, 'Second answer for Second PHP question (right)', 1),
(23, 'Third answer for Second PHP question', 0),
(24, 'First answer for Third PHP question', 0),
(24, 'Second answer for Third PHP question', 0),
(24, 'Third answer for Third PHP question (right)', 1),
(25, 'First answer for Fourth PHP question (right)', 1),
(25, 'Second answer for Fourth PHP question', 0),
(25, 'Third answer for Fourth PHP question', 0)

GO
INSERT INTO [dbo].[Certificates] ([CourseName], [ImageLink])
VALUES ('Layout designer', 'https://image.freepik.com/free-vector/layout-designer-concept-web-development-mobile-app-design-people-building-user-interface-template-computer-technology_277904-10536.jpg'),
('ASP.NET developer', 'https://www.aceinfoway.com/blog/wp-content/uploads/2020/05/Top-5-benefits-of-using-ASPNET-Core.jpg'),
('Frontend developer', 'https://www.mindinventory.com/blog/wp-content/uploads/2021/03/frontend-development-tools.png'),
('Python developer', 'https://jobaxes.com/wp-content/uploads/2021/05/Python-Developer-at-P.jpg'),
('PHP developer', 'https://interact2019.org/wp-content/uploads/2021/05/php-Developer.jpg')

GO
INSERT INTO [dbo].[Lessons] ([Name], [Material]) 
VALUES ('Become Layout designer', 'Some text or code'),
('HTML', 'Some text or code'),
('CSS', 'Some text or code'),
('JS', 'Some text or code'),
('Lesson 1: "Become ASP.NET developer"', 'Some text or code'),
('Lesson 2: "Become ASP.NET developer"', 'Some text or code'),
('Lesson 3: "Become ASP.NET developer"', 'Some text or code'),
('Lesson 4: "Become ASP.NET developer"', 'Some text or code'),
('Lesson 5: "Become ASP.NET developer"', 'Some text or code'),
('Lesson 1: "Become Frontend developer"', 'Some text or code'),
('Lesson 2: "Become Frontend developer"', 'Some text or code'),
('Lesson 3: "Become Frontend developer"', 'Some text or code'),
('Lesson 4: "Become Frontend developer"', 'Some text or code'),
('Lesson 1: "Become Python developer"', 'Some text or code'),
('Lesson 2: "Become Python developer"', 'Some text or code'),
('Lesson 3: "Become Python developer"', 'Some text or code'),
('Lesson 1: "Become PHP developer"', 'Some text or code'),
('Lesson 2: "Become PHP developer"', 'Some text or code')

GO
INSERT INTO [dbo].[TargetAudiencies] ([Name])
VALUES ('Beginners'),
('Advanced'),
('Professionals')

GO
INSERT INTO [dbo].[Categories] ([Name])
VALUES ('Engineering'),
('Cosmetology')

GO
INSERT INTO [dbo].[Roles] ([Name])
VALUES ('user'),
('editor'),
('admin')

GO
INSERT INTO [dbo].[Users] ([Login], [PasswordHash], [Email], [RoleId], [Lastname], [Firstname], [Patronymic])
VALUES ('admin', 'ISMvKXpXpadDiUoOSoAfww==', 'admin@tp.com', 3, 'Adminlastname', 'Adminfirstname', 'Adminpatronymic'),
('editor', 'Wu6dvSoYiDkQUHNXG+4bHw==', 'editor@tp.com', 2, 'Editorlastname', 'Editorfirstname', 'Editorpatronymic'),
('user', '7hHLsZBS5AsHqsDKBgwj7g==', 'user@tp.com', 1, 'Userlastname', 'Userfirstname', 'Userpatronymic')

GO
INSERT INTO [dbo].[Courses] ([Name], [Description], [CategoryId], [TestId], [CertificateId])
VALUES ('Layout designer', 'Description for Layout designer', 1, 1, 1),
('ASP.NET developer', 'Description for ASP.NET developer', 1, 2, 2),
('Frontend developer', 'Description for Frontend developer', 1, 3, 3),
('Python developer', 'Description for Python developer', 1, 4, 4),
('PHP developer', 'Description for PHP developer', 1, 5, 5)

GO
INSERT INTO [dbo].[Courses_Lessons] ([CourseId], [LessonId])
VALUES (1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(3, 10),
(3, 11),
(3, 12),
(3, 13),
(4, 14),
(4, 15),
(4, 16),
(5, 17),
(5, 18)

GO
INSERT INTO [dbo].[Courses_TargetAudiencies] ([CourseId], [TargetAudienceId])
VALUES (1, 1),
(1, 2),
(2, 2),
(2, 3),
(3, 3),
(4, 2),
(5, 1)