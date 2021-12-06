namespace TrainingPortal.DAL.Dbo.CourseItems
{
    public class CertificateDbo
    {
        public int Id { get; }

        public string CourseName { get; }

        public string ImageLink { get; }

        public CertificateDbo(int id, string courseName, string image)
        {
            Id = id;
            CourseName = courseName;
            ImageLink = image;
        }
    }
}