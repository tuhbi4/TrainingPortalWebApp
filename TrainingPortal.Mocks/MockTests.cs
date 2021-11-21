using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.BLL.Mocks
{
    public class MockTests
    {
        public List<Test> TestsList { get; set; } = new List<Test>()
        {
            new Test(1, "First test",
                new() { mockTestQuestions.TestQuestionsList[0], mockTestQuestions.TestQuestionsList[1], mockTestQuestions.TestQuestionsList[2]}),
            new Test(2, "First test",
                new() { mockTestQuestions.TestQuestionsList[3], mockTestQuestions.TestQuestionsList[4], mockTestQuestions.TestQuestionsList[5],
                    mockTestQuestions.TestQuestionsList[6]}),
            new Test(3, "First test",
                new() { mockTestQuestions.TestQuestionsList[1], mockTestQuestions.TestQuestionsList[3], mockTestQuestions.TestQuestionsList[6]}),
        };

        private static readonly MockTestQuestions mockTestQuestions = new();
    }
}