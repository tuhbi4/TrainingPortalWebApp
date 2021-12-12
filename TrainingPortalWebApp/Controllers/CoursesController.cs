using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebPL.Models;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin,  editor")]
    public class CoursesController : Controller
    {
        private readonly IRepositoryService<Course> courseService;

        public CoursesController(IRepositoryService<Course> courseService)
        {
            this.courseService = courseService;
        }

        // GET: CoursesController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(courseService.ReadAll());
        }

        // GET: CoursesController/Details/5
        [Authorize(Roles = "admin,  editor, user")]
        public ActionResult Details(int id)
        {
            return View(courseService.Read(id));
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            CourseViewModel workingItem = new();

            return View(workingItem);
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel workingItem)
        {
            if (ModelState.IsValid
                //&& courseService.Create(new(courseService.ReadAll().Count + 1, workingItem.Name, )) > 0
                )
            {
                return RedirectToAction(nameof(Index));
            }

            return View(workingItem);
        }

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = courseService.Read(id);
            CourseViewModel workingItem = new() { Name = course.Name, Description = course.Description };

            return View(workingItem);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel workingItem)
        {
            return RedirectToAction("NotImplemented", "Home");
        }

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseService.Read(id));
        }

        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (courseService.Read(id) != null)
            {
                if (courseService.Delete(id) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Exception"] = "Category could not be deleted due to a reference to another item in the database";

                return View(courseService.Read(id));
            }

            ViewData["Exception"] = "Object not found";

            return View(courseService.Read(id));
        }
    }
}