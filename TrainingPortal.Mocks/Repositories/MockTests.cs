using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockTests : MockRepository<Test>
    {
        public List<Test> List
        {
            get => new()
            {
                new Test(1, "First test",
                new() { mockTestQuestions.List[0], mockTestQuestions.List[1], mockTestQuestions.List[2] }),
                new Test(2, "First test",
                new()
                {
                    mockTestQuestions.List[3],
                    mockTestQuestions.List[4],
                    mockTestQuestions.List[5],
                    mockTestQuestions.List[6]
                }),
                new Test(3, "First test",
                new() { mockTestQuestions.List[1], mockTestQuestions.List[3], mockTestQuestions.List[6] }),
            };
            set => throw new System.NotImplementedException();
        }

        private static readonly MockTestQuestions mockTestQuestions = new();
    }
}