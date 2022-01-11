using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.WebPL.Models;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin,  editor")]
    public class CategoriesController : Controller
    {
        private readonly IRepositoryService<Category> categoryService;

        public CategoriesController(IRepositoryService<Category> categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: CategoryController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(categoryService.ReadAll());
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            CategoryViewModel workingItem = new();

            return View(workingItem);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel workingItem)
        {
            if (ModelState.IsValid
                && categoryService.Create(new Category { Id = categoryService.ReadAll().Count + 1, Name = workingItem.Name }) > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(workingItem);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryViewModel workingItem = new() { Name = categoryService.Read(id).Name };

            return View(workingItem);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel workingItem)
        {
            if (!ModelState.IsValid)
            {
                return View(workingItem);
            }

            Category targetItem = categoryService.Read(id);
            targetItem.Name = workingItem.Name;
            categoryService.Update(id, targetItem);

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(categoryService.Read(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (categoryService.Read(id) != null)
            {
                if (categoryService.Delete(id) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Exception"] = "Category could not be deleted due to a reference to another item in the database";

                return View(categoryService.Read(id));
            }

            ViewData["Exception"] = "Object not found";

            return View(categoryService.Read(id));
        }
    }
}