namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class CoursesTargetAudienciesDboRelation
    {
        public int CourseId { get; }

        public int TargetAudienceId { get; }

        public CoursesTargetAudienciesDboRelation(int courseId, int targetAudienceId)
        {
            CourseId = courseId;
            TargetAudienceId = targetAudienceId;
        }
    }
}