using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;
using TrainingPortal.Entities.Models.CourseItems;
using TrainingPortal.Entities.Models.CourseItems.TestItems;
using TrainingPortal.Entities.Models.CourseItems.TestItems.TestQuestionItems;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class CourseRepositoryService : IRepositoryService<Course>
    {
        private readonly IModelMapper _modelMapper;
        private readonly IDboRepository<CategoryDbo> _categoryDboRepository;
        private readonly IDboRepository<CertificateDbo> _certificateDboRepository;
        private readonly IDboRepository<CourseDbo> _courseDboRepository;
        private readonly IDboInnerRepository<AnswerDbo> _answerDboInnerRepository;
        private readonly IDboInnerRepository<TestQuestionDbo> _testQuestionDboInnerRepository;
        private readonly IDboRelationsRepository<CoursesLessonsDboRelation> _coursesLessonsDboRelationsRepository;
        private readonly IDboRelationsRepository<CoursesTargetAudienciesDboRelation> _coursesTargetAudienciesDboRelationsRepository;
        private readonly IDboRepository<LessonDbo> _lessonDboRepository;
        private readonly IDboRepository<TargetAudienceDbo> _targetAudienceDboRepository;
        private readonly IDboRepository<TestDbo> _testDboRepository;

        public CourseRepositoryService(IModelMapper modelMapper, IDboRepository<CategoryDbo> categoryDboRepository,
            IDboRepository<CertificateDbo> certificateDboRepository, IDboRepository<CourseDbo> courseDboRepository,
            IDboInnerRepository<AnswerDbo> answerDboInnerRepository, IDboInnerRepository<TestQuestionDbo> testQuestionDboInnerRepository,
            IDboRelationsRepository<CoursesLessonsDboRelation> coursesLessonsDboRelationsRepository,
            IDboRelationsRepository<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboRelationsRepository,
            IDboRepository<LessonDbo> lessonDboRepository, IDboRepository<TargetAudienceDbo> targetAudienceDboRepository, IDboRepository<TestDbo> testDboRepository)
        {
            _modelMapper = modelMapper;
            _categoryDboRepository = categoryDboRepository;
            _certificateDboRepository = certificateDboRepository;
            _courseDboRepository = courseDboRepository;
            _answerDboInnerRepository = answerDboInnerRepository;
            _testQuestionDboInnerRepository = testQuestionDboInnerRepository;
            _coursesLessonsDboRelationsRepository = coursesLessonsDboRelationsRepository;
            _coursesTargetAudienciesDboRelationsRepository = coursesTargetAudienciesDboRelationsRepository;
            _lessonDboRepository = lessonDboRepository;
            _targetAudienceDboRepository = targetAudienceDboRepository;
            _testDboRepository = testDboRepository;
        }

        public int Create(Course dataInstance)
        {
            CourseDbo courseDboInstance = _modelMapper.ConvertToDboModel<Course, CourseDbo>(dataInstance);
            courseDboInstance.UpdateCategoryId(dataInstance.Category.Id);
            courseDboInstance.UpdateTestId(dataInstance.Test.Id);
            courseDboInstance.UpdateCertificateId(dataInstance.Certificate.Id);
            _courseDboRepository.Create(courseDboInstance);
            TestDbo testDboInstance = _modelMapper.ConvertToDboModel<Test, TestDbo>(dataInstance.Test);
            _testDboRepository.Create(testDboInstance);

            foreach (TargetAudience targetAudienceInstance in dataInstance.TargetAudienciesList)
            {
                TargetAudienceDbo targetAudienceDboInstance = _modelMapper.ConvertToDboModel<TargetAudience, TargetAudienceDbo>(targetAudienceInstance);
                _targetAudienceDboRepository.Create(targetAudienceDboInstance);
            }

            foreach (Lesson lessonInstance in dataInstance.LessonsList)
            {
                LessonDbo lessonDboInstance = _modelMapper.ConvertToDboModel<Lesson, LessonDbo>(lessonInstance);
                _lessonDboRepository.Create(lessonDboInstance);
            }

            CertificateDbo certificateDboInstance = _modelMapper.ConvertToDboModel<Certificate, CertificateDbo>(dataInstance.Certificate);
            _certificateDboRepository.Create(certificateDboInstance);

            foreach (TestQuestion testQuestionInstance in dataInstance.Test.QuestionsList)
            {
                TestQuestionDbo testQuestionDboInstance = _modelMapper.ConvertToDboModel<TestQuestion, TestQuestionDbo>(testQuestionInstance);
                _testQuestionDboInnerRepository.Create(testQuestionDboInstance);

                foreach (Answer answerInstance in testQuestionInstance.Answers)
                {
                    AnswerDbo answerDboInstance = _modelMapper.ConvertToDboModel<Answer, AnswerDbo>(answerInstance);
                    _answerDboInnerRepository.Create(answerDboInstance);
                }
            }

            return _courseDboRepository.Create(courseDboInstance);
        }

        public Course Read(int id)
        {
            //return ReadAll().Find(x => x.Id == id);
            CourseDbo courseDbo = _courseDboRepository.Read(id);
            Course course = _modelMapper.ConvertToDomainModel<CourseDbo, Course>(courseDbo);
            CategoryDbo categoryDbo = _categoryDboRepository.Read(courseDbo.CategoryId);
            course.UpdateCategory(_modelMapper.ConvertToDomainModel<CategoryDbo, Category>(categoryDbo));
            List<Lesson> lessonList = new();
            List<CoursesLessonsDboRelation> coursesLessonsDboRelationList = _coursesLessonsDboRelationsRepository.Read(id);

            foreach (CoursesLessonsDboRelation coursesLessonsDboRelation in coursesLessonsDboRelationList)
            {
                LessonDbo lessonDbo = _lessonDboRepository.Read(coursesLessonsDboRelation.LessonId);
                lessonList.Add(_modelMapper.ConvertToDomainModel<LessonDbo, Lesson>(lessonDbo));
            }

            course.UpdateLessonsList(lessonList);

            TestDbo testDbo = _testDboRepository.Read(courseDbo.TestId);
            Test test = _modelMapper.ConvertToDomainModel<TestDbo, Test>(testDbo);
            List<TestQuestion> questionsList = new();
            List<TestQuestionDbo> testQuestionDboList = _testQuestionDboInnerRepository.ReadAllByParentId(test.Id);

            foreach (TestQuestionDbo testQuestionDbo in testQuestionDboList)
            {
                TestQuestion testQuestion = _modelMapper.ConvertToDomainModel<TestQuestionDbo, TestQuestion>(testQuestionDbo);
                List<Answer> answersList = new();
                List<AnswerDbo> answerDboList = _answerDboInnerRepository.ReadAllByParentId(testQuestion.Id);

                foreach (AnswerDbo answerDbo in answerDboList)
                {
                    answersList.Add(_modelMapper.ConvertToDomainModel<AnswerDbo, Answer>(answerDbo));
                }

                testQuestion.UpdateAnswers(answersList);
                questionsList.Add(testQuestion);
            }

            test.UpdateQuestions(questionsList);
            course.UpdateTest(test);
            CertificateDbo certificateDbo = _certificateDboRepository.Read(courseDbo.CertificateId);
            course.UpdateCertificate(_modelMapper.ConvertToDomainModel<CertificateDbo, Certificate>(certificateDbo));

            List<TargetAudience> targetAudienceList = new();
            List<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboRelationList = _coursesTargetAudienciesDboRelationsRepository.Read(id);

            foreach (CoursesTargetAudienciesDboRelation coursesTargetAudienciesDboRelation in coursesTargetAudienciesDboRelationList)
            {
                TargetAudienceDbo targetAudienceDbo = _targetAudienceDboRepository.Read(coursesTargetAudienciesDboRelation.TargetAudienceId);
                targetAudienceList.Add(_modelMapper.ConvertToDomainModel<TargetAudienceDbo, TargetAudience>(targetAudienceDbo));
            }

            course.UpdateTargetAudienciesList(targetAudienceList);

            return course;
        }

        public List<Course> ReadAll()
        {
            List<Course> courseList = new();
            List<AnswerDbo> answerDboList = _answerDboInnerRepository.ReadAll();
            List<CategoryDbo> categoryDboList = _categoryDboRepository.ReadAll();
            List<CertificateDbo> certificateDboList = _certificateDboRepository.ReadAll();
            List<CourseDbo> courseDboList = _courseDboRepository.ReadAll();
            List<CoursesLessonsDboRelation> coursesLessonsDboList = _coursesLessonsDboRelationsRepository.ReadAll();
            List<CoursesTargetAudienciesDboRelation> coursesTargetAudienciesDboList = _coursesTargetAudienciesDboRelationsRepository.ReadAll();
            List<LessonDbo> lessonDboList = _lessonDboRepository.ReadAll();
            List<TestQuestionDbo> testQuestionDboList = _testQuestionDboInnerRepository.ReadAll();
            List<TargetAudienceDbo> targetAudienceDboList = _targetAudienceDboRepository.ReadAll();
            List<TestDbo> testDboList = _testDboRepository.ReadAll();

            foreach (CourseDbo courseDbo in courseDboList)
            {
                Course course = _modelMapper.ConvertToDomainModel<CourseDbo, Course>(courseDbo);
                List<Lesson> lessonList = new();

                foreach (CoursesLessonsDboRelation coursesLessonsDbo in coursesLessonsDboList)
                {
                    if (coursesLessonsDbo.CourseId == courseDbo.Id)
                    {
                        LessonDbo lessondbo = lessonDboList.Find(x => x.Id == coursesLessonsDbo.LessonId);
                        lessonList.Add(_modelMapper.ConvertToDomainModel<LessonDbo, Lesson>(lessondbo));
                    }
                }

                Test test = _modelMapper.ConvertToDomainModel<TestDbo, Test>(testDboList.Find(x => x.Id == courseDbo.TestId));
                List<TestQuestion> questionsList = new();

                foreach (TestQuestionDbo testQuestionDbo in testQuestionDboList)
                {
                    if (testQuestionDbo.TestId == test.Id)
                    {
                        TestQuestion testQuestion = _modelMapper.ConvertToDomainModel<TestQuestionDbo, TestQuestion>(testQuestionDbo);
                        List<Answer> answersList = new();

                        foreach (AnswerDbo answerDbo in answerDboList)
                        {
                            if (answerDbo.QuestionId == testQuestion.Id)
                            {
                                answersList.Add(_modelMapper.ConvertToDomainModel<AnswerDbo, Answer>(answerDbo));
                            }
                        }

                        testQuestion.UpdateAnswers(answersList);
                        questionsList.Add(testQuestion);
                    }
                }

                test.UpdateQuestions(questionsList);

                List<TargetAudience> targetAudienceList = new();

                foreach (CoursesTargetAudienciesDboRelation coursesTargetAudienciesDbo in coursesTargetAudienciesDboList)
                {
                    if (coursesTargetAudienciesDbo.CourseId == courseDbo.Id)
                    {
                        TargetAudienceDbo targetAudienceDbo = targetAudienceDboList.Find(x => x.Id == coursesTargetAudienciesDbo.TargetAudienceId);
                        targetAudienceList.Add(_modelMapper.ConvertToDomainModel<TargetAudienceDbo, TargetAudience>(targetAudienceDbo));
                    }
                }

                course.UpdateCategory(_modelMapper.ConvertToDomainModel<CategoryDbo, Category>(categoryDboList.Find(x => x.Id == courseDbo.CategoryId)));
                course.UpdateLessonsList(lessonList);
                course.UpdateTest(test);
                course.UpdateCertificate(_modelMapper.ConvertToDomainModel<CertificateDbo, Certificate>(certificateDboList.Find(x => x.Id == courseDbo.CertificateId)));
                course.UpdateTargetAudienciesList(targetAudienceList);
                courseList.Add(course);
            }

            return courseList;
        }

        public int Update(int id, Course dataInstance)
        {
            throw new System.NotSupportedException();
        }

        public int Delete(int id)
        {
            return _courseDboRepository.Delete(id);
        }
    }
}