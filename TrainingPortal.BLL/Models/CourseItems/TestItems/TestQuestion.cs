using System.Collections.Generic;
using TrainingPortal.BLL.Models.CourseItems.TestItems.TestQuestionItems;

namespace TrainingPortal.BLL.Models.CourseItems.TestItems
{
    public class TestQuestion
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public List<Answer> Answers { get; set; }
    }
}