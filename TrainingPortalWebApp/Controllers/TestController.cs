using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models.CourseItems;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin,  editor, user")]
    public class TestController : Controller
    {
        private readonly IRepositoryService<Test> testService;
        private readonly IMapper mapper;

        public TestController(IRepositoryService<Test> testService, IMapper mapper)
        {
            this.testService = testService;
            this.mapper = mapper;
        }

        // GET: TestController/Start
        public ActionResult Start(int id)
        {
            ViewBag.СhancesLeft = 3;

            return View(testService.Read(id));
        }

        // POST: TestController/NextQuestion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NextQuestion(int testId, int questionNumber, int chancesLeft, IFormCollection collection)
        {
            if (User.Identity.IsAuthenticated)
            {
                Test test = testService.Read(testId);
                collection.TryGetValue("answers", out var userAnswersStringValues);
                int[] userAnswers = userAnswersStringValues.ToArray().Select(int.Parse).ToArray();
                chancesLeft = CalculateMistakes(questionNumber, chancesLeft, test, userAnswers);

                if (chancesLeft < 1 || questionNumber > test.QuestionsList.Count)
                {
                    bool isTestPassed = chancesLeft > 0;

                    return RedirectToAction("End", new { isTestPassed = isTestPassed });
                }

                ViewBag.TestId = testId;
                ViewBag.QuestionNumber = questionNumber;
                ViewBag.СhancesLeft = chancesLeft;

                if (test.QuestionsList[questionNumber - 1].Answers.FindAll(x => x.IsRightAnswer).Count > 1)
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
        public ActionResult End(bool isTestPassed)
        {
            if (isTestPassed)
            {
                ViewBag.Message = "You have passed the test successfully!";
                ViewBag.AdditionalMessage = "Congratulations on finishing the course! The certificate is now available for download in your profile";
            }
            else
            {
                ViewBag.Message = "You have made the maximum number of mistakes allowed";
                ViewBag.AdditionalMessage = "But you can try again anytime! ";
            }

            return View();
        }

        [NonAction]
        private int CalculateMistakes(int questionNumber, int chancesLeft, Test test, int[] userAnswers)
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