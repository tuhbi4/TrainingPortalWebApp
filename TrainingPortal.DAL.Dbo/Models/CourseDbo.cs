namespace TrainingPortal.DAL.Dbo.Models
{
    public class CourseDbo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int TestId { get; set; }

        public int CertificateId { get; set; }
    }
}