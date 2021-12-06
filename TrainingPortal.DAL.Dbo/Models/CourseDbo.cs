namespace TrainingPortal.DAL.Dbo.Models
{
    public class CourseDbo
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public int CategoryId { get; private set; }

        public int TestId { get; private set; }

        public int CertificateId { get; private set; }

        public CourseDbo(int id, string name, string description, int categoryId, int testId, int certificateId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            TestId = testId;
            CertificateId = certificateId;
        }

        public void UpdateCategoryId(int id)
        {
            CategoryId = id;
        }

        public void UpdateTestId(int id)
        {
            TestId = id;
        }

        public void UpdateCertificateId(int id)
        {
            CertificateId = id;
        }
    }
}