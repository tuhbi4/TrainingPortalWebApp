using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Entities;

namespace TrainingPortal.WebPL.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepositoryService<Course> courseService;

        public CoursesController(IRepositoryService<Course> courseService)
        {
            this.courseService = courseService;
        }

        // GET: CoursesController
        public ActionResult Index()
        {
            return View(courseService.ReadAll());
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (IsContainEmptyValues(collection))
                {
                    throw new BadHttpRequestException("Field cannot be empty");
                }
                else
                {
                    collection.TryGetValue("Name", out var name);
                    collection.TryGetValue("Description", out var description);
                    courseService.Create(new(courseService.ReadAll().Count + 1, name.ToString(), description.ToString()));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (BadHttpRequestException exception)
            {
                ViewBag.Exception = exception;
                ViewBag.IFormCollection = collection;

                return View();
            }
        }

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(courseService.Read(id));
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (IsContainEmptyValues(collection))
                {
                    throw new BadHttpRequestException("Field cannot be empty");
                }
                else
                {
                    Course targetCourse = courseService.Read(id);
                    UpdateProperties(collection, targetCourse);
                    courseService.Update(id, targetCourse);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (BadHttpRequestException exception)
            {
                ViewBag.Exception = exception;
                ViewBag.IFormCollection = collection;

                return View(courseService.Read(id));
            }
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
            try
            {
                if (courseService.Read(id) != null)
                {
                    courseService.Delete(id);
                    return RedirectToAction(nameof(Index));
                }

                throw new BadHttpRequestException("Object not found");
            }
            catch (BadHttpRequestException exception)
            {
                ViewData["Exception"] = exception;
                ViewBag.Exception = exception;
                return View();
            }
        }

        private bool IsContainEmptyValues(IFormCollection collection)
        {
            foreach (var item in collection)
            {
                if (item.Value == string.Empty)
                {
                    return true;
                }
            }

            return false;
        }

        private void UpdateProperties(IFormCollection collection, Course targetCourse)
        {
            collection.TryGetValue("Name", out var name);
            targetCourse.UpdateName(name);
            collection.TryGetValue("Description", out var description);
            targetCourse.UpdateDescription(description);
        }
    }
}