using AutoMapper;
using System;
using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories.CourseParts
{
    public class TestService : IRepositoryService<Test>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<TestDbo> testDboRepository;
        private readonly IDboInnerRepository<TestQuestionDbo> testQuestionDboInnerRepository;
        private readonly IDboInnerRepository<AnswerDbo> answerDboInnerRepository;

        public TestService(IMapper mapper, IDboRepository<TestDbo> testDboRepository,
            IDboInnerRepository<TestQuestionDbo> testQuestionDboInnerRepository, IDboInnerRepository<AnswerDbo> answerDboInnerRepository)
        {
            this.mapper = mapper;
            this.testDboRepository = testDboRepository;
            this.testQuestionDboInnerRepository = testQuestionDboInnerRepository;
            this.answerDboInnerRepository = answerDboInnerRepository;
        }

        public int Create(Test dataInstance)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Test Read(int id)
        {
            TestDbo testDbo = testDboRepository.Read(id);
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

            return test;
        }

        public List<Test> ReadAll()
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Test dataInstance)
        {
            throw new NotImplementedException();
        }
    }
}