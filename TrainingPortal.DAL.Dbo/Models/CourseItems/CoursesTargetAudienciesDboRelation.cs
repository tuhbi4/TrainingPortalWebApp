namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class CoursesTargetAudienciesDboRelation
    {
        public int CourseId { get; set; }

        public int TargetAudienceId { get; set; }

        public CoursesTargetAudienciesDboRelation()
        { }

        public CoursesTargetAudienciesDboRelation(int courseId, int targetAudienceId)
        {
            CourseId = courseId;
            TargetAudienceId = targetAudienceId;
        }
    }
}