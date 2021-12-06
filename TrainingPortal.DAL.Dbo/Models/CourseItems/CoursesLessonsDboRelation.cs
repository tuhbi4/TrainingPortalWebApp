namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class CoursesLessonsDboRelation
    {
        public int CourseId { get; }

        public int LessonId { get; }

        public CoursesLessonsDboRelation(int courseId, int lessonId)
        {
            CourseId = courseId;
            LessonId = lessonId;
        }
    }
}