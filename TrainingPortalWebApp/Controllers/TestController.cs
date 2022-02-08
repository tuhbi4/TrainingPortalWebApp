using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin, editor, user")]
    public class TestController : Controller
    {
        private readonly ISearchableRepositoryService<Course> courseService;
        private readonly IRepositoryService<UserPassedCourse> userPassedCourseService;

        public TestController(ISearchableRepositoryService<Course> courseService, IRepositoryService<UserPassedCourse> userPassedCourseService)
        {
            this.courseService = courseService;
            this.userPassedCourseService = userPassedCourseService;
        }

        // GET: TestController/Start
        public ActionResult Start(int id)
        {
            ViewBag.CourseId = id;
            ViewBag.СhancesLeft = 3;

            return View(courseService.Read(id).Test);
        }

        // POST: TestController/NextQuestion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NextQuestion(int courseId, int questionNumber, int chancesLeft, IFormCollection collection)
        {
            if (User.Identity.IsAuthenticated)
            {
                Test test = courseService.Read(courseId).Test;
                collection.TryGetValue("answers", out var userAnswersStringValues);
                int[] userAnswers = userAnswersStringValues.ToArray().Select(int.Parse).ToArray();
                chancesLeft = CalculateChances(questionNumber, chancesLeft, test, userAnswers);

                if (chancesLeft < 1 || questionNumber > test.QuestionsList.Count)
                {
                    bool isTestPassed = chancesLeft > 0;

                    return RedirectToAction("End", new { courseId = courseId, isTestPassed = isTestPassed });
                }

                ViewBag.CourseId = courseId;
                ViewBag.QuestionNumber = questionNumber;
                ViewBag.СhancesLeft = chancesLeft;
                int rightAnswersNumber = test.QuestionsList[questionNumber - 1].Answers.FindAll(x => x.IsRightAnswer).Count;

                if (rightAnswersNumber > 1)
                {
                    ViewBag.MultipleRightAnswers = "(multiple answer options)";
                }
                else
                {
                    ViewBag.MultipleRightAnswers = string.Empty;
                }

                return View(test.QuestionsList[questionNumber - 1]);
            }

            return RedirectToAction("AccessDenied", "Home");
        }

        // GET: TestController/Create
        public ActionResult End(int courseId, bool isTestPassed)
        {
            if (isTestPassed)
            {
                ViewBag.Message = "You have passed the test successfully!";
                ViewBag.AdditionalMessage = "Congratulations on finishing the course! The certificate is now available for download in your profile";
                UserPassedCourse passedCourse = new() { CourseId = courseId, CourseName = courseService.Read(courseId).Name, UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) };
                userPassedCourseService.Create(passedCourse);
            }
            else
            {
                ViewBag.Message = "You have made the maximum number of mistakes allowed";
                ViewBag.AdditionalMessage = "But you can try again anytime! ";
            }

            return View();
        }

        [NonAction]
        private int CalculateChances(int questionNumber, int chancesLeft, Test test, int[] userAnswers)
        {
            if (questionNumber != 1)
            {
                foreach (var answer in test.QuestionsList[questionNumber - 2].Answers)
                {
                    if ((!answer.IsRightAnswer && userAnswers.Any(x => x == answer.Id))
                        || (answer.IsRightAnswer && !userAnswers.Any(x => x == answer.Id)))
                    {
                        chancesLeft--;

                        break;
                    }
                }
            }

            return chancesLeft;
        }
    }
}