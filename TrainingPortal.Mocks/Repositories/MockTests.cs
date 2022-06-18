using System.Collections.Generic;
using TrainingPortal.Entities.Models.CourseItems;

namespace TrainingPortal.DAL.Mocks
{
    public class MockTests : MockRepository<Test>
    {
        public List<Test> List
        {
            get => new()
            {
                new Test(1, "Test \"Layout designer\"",
                new()
                {
                    mockTestQuestions.List[0],
                    mockTestQuestions.List[1],
                    mockTestQuestions.List[2]
                }),
                new Test(2, "Test \"ASP.NET developer\"",
                new()
                {
                    mockTestQuestions.List[3],
                    mockTestQuestions.List[4],
                    mockTestQuestions.List[5],
                    mockTestQuestions.List[6],
                    mockTestQuestions.List[7],
                    mockTestQuestions.List[8],
                    mockTestQuestions.List[9]
                }),
                new Test(3, "Test \"Frontend developer\"",
                new()
                {
                    mockTestQuestions.List[10],
                    mockTestQuestions.List[11],
                    mockTestQuestions.List[12],
                    mockTestQuestions.List[13],
                    mockTestQuestions.List[14],
                    mockTestQuestions.List[15]
                }),
                new Test(4, "Test \"Python developer\"",
                new()
                {
                    mockTestQuestions.List[16],
                    mockTestQuestions.List[17],
                    mockTestQuestions.List[18],
                    mockTestQuestions.List[19],
                    mockTestQuestions.List[20]
                }),
                new Test(5, "Test \"PHP developer\"",
                new()
                {
                    mockTestQuestions.List[21],
                    mockTestQuestions.List[22],
                    mockTestQuestions.List[23],
                    mockTestQuestions.List[24]
                }),
            };
            set => throw new System.NotImplementedException();
        }

        private static readonly MockTestQuestions mockTestQuestions = new();
    }
}