USE [master]
GO
/****** Object:  Database [TrainingPortal]    Script Date: 10.12.2021 13:30:24 ******/
CREATE DATABASE [TrainingPortal]
GO
ALTER DATABASE [TrainingPortal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainingPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainingPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainingPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainingPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainingPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainingPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainingPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrainingPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainingPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainingPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainingPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainingPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainingPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainingPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainingPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainingPortal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrainingPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainingPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainingPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainingPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainingPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainingPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrainingPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainingPortal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrainingPortal] SET  MULTI_USER 
GO
ALTER DATABASE [TrainingPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainingPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainingPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainingPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainingPortal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainingPortal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TrainingPortal] SET QUERY_STORE = OFF
GO
USE [TrainingPortal]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 10.12.2021 13:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[IsRightAnswer] [bit] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificates]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[ImageLink] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Certificates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[CategoryId] [int] NULL,
	[TestId] [int] NULL,
	[CertificateId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses_Lessons]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Lessons](
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses_TargetAudiencies]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_TargetAudiencies](
	[CourseId] [int] NOT NULL,
	[TargetAudienceId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Material] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[Question] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAudiencies]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAudiencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_TargetAudiencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Lastname] [nvarchar](50) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_PassedCourses]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_PassedCourses](
	[UserId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Categories]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Certificates] FOREIGN KEY([CertificateId])
REFERENCES [dbo].[Certificates] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Certificates]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Tests]
GO
ALTER TABLE [dbo].[Courses_Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Lessons_Lessons] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
GO
ALTER TABLE [dbo].[Courses_Lessons] CHECK CONSTRAINT [FK_Courses_Lessons_Lessons]
GO
ALTER TABLE [dbo].[Courses_Lessons]  WITH CHECK ADD  CONSTRAINT [FK_CoursesLessons_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Courses_Lessons] CHECK CONSTRAINT [FK_CoursesLessons_Courses]
GO
ALTER TABLE [dbo].[Courses_TargetAudiencies]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTargetAudiencies_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Courses_TargetAudiencies] CHECK CONSTRAINT [FK_CoursesTargetAudiencies_Courses]
GO
ALTER TABLE [dbo].[Courses_TargetAudiencies]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTargetAudiencies_TargetAudiencies] FOREIGN KEY([TargetAudienceId])
REFERENCES [dbo].[TargetAudiencies] ([Id])
GO
ALTER TABLE [dbo].[Courses_TargetAudiencies] CHECK CONSTRAINT [FK_CoursesTargetAudiencies_TargetAudiencies]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Tests]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Users_PassedCourses]  WITH CHECK ADD  CONSTRAINT [FK_Users_PassedCourses_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Users_PassedCourses] CHECK CONSTRAINT [FK_Users_PassedCourses_Courses]
GO
ALTER TABLE [dbo].[Users_PassedCourses]  WITH CHECK ADD  CONSTRAINT [FK_Users_PassedCourses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_PassedCourses] CHECK CONSTRAINT [FK_Users_PassedCourses_Users]
GO
/****** Object:  StoredProcedure [dbo].[CreateAnswer]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateAnswer]
	@QuestionId int,
	@Text nvarchar(1000),
	@IsRightAnswer bit
AS
BEGIN
	INSERT INTO [dbo].[Answers] ([QuestionId], [Text], [IsRightAnswer] )
	OUTPUT Inserted.Id
	VALUES (@QuestionId, @Text, @IsRightAnswer )
END
GO
/****** Object:  StoredProcedure [dbo].[CreateCategory]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCategory]
	@Name nvarchar(500)
AS
BEGIN
	INSERT INTO [dbo].[Categories] ([Name])
	OUTPUT Inserted.Id
	VALUES (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateCertificate]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCertificate]
	@CourseName nvarchar(50),
	@ImageLink nvarchar(1000)
AS
BEGIN
	INSERT INTO [dbo].[Certificates] ([CourseName], [ImageLink])
	OUTPUT Inserted.Id
	VALUES (@CourseName, @ImageLink)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateCourse]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCourse]
	@Name nvarchar(500),
	@Description nvarchar(1000),
	@CategoryId int,
	@TestId int,
	@CertificateId int
AS
BEGIN
	INSERT INTO [dbo].[Courses] ([Name], [Description], [CategoryId], [TestId], [CertificateId])
	OUTPUT Inserted.Id
	VALUES (@Name, @Description, @CategoryId, @TestId, @CertificateId)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateCoursesLessons]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCoursesLessons]
	@CourseId int,
	@LessonId int
AS
BEGIN
	INSERT INTO [dbo].[Courses_Lessons] ([CourseId], [LessonId])
	VALUES (@CourseId, @LessonId)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateCoursesTargetAudiencies]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCoursesTargetAudiencies]
	@CourseId int,
	@TargetAudienceId int
AS
BEGIN
	INSERT INTO [dbo].[Courses_TargetAudiencies] ([CourseId], [TargetAudienceId])
	VALUES (@CourseId, @TargetAudienceId)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateLesson]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateLesson]
	@Name nvarchar(500),
	@Material nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Lessons] ([Name], [Material])
	OUTPUT Inserted.Id
	VALUES (@Name, @Material)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateQuestion]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateQuestion]
	@TestId int,
	@Question nvarchar(1000)
AS
BEGIN
	INSERT INTO [dbo].[Questions] ([TestId], [Question])
	OUTPUT Inserted.Id
	VALUES (@TestId, @Question)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRole]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Roles] ([Name])
	OUTPUT Inserted.Id
	VALUES (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateTargetAudience]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTargetAudience]
	@Name nvarchar(500)
AS
BEGIN
	INSERT INTO [dbo].[TargetAudiencies] ([Name])
	OUTPUT Inserted.Id
	VALUES (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateTest]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTest]
	@Name nvarchar(500)
AS
BEGIN
	INSERT INTO [dbo].[Tests] ([Name])
	OUTPUT Inserted.Id
	VALUES (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
	@Login nvarchar(50),
	@PasswordHash nvarchar(50),
	@Email nvarchar(50),
	@RoleId int,
	@Lastname nvarchar(50),
	@Firstname nvarchar(50),
	@Patronymic nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Users] ([Login], [PasswordHash], [Email], [RoleId], [Lastname], [Firstname], [Patronymic])
	OUTPUT Inserted.Id
	VALUES (@Login, @PasswordHash, @Email, @RoleId, @Lastname, @Firstname, @Patronymic)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUserPassedCourse]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUserPassedCourse]
	@UserId int,
	@CourseId int
AS
BEGIN
	INSERT INTO [dbo].[Users_PassedCourses] ([UserId], [CourseId])
	VALUES (@UserId, @CourseId)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAnswerById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAnswerById]
	@Id int
AS
BEGIN
	DELETE	
	FROM [dbo].[Answers]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAnswersByQuestionId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAnswersByQuestionId]
	@QuestionId int
AS
BEGIN
	DELETE
	FROM [dbo].[Answers]
	OUTPUT Deleted.Id
	WHERE [QuestionId] = @QuestionId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategoryById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Categories]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCertificateById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCertificateById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Certificates]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCoursesLessonsByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCoursesLessonsByCourseId]
	@CourseId int
AS
BEGIN
	DELETE
	FROM [dbo].[Courses_Lessons]
	WHERE [CourseId] = @CourseId
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteCoursesLessonsByCourseIdAndLessonId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCoursesLessonsByCourseIdAndLessonId]
	@CourseId int,
	@LessonId int
AS
BEGIN
	DELETE
	FROM [dbo].[Courses_Lessons]
	WHERE [CourseId] = @CourseId AND [LessonId] = @LessonId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCoursesTargetAudienciesByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCoursesTargetAudienciesByCourseId]
	@CourseId int
AS
BEGIN
	DELETE
	FROM [dbo].[Courses_TargetAudiencies]
	WHERE [CourseId] = @CourseId
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteCoursesTargetAudienciesByCourseIdAndTargetAudienceId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCoursesTargetAudienciesByCourseIdAndTargetAudienceId]
	@CourseId int,
	@TargetAudienceId int
AS
BEGIN
	DELETE
	FROM [dbo].[Courses_TargetAudiencies]
	WHERE [CourseId] = @CourseId AND [TargetAudienceId] = @TargetAudienceId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourseWithChildsById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCourseWithChildsById]
	@Id int
AS
BEGIN
DECLARE @TestId INT;
DECLARE @CertificateId INT;
DECLARE @QuestionId INT;
DECLARE @LessonId INT;
DECLARE @TargetAudienceId INT;
DECLARE @Ans int;

SELECT @TestId = [TestId], @CertificateId = [CertificateId] FROM [dbo].[Courses] WHERE [Id] = @Id;

WHILE (SELECT COUNT(*) FROM [dbo].[Courses_Lessons] WHERE [CourseId] = @Id) > 0

BEGIN
SELECT @LessonId = [LessonId] FROM [dbo].[Courses_Lessons] WHERE [CourseId] = @Id;
DELETE FROM [dbo].[Courses_Lessons] WHERE [CourseId] = @Id AND [LessonId]= @LessonId;
DELETE FROM [dbo].[Lessons] WHERE [Id] = @LessonId;
END;

WHILE (SELECT COUNT(*) FROM [dbo].[Courses_TargetAudiencies] WHERE [CourseId] = @Id) > 0
BEGIN
SELECT @TargetAudienceId = [TargetAudienceId] FROM [dbo].[Courses_TargetAudiencies] WHERE [CourseId] = @Id;
DELETE FROM [dbo].[Courses_TargetAudiencies] WHERE [CourseId] = @Id AND [TargetAudienceId] = @TargetAudienceId;
END;

DELETE FROM [dbo].[Courses] OUTPUT Deleted.Id WHERE [Id] = @Id;
DELETE FROM [dbo].[Certificates] WHERE [Id] = @CertificateId;

WHILE (SELECT COUNT(*) FROM [Questions] WHERE [TestId] = @TestId) > 0
BEGIN
SELECT @QuestionId = [Id] FROM [dbo].[Questions] WHERE [TestId] = @TestId;
SELECT @Ans = COUNT(*) FROM [Answers] WHERE [QuestionId] = @QuestionId

WHILE (SELECT COUNT(*) FROM [Answers] WHERE [QuestionId] = @QuestionId) > 0
BEGIN
DELETE FROM [dbo].[Answers] WHERE [QuestionId] = @QuestionId;
END;

DELETE FROM [dbo].[Questions] WHERE [TestId] = @TestId AND [Id] = @QuestionId;
END;

DELETE FROM [dbo].[Tests] WHERE [Id] = @TestId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLessonById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteLessonById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Lessons]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteQuestionById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteQuestionById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Questions]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteQuestionsByTestId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteQuestionsByTestId]
	@TestId int
AS
BEGIN
	DELETE
	FROM [dbo].[Questions]
	OUTPUT Deleted.Id
	WHERE [TestId] = @TestId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteRoleById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Roles]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTargetAudienceById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteTargetAudienceById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[TargetAudiencies]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTestById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteTestById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Tests]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserById]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Users]
	OUTPUT Deleted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserPassedCoursesByUserId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserPassedCoursesByUserId]
	@UserId int
AS
BEGIN
	DELETE
	FROM [dbo].[Users_PassedCourses]
	WHERE [UserId] = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAnswerById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAnswerById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Answers]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAnswersByQuestionId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAnswersByQuestionId]
	@QuestionId int
AS
BEGIN
	SELECT *
	FROM [dbo].[Answers]
	WHERE [QuestionId] = @QuestionId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Categories]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetCertificateById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCertificateById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Certificates]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetCourseById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCourseById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Courses]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetCoursesLessonsByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCoursesLessonsByCourseId]
	@CourseId int
AS
BEGIN
	SELECT *
	FROM [dbo].[Courses_Lessons]
	WHERE [CourseId] = @CourseId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCoursesTargetAudienciesByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCoursesTargetAudienciesByCourseId]
	@CourseId int
AS
BEGIN
	SELECT *
	FROM [dbo].[Courses_TargetAudiencies]
	WHERE [CourseId] = @CourseId
END
GO
/****** Object:  StoredProcedure [dbo].[GetLessonById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLessonById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Lessons]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestionById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetQuestionById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Questions]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestionsByTestId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetQuestionsByTestId]
	@TestId int
AS
BEGIN
	SELECT *
	FROM [dbo].[Questions]
	WHERE [TestId] = @TestId
END
GO
/****** Object:  StoredProcedure [dbo].[GetRoleById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRoleById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Roles]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetTargetAudienceById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTargetAudienceById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[TargetAudiencies]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTestById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Tests]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Users]
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserPassedCoursesByUserId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserPassedCoursesByUserId]
	@UserId int
AS
BEGIN
	SELECT *
	FROM [dbo].[Users_PassedCourses]
	WHERE [UserId] = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCourse]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchCourse]
	@Course nvarchar(500),
	@Category nvarchar(50),
	@TargetAudience nvarchar(500)
AS
BEGIN
	Select Course.[Id], Course.[Name], Course.[Description], Course.[CategoryId], Course.[TestId], Course.[CertificateId]
	FROM [dbo].[Courses] Course
	FULL JOIN [dbo].[Categories] Category ON Course.CategoryId = Category.Id
	FULL JOIN [dbo].[Courses_TargetAudiencies] CoursesAudiencies ON Course.Id = CoursesAudiencies.CourseId
	FULL JOIN [dbo].[TargetAudiencies] Audiency ON CoursesAudiencies.TargetAudienceId = Audiency.Id
	WHERE Course.Name LIKE '%'+@Course+'%' AND Category.Name LIKE '%'+@Category+'%' AND Audiency.Name LIKE '%'+@TargetAudience+'%'
	GROUP BY Course.[Id], Course.[Name], Course.[Description], Course.[CategoryId], Course.[TestId], Course.[CertificateId]
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAnswerById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAnswerById]
	@Id int,
	@Text nvarchar(1000),
	@IsRightAnswer bit
AS
BEGIN
	UPDATE [dbo].[Answers]
	SET [Text] = @Text,
	[IsRightAnswer] = @IsRightAnswer
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategoryById]
	@Id int,
	@Name nvarchar(500)
AS
BEGIN
	UPDATE [dbo].[Categories]
	SET [Name] = @Name
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCertificateById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCertificateById]
	@Id int,
	@CourseName nvarchar(50),
	@ImageLink nvarchar(1000)
AS
BEGIN
	UPDATE [dbo].[Certificates]
	SET [CourseName] = @CourseName,
	[ImageLink] = @ImageLink
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourseById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCourseById]
	@Id int,
	@Name nvarchar(500),
	@Description nvarchar(1000),
	@CategoryId int,
	@TestId int,
	@CertificateId int
AS
BEGIN
	UPDATE [dbo].[Courses]
	SET 
	[Name] = @Name,
	[Description] = @Description,
	[CategoryId] = @CategoryId,
	[TestId] = @TestId,
	[CertificateId] = @CertificateId
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCoursesLessonsByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCoursesLessonsByCourseId]
	@CourseId int,
	@LessonId int
AS
BEGIN
	INSERT INTO [dbo].[Courses_Lessons] ([CourseId], [LessonId])
	VALUES (@CourseId, @LessonId)
END
BEGIN
	UPDATE [dbo].[Courses_Lessons]
	SET [CourseId] = @CourseId,
	[LessonId] = @LessonId
	WHERE [CourseId] = @CourseId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCoursesTargetAudienciesByCourseId]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCoursesTargetAudienciesByCourseId]
	@CourseId int,
	@TargetAudienceId int
AS
BEGIN
	INSERT INTO [dbo].[Courses_Lessons] ([CourseId], [LessonId])
	VALUES (@CourseId, @TargetAudienceId)
END
BEGIN
	UPDATE [dbo].[Courses_TargetAudiencies]
	SET [CourseId] = @CourseId,
	[TargetAudienceId] = @TargetAudienceId
	WHERE [CourseId] = @CourseId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLessonById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateLessonById]
	@Id int,
	@Name nvarchar(500),
	@Material nvarchar(max)
AS
BEGIN
	UPDATE [dbo].[Lessons]
	SET [Name] = @Name,
	[Material] = @Material
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateQuestionById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateQuestionById]
	@Id int,
	@TestId int,
	@Question nvarchar(1000)
AS
BEGIN
	UPDATE [dbo].[Questions]
	SET [Question] = @Question,
	[TestId] = @TestId
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRoleById]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE [dbo].[Roles]
	SET [Name] = @Name
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTargetAudienceById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateTargetAudienceById]
	@Id int,
	@Name nvarchar(500)
AS
BEGIN
	UPDATE [dbo].[TargetAudiencies]
	SET [Name] = @Name
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTestById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateTestById]
	@Id int,
	@Name nvarchar(500)
AS
BEGIN
	UPDATE [dbo].[Tests]
	SET [Name] = @Name
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserById]    Script Date: 04.02.2022 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUserById]
	@Id int,
	@Login nvarchar(50),
	@PasswordHash nvarchar(50),
	@Email nvarchar(50),
	@RoleId int,
	@Lastname nvarchar(50),
	@Firstname nvarchar(50),
	@Patronymic nvarchar(50)
AS
BEGIN
	UPDATE [dbo].[Users]
	SET 
	[Login] = @Login,
	[PasswordHash] = @PasswordHash,
	[Email] = @Email,
	[RoleId] = @RoleId,
	[Lastname] = @Lastname,
	[Firstname] = @Firstname,
	[Patronymic] = @Patronymic
	OUTPUT Inserted.Id
	WHERE [Id] = @Id
END
GO
USE [master]
GO
ALTER DATABASE [TrainingPortal] SET  READ_WRITE 
GO
