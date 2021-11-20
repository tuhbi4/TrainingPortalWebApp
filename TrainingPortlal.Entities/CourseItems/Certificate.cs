namespace TrainingPortal.Entities
{
    public class Certificate
    {
        public int Id { get; }

        public string CourseName { get; private set; }

        // UNDONE: certificate image - think over the type
        public object Image { get; private set; }

        public string UserName { get; private set; }

        public Certificate(string courseName, object image, string userName)
        {
            CourseName = courseName;
            Image = image;
            UserName = userName;
        }

        public void UpdateCourseName(string courseName)
        {
            CourseName = courseName;
        }

        public void UpdateImage(object image)
        {
            Image = image;
        }

        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }
    }
}