namespace TrainingPortal.Entities
{
    public class Certificate
    {
        public int Id { get; }

        public string CourseName { get; private set; }

        public string Image { get; private set; }

        public string UserName { get; private set; }

        public Certificate(int id, string courseName, string image, string userName)
        {
            Id = id;
            CourseName = courseName;
            Image = image;
            UserName = userName;
        }

        public void UpdateCourseName(string courseName)
        {
            CourseName = courseName;
        }

        public void UpdateImage(string image)
        {
            Image = image;
        }

        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }
    }
}