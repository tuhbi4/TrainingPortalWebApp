using System;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.Entities.Models;
using TrainingPortal.Entities.Models.CourseItems;
using TrainingPortal.Entities.Models.CourseItems.TestItems;
using TrainingPortal.Entities.Models.CourseItems.TestItems.TestQuestionItems;

namespace TrainingPortal.BLL.Services
{
    public class ModelMapper : IModelMapper
    {
        public TOut ConvertToDomainModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class
        {
            switch (typeof(TIn).Name)
            {
                case nameof(AnswerDbo):
                    AnswerDbo answerDbo = sourceInstance as AnswerDbo;
                    return new Answer(answerDbo.Id, answerDbo.Text) as TOut;

                case nameof(TestQuestionDbo):
                    TestQuestionDbo testQuestionDbo = sourceInstance as TestQuestionDbo;
                    return new TestQuestion(testQuestionDbo.Id, testQuestionDbo.Question, null) as TOut;

                case nameof(CertificateDbo):
                    CertificateDbo certificateDbo = sourceInstance as CertificateDbo;
                    return new Certificate(certificateDbo.Id, certificateDbo.CourseName, certificateDbo.ImageLink) as TOut;

                case nameof(LessonDbo):
                    LessonDbo lessonDbo = sourceInstance as LessonDbo;
                    return new Lesson(lessonDbo.Id, lessonDbo.Name, lessonDbo.Material) as TOut;

                case nameof(TargetAudienceDbo):
                    TargetAudienceDbo targetAudienceDbo = sourceInstance as TargetAudienceDbo;
                    return new TargetAudience(targetAudienceDbo.Id, targetAudienceDbo.Name) as TOut;

                case nameof(TestDbo):
                    TestDbo testDbo = sourceInstance as TestDbo;
                    return new Test(testDbo.Id, testDbo.Name, null) as TOut;

                case nameof(CategoryDbo):
                    CategoryDbo categoryDbo = sourceInstance as CategoryDbo;
                    return new Category(categoryDbo.Id, categoryDbo.Name) as TOut;

                case nameof(CourseDbo):
                    CourseDbo courseDbo = sourceInstance as CourseDbo;
                    return new Course(courseDbo.Id, courseDbo.Name, courseDbo.Description, null, null, null, null, null) as TOut;

                case nameof(RoleDbo):
                    RoleDbo roleDbo = sourceInstance as RoleDbo;
                    return new Role(roleDbo.Id, roleDbo.Name) as TOut;

                case nameof(UserDbo):
                    UserDbo userDbo = sourceInstance as UserDbo;
                    return new User(userDbo.Id, userDbo.Login, userDbo.PasswordHash, userDbo.Email, null,
                        userDbo.Lastname, userDbo.Firstname, userDbo.Patronymic) as TOut;

                default:
                    throw new ArgumentException("The argument type is not in the allowed list.", typeof(TIn).Name);
            }
        }

        public TOut ConvertToDboModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class
        {
            switch (typeof(TIn).Name)
            {
                case nameof(Answer):
                    Answer answer = sourceInstance as Answer;
                    return new AnswerDbo(answer.Id, 0, answer.Text) as TOut;

                case nameof(TestQuestion):
                    TestQuestion testQuestion = sourceInstance as TestQuestion;
                    return new TestQuestionDbo(testQuestion.Id, 0, testQuestion.Question) as TOut;

                case nameof(Certificate):
                    Certificate certificate = sourceInstance as Certificate;
                    return new CertificateDbo(certificate.Id, certificate.CourseName, certificate.ImageLink) as TOut;

                case nameof(Lesson):
                    Lesson lesson = sourceInstance as Lesson;
                    return new LessonDbo(lesson.Id, lesson.Name, lesson.Material) as TOut;

                case nameof(TargetAudience):
                    TargetAudience targetAudience = sourceInstance as TargetAudience;
                    return new TargetAudienceDbo(targetAudience.Id, targetAudience.Name) as TOut;

                case nameof(Test):
                    Test test = sourceInstance as Test;
                    return new TestDbo(test.Id, test.Name) as TOut;

                case nameof(Category):
                    Category category = sourceInstance as Category;
                    return new CategoryDbo(category.Id, category.Name) as TOut;

                case nameof(Course):
                    Course course = sourceInstance as Course;
                    return new CourseDbo(course.Id, course.Name, course.Description, 0, course.Test.Id, course.Certificate.Id) as TOut;

                case nameof(Role):
                    Role role = sourceInstance as Role;
                    return new RoleDbo(role.Id, role.Name) as TOut;

                case nameof(User):
                    User user = sourceInstance as User;
                    return new UserDbo(user.Id, user.Login, user.Password, user.Email, 0,
                        user.Lastname, user.Firstname, user.Patronymic) as TOut;

                default:
                    throw new ArgumentException("The argument type is not in the allowed list.", typeof(TIn).Name);
            }
        }
    }
}