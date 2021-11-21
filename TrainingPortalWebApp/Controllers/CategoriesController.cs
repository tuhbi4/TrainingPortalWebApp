using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Entities;

namespace TrainingPortal.WebPL.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepositoryService<Category> categoryService;

        public CategoriesController(IRepositoryService<Category> categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categoryService.ReadAll());
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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
                    categoryService.Create(new(categoryService.ReadAll().Count + 1, name.ToString()));
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(categoryService.Read(id));
        }

        // POST: CategoryController/Edit/5
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
                    Category targetCategory = categoryService.Read(id);
                    UpdateProperties(collection, targetCategory);
                    categoryService.Update(id, targetCategory);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (BadHttpRequestException exception)
            {
                ViewBag.Exception = exception;
                ViewBag.IFormCollection = collection;

                return View(categoryService.Read(id));
            }
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
            try
            {
                if (categoryService.Read(id) != null)
                {
                    categoryService.Delete(id);
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

        private void UpdateProperties(IFormCollection collection, Category targetCategory)
        {
            collection.TryGetValue("Name", out var name);
            targetCategory.UpdateName(name);
        }
    }
}