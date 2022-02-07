using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.WebPL.Helpers;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin, editor, user")]
    public class CertificateController : Controller
    {
        private readonly IRepositoryService<Course> courseService;
        private readonly IRepositoryService<User> userService;

        public CertificateController(IRepositoryService<Course> courseService, IRepositoryService<User> userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }

        // POST: CertificateController/Download?userId=1&courseId=1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Download(int userId, int courseId)
        {
            if (User.Identity.IsAuthenticated)
            {
                Course course = courseService.Read(courseId);
                Certificate certificate = course.Certificate;
                certificate.CourseName = course.Name;
                User user = userService.Read(userId);
                certificate.UserName = user.Firstname + " " + user.Lastname + " " + user.Patronymic;
                string viewHtml = await this.RenderViewAsync("Download", certificate);
                string fileName = "Certificate";
                string fileType = "application/pdf";
                string filePath = await this.GeneratePDF(viewHtml);

                return PhysicalFile(filePath, fileType, fileName);
            }

            return RedirectToAction("AccessDenied", "Home");
        }
    }
}