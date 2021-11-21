using System.Collections.Generic;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockCertificates
    {
        public List<Certificate> CertificatesList { get; set; } = new List<Certificate>()
        {
            new Certificate(1, "Layout designer",
                @"https://image.freepik.com/free-vector/layout-designer-concept-web-development-mobile-app-design-people-building-user-interface-template-computer-technology_277904-10536.jpg",
                "Lastname Firstname Patronymic"),
            new Certificate(2, "ASP.NET Developer",
                @"https://www.aceinfoway.com/blog/wp-content/uploads/2020/05/Top-5-benefits-of-using-ASPNET-Core.jpg",
                "Lastname Firstname Patronymic"),
            new Certificate(3, "Frontend Developer",
                @"https://www.mindinventory.com/blog/wp-content/uploads/2021/03/frontend-development-tools.png",
                "Lastname Firstname Patronymic"),
            new Certificate(4, "Python Developer",
                @"https://jobaxes.com/wp-content/uploads/2021/05/Python-Developer-at-P.jpg",
                "Lastname Firstname Patronymic"),
            new Certificate(5, "PHP Developer",
                @"https://interact2019.org/wp-content/uploads/2021/05/php-Developer.jpg",
                "Lastname Firstname Patronymic"),
        };
    }
}