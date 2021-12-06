namespace TrainingPortal.Entities.Models.CourseItems
{
    public class Certificate
    {
        public int Id { get; }

        public string CourseName { get; private set; }

        public string ImageLink { get; private set; }

        public string UserName { get; private set; }

        public Certificate(int id, string courseName, string image, string userName)
        {
            Id = id;
            CourseName = courseName;
            ImageLink = image;
            UserName = userName;
        }

        public Certificate(int id, string courseName, string image, User user) : this(id, courseName, image, $"{user.Lastname} {user.Firstname} {user.Patronymic}")
        {
        }

        public Certificate(int id, string courseName, string image) : this(id, courseName, image, "Lastname Firstname Patronymic")
        {
        }

        public void UpdateCourseName(string courseName)
        {
            CourseName = courseName;
        }

        public void UpdateImage(string image)
        {
            ImageLink = image;
        }

        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }
    }
}