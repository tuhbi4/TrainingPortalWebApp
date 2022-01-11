using System.Collections.Generic;
using TrainingPortal.BLL.Models.CourseItems.TestItems;

namespace TrainingPortal.BLL.Models.CourseItems
{
    public class Test
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TestQuestion> QuestionsList { get; set; }
    }
}