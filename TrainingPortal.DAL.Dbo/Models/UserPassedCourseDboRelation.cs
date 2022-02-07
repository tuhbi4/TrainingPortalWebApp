namespace TrainingPortal.DAL.Dbo.Models
{
    public class UserPassedCourseDboRelation
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public UserPassedCourseDboRelation()
        { }

        public UserPassedCourseDboRelation(int userId, int courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }
    }
}