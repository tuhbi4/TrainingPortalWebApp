namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class CoursesLessonsDboRelation
    {
        public int CourseId { get; set; }

        public int LessonId { get; set; }

        public CoursesLessonsDboRelation()
        { }

        public CoursesLessonsDboRelation(int courseId, int lessonId)
        {
            CourseId = courseId;
            LessonId = lessonId;
        }
    }
}