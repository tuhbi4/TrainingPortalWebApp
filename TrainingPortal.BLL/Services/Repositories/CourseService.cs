using AutoMapper;
using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class CourseService : ISearchableRepositoryService<Course>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<CategoryDbo> categoryDboRepository;
        private readonly IDboRepository<CertificateDbo> certificateDboRepository;
        private readonly ISearchableDboRepository<CourseDbo> courseDboRepository;
        private readonly IDboInnerRepository<AnswerDbo> answerDboInnerRepository;
        private readonly IDboInnerRepository<TestQuestionDbo> testQuestionDboInnerRepository;
        private readonly IDboRelationsRepository<CoursesLessonsDboRelation> coursesLessonsDboRelationsRepository;
        private readonly IDboRelationsRepository<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboRelationsRepository;
        private readonly IDboRepository<LessonDbo> lessonDboRepository;
        private readonly IDboRepository<TargetAudienceDbo> targetAudienceDboRepository;
        private readonly IDboRepository<TestDbo> testDboRepository;

        public CourseService(IMapper mapper, IDboRepository<CategoryDbo> categoryDboRepository,
            IDboRepository<CertificateDbo> certificateDboRepository, ISearchableDboRepository<CourseDbo> courseDboRepository,
            IDboInnerRepository<AnswerDbo> answerDboInnerRepository, IDboInnerRepository<TestQuestionDbo> testQuestionDboInnerRepository,
            IDboRelationsRepository<CoursesLessonsDboRelation> coursesLessonsDboRelationsRepository,
            IDboRelationsRepository<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboRelationsRepository,
            IDboRepository<LessonDbo> lessonDboRepository, IDboRepository<TargetAudienceDbo> targetAudienceDboRepository, IDboRepository<TestDbo> testDboRepository)
        {
            this.mapper = mapper;
            this.categoryDboRepository = categoryDboRepository;
            this.certificateDboRepository = certificateDboRepository;
            this.courseDboRepository = courseDboRepository;
            this.answerDboInnerRepository = answerDboInnerRepository;
            this.testQuestionDboInnerRepository = testQuestionDboInnerRepository;
            this.coursesLessonsDboRelationsRepository = coursesLessonsDboRelationsRepository;
            this.coursesTargetAudienciesDboRelationsRepository = coursesTargetAudienciesDboRelationsRepository;
            this.lessonDboRepository = lessonDboRepository;
            this.targetAudienceDboRepository = targetAudienceDboRepository;
            this.testDboRepository = testDboRepository;
        }

        public int Create(Course dataInstance)
        {
            CourseDbo courseDbo = mapper.Map<CourseDbo>(dataInstance);
            courseDbo.CategoryId = dataInstance.Category.Id;
            TestDbo testDboInstance = mapper.Map<TestDbo>(dataInstance.Test);
            courseDbo.TestId = testDboRepository.Create(testDboInstance);
            CertificateDbo certificateDboInstance = mapper.Map<CertificateDbo>(dataInstance.Certificate);
            courseDbo.CertificateId = certificateDboRepository.Create(certificateDboInstance);
            courseDbo.Id = courseDboRepository.Create(courseDbo);

            foreach (Lesson lesson in dataInstance.LessonsList)
            {
                LessonDbo lessonDbo = mapper.Map<LessonDbo>(lesson);
                var newLessonId = lessonDboRepository.Create(lessonDbo);
                coursesLessonsDboRelationsRepository.Create(new CoursesLessonsDboRelation() { CourseId = courseDbo.Id, LessonId = newLessonId });
            }

            foreach (TestQuestion testQuestion in dataInstance.Test.QuestionsList)
            {
                TestQuestionDbo testQuestionDbo = mapper.Map<TestQuestionDbo>(testQuestion);
                testQuestionDbo.TestId = courseDbo.TestId;
                int newQuestionId = testQuestionDboInnerRepository.Create(testQuestionDbo);

                foreach (Answer answer in testQuestion.Answers)
                {
                    AnswerDbo answerDbo = mapper.Map<AnswerDbo>(answer);
                    answerDbo.QuestionId = newQuestionId;
                    answerDboInnerRepository.Create(answerDbo);
                }
            }

            foreach (TargetAudience targetAudience in dataInstance.TargetAudienciesList)
            {
                coursesTargetAudienciesDboRelationsRepository.Create(new CoursesTargetAudienciesDboRelation() { CourseId = courseDbo.Id, TargetAudienceId = targetAudience.Id });
            }

            return courseDbo.Id;
        }

        public Course Read(int id)
        {
            CourseDbo courseDbo = courseDboRepository.Read(id);
            Course course = mapper.Map<Course>(courseDbo);
            CategoryDbo categoryDbo = categoryDboRepository.Read(courseDbo.CategoryId);
            course.Category = mapper.Map<Category>(categoryDbo);
            List<Lesson> lessonList = new();
            List<CoursesLessonsDboRelation> coursesLessonsDboRelationList = coursesLessonsDboRelationsRepository.Read(id);

            foreach (CoursesLessonsDboRelation coursesLessonsDboRelation in coursesLessonsDboRelationList)
            {
                LessonDbo lessonDbo = lessonDboRepository.Read(coursesLessonsDboRelation.LessonId);
                lessonList.Add(mapper.Map<Lesson>(lessonDbo));
            }

            course.LessonsList = lessonList;

            TestDbo testDbo = testDboRepository.Read(courseDbo.TestId);
            Test test = mapper.Map<Test>(testDbo);
            List<TestQuestion> questionsList = new();
            List<TestQuestionDbo> testQuestionDboList = testQuestionDboInnerRepository.ReadAllByParentId(test.Id);

            foreach (TestQuestionDbo testQuestionDbo in testQuestionDboList)
            {
                TestQuestion testQuestion = mapper.Map<TestQuestion>(testQuestionDbo);
                List<Answer> answersList = new();
                List<AnswerDbo> answerDboList = answerDboInnerRepository.ReadAllByParentId(testQuestion.Id);

                foreach (AnswerDbo answerDbo in answerDboList)
                {
                    answersList.Add(mapper.Map<Answer>(answerDbo));
                }

                testQuestion.Answers = answersList;
                questionsList.Add(testQuestion);
            }

            test.QuestionsList = questionsList;
            course.Test = test;
            CertificateDbo certificateDbo = certificateDboRepository.Read(courseDbo.CertificateId);
            course.Certificate = mapper.Map<Certificate>(certificateDbo);

            List<TargetAudience> targetAudienceList = new();
            List<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboRelationList = coursesTargetAudienciesDboRelationsRepository.Read(id);

            foreach (CoursesTargetAudienciesDboRelation coursesTargetAudienciesDboRelation in coursesTargetAudienciesDboRelationList)
            {
                TargetAudienceDbo targetAudienceDbo = targetAudienceDboRepository.Read(coursesTargetAudienciesDboRelation.TargetAudienceId);
                targetAudienceList.Add(mapper.Map<TargetAudience>(targetAudienceDbo));
            }

            course.TargetAudienciesList = targetAudienceList;

            return course;
        }

        public List<Course> ReadAll()
        {
            List<Course> courseList = new();
            List<AnswerDbo> answerDboList = answerDboInnerRepository.ReadAll();
            List<CategoryDbo> categoryDboList = categoryDboRepository.ReadAll();
            List<CertificateDbo> certificateDboList = certificateDboRepository.ReadAll();
            List<CourseDbo> courseDboList = courseDboRepository.ReadAll();
            List<CoursesLessonsDboRelation> coursesLessonsDboList = coursesLessonsDboRelationsRepository.ReadAll();
            List<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboList = coursesTargetAudienciesDboRelationsRepository.ReadAll();
            List<LessonDbo> lessonDboList = lessonDboRepository.ReadAll();
            List<TestQuestionDbo> testQuestionDboList = testQuestionDboInnerRepository.ReadAll();
            List<TargetAudienceDbo> targetAudienceDboList = targetAudienceDboRepository.ReadAll();
            List<TestDbo> testDboList = testDboRepository.ReadAll();

            foreach (CourseDbo courseDbo in courseDboList)
            {
                Course course = mapper.Map<Course>(courseDbo);
                List<Lesson> lessonList = new();

                foreach (CoursesLessonsDboRelation coursesLessonsDbo in coursesLessonsDboList)
                {
                    if (coursesLessonsDbo.CourseId == courseDbo.Id)
                    {
                        LessonDbo lessondbo = lessonDboList.Find(x => x.Id == coursesLessonsDbo.LessonId);
                        lessonList.Add(mapper.Map<Lesson>(lessondbo));
                    }
                }

                Test test = mapper.Map<Test>(testDboList.Find(x => x.Id == courseDbo.TestId));
                List<TestQuestion> questionsList = new();

                foreach (TestQuestionDbo testQuestionDbo in testQuestionDboList)
                {
                    if (testQuestionDbo.TestId == test.Id)
                    {
                        TestQuestion testQuestion = mapper.Map<TestQuestion>(testQuestionDbo);
                        List<Answer> answersList = new();

                        foreach (AnswerDbo answerDbo in answerDboList)
                        {
                            if (answerDbo.QuestionId == testQuestion.Id)
                            {
                                answersList.Add(mapper.Map<Answer>(answerDbo));
                            }
                        }

                        testQuestion.Answers = answersList;
                        questionsList.Add(testQuestion);
                    }
                }

                test.QuestionsList = questionsList;

                List<TargetAudience> targetAudienceList = new();

                foreach (CoursesTargetAudienciesDboRelation coursesTargetAudienciesDbo in coursesTargetAudienciesDboList)
                {
                    if (coursesTargetAudienciesDbo.CourseId == courseDbo.Id)
                    {
                        TargetAudienceDbo targetAudienceDbo = targetAudienceDboList.Find(x => x.Id == coursesTargetAudienciesDbo.TargetAudienceId);
                        targetAudienceList.Add(mapper.Map<TargetAudience>(targetAudienceDbo));
                    }
                }

                course.Category = mapper.Map<Category>(categoryDboList.Find(x => x.Id == courseDbo.CategoryId));
                course.LessonsList = lessonList;
                course.Test = test;
                course.Certificate = mapper.Map<Certificate>(certificateDboList.Find(x => x.Id == courseDbo.CertificateId));
                course.TargetAudienciesList = targetAudienceList;
                courseList.Add(course);
            }

            return courseList;
        }

        public int Update(int id, Course dataInstance)
        {
            List<CoursesLessonsDboRelation> coursesLessonsDboRelationList = coursesLessonsDboRelationsRepository.Read(id);
            coursesLessonsDboRelationsRepository.Delete(id);

            foreach (CoursesLessonsDboRelation coursesLessonsDboRelation in coursesLessonsDboRelationList)
            {
                lessonDboRepository.Delete(coursesLessonsDboRelation.LessonId);
            }

            foreach (Lesson lesson in dataInstance.LessonsList)
            {
                var newLessonId = lessonDboRepository.Create(mapper.Map<LessonDbo>(lesson));
                coursesLessonsDboRelationsRepository.Create(new CoursesLessonsDboRelation() { CourseId = id, LessonId = newLessonId });
            }

            Course targetCourse = Read(id);
            testDboRepository.Update(targetCourse.Test.Id, mapper.Map<TestDbo>(dataInstance.Test));

            foreach (TestQuestion testQuestion in targetCourse.Test.QuestionsList)
            {
                answerDboInnerRepository.DeleteAllByParentId(testQuestion.Id);
            }

            testQuestionDboInnerRepository.DeleteAllByParentId(targetCourse.Test.Id);

            foreach (TestQuestion testQuestion in dataInstance.Test.QuestionsList)
            {
                TestQuestionDbo testQuestionDbo = mapper.Map<TestQuestionDbo>(testQuestion);
                testQuestionDbo.TestId = targetCourse.Test.Id;
                int questionId = testQuestionDboInnerRepository.Create(testQuestionDbo);

                foreach (Answer answer in testQuestion.Answers)
                {
                    AnswerDbo answerDbo = mapper.Map<AnswerDbo>(answer);
                    answerDbo.QuestionId = questionId;
                    answerDboInnerRepository.Create(answerDbo);
                }
            }

            certificateDboRepository.Update(dataInstance.Certificate.Id, mapper.Map<CertificateDbo>(dataInstance.Certificate));

            coursesTargetAudienciesDboRelationsRepository.Delete(id);

            foreach (TargetAudience targetAudience in dataInstance.TargetAudienciesList)
            {
                coursesTargetAudienciesDboRelationsRepository.Create(new CoursesTargetAudienciesDboRelation() { CourseId = id, TargetAudienceId = targetAudience.Id });
            }

            return courseDboRepository.Update(id, mapper.Map<CourseDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return courseDboRepository.Delete(id);
        }

        public List<Course> Search(string courseName, string categoryName, string targetAudiencyName)
        {
            List<Course> resultList = new();

            foreach (CourseDbo courseDbo in courseDboRepository.Search(courseName, categoryName, targetAudiencyName))
            {
                resultList.Add(Read(courseDbo.Id));
            }

            return resultList;
        }
    }
}