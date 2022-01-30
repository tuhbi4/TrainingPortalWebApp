﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.WebPL.Models.Course;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize(Roles = "admin,  editor")]
    public class CoursesController : Controller
    {
        private readonly IRepositoryService<Course> courseService;
        private readonly IRepositoryService<Category> categoryService;
        private readonly IRepositoryService<TargetAudience> targetAudienceService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CoursesController(IRepositoryService<Course> courseService, IRepositoryService<Category> categoryService, IRepositoryService<TargetAudience> targetAudienceService,
            IMapper mapper, ILogger logger)
        {
            this.courseService = courseService;
            this.categoryService = categoryService;
            this.targetAudienceService = targetAudienceService;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: Courses
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(courseService.ReadAll());
        }

        // GET: Courses/Details/5
        [Authorize(Roles = "admin,  editor, user")]
        public ActionResult Details(int id)
        {
            return View(courseService.Read(id));
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.AvailableCategories = new SelectList(categoryService.ReadAll(), nameof(Category.Id), nameof(Category.Name));
            ViewBag.AvailableTargetAudiencies = targetAudienceService.ReadAll();
            ViewBag.IsEmptyModel = true;

            return View(new CourseViewModel());
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel, IFormCollection collection)
        {
            if (User.Identity.IsAuthenticated)
            {
                Course courseModel = mapper.Map<Course>(viewModel);

                if (ModelState.IsValid)
                {
                    SetCategory(courseModel, collection);
                    SetLessonsList(courseModel, collection);
                    SetTest(courseModel, collection);
                    ValidateCertificateImageLink(courseModel);
                    SetTargetAudienciesList(courseModel, collection);
                    int createdCourseId = courseService.Create(courseModel);

                    if (createdCourseId > 0)
                    {
                        logger.Debug($"Course was created successful: id = \"{createdCourseId}\", name = \"{courseModel.Name}\", initiator = \"{User.Identity.Name}\"");
                    }
                    else
                    {
                        logger.Error($"Course was not created in the database: name = \"{courseModel.Name}\", initiator = \"{User.Identity.Name}\"");
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.AvailableCategories = new SelectList(categoryService.ReadAll(), nameof(Category.Id), nameof(Category.Name));
                ViewBag.AvailableTargetAudiencies = targetAudienceService.ReadAll();
                ViewBag.IsEmptyModel = true;

                return View(mapper.Map<CourseViewModel>(courseModel));
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            logger.Information($"Course editing was requested: id = \"{id}\", initiator = \"{User.Identity.Name}\"");
            Course targetCourse = courseService.Read(id);
            CourseViewModel model = mapper.Map<CourseViewModel>(targetCourse);
            ViewBag.AvailableCategories = new SelectList(categoryService.ReadAll(), nameof(Category.Id), nameof(Category.Name), targetCourse.Category.Id);
            ViewBag.AvailableTargetAudiencies = targetAudienceService.ReadAll();
            ViewBag.IsEmptyModel = false;

            return View(model);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseViewModel viewModel, IFormCollection collection)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    Course courseModel = mapper.Map<Course>(viewModel);
                    Course targetCourse = courseService.Read(id);
                    courseModel.Id = id;
                    SetCategory(courseModel, collection);
                    SetLessonsList(courseModel, collection);
                    SetTest(courseModel, collection);
                    courseModel.Test.Id = targetCourse.Test.Id;
                    ValidateCertificateImageLink(courseModel);
                    courseModel.Certificate.Id = targetCourse.Certificate.Id;

                    if (courseModel.Certificate.ImageLink == string.Empty)
                    {
                        courseModel.Certificate.ImageLink = targetCourse.Certificate.ImageLink;
                    }

                    SetTargetAudienciesList(courseModel, collection);

                    if (courseService.Update(id, courseModel) > 0)
                    {
                        logger.Debug($"Course was updated successful: id = \"{id}\", initiator = \"{User.Identity.Name}\"");
                    }
                    else
                    {
                        logger.Error($"Course was not updated in the database: id = \"{id}\", initiator = \"{User.Identity.Name}\"");
                    }
                }

                return RedirectToAction("Edit");
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseService.Read(id));
        }

        // POST: Courses/Delete/5
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

                ViewBag.Exception = "Course could not be deleted due to a reference to another item in the database";

                return View(courseService.Read(id));
            }

            ViewBag.Exception = "Object not found";

            return View(courseService.Read(id));
        }

        [NonAction]
        private void SetCategory(Course course, IFormCollection collection)
        {
            course.Category = categoryService.Read(int.Parse(Request.Form[nameof(Category)].ToString()));
        }

        private void SetLessonsList(Course course, IFormCollection collection)
        {
            collection.TryGetValue("Lesson", out var lessonsStringValues);
            List<string> lessonsNames = lessonsStringValues.ToArray().ToList();
            List<Lesson> lessonsList = new();

            for (int i = 1; i <= lessonsNames.Count; i++)
            {
                collection.TryGetValue("lessonsTextareaName" + i, out var materialStringValue);

                if (lessonsNames[i - 1] != string.Empty || materialStringValue.ToString() != string.Empty)
                {
                    lessonsList.Add(new Lesson() { Id = lessonsList.Count + 1, Name = lessonsNames[i - 1], Material = materialStringValue.ToString() });
                }
            }

            course.LessonsList = lessonsList;
        }

        private void SetTest(Course course, IFormCollection collection)
        {
            List<TestQuestion> testQuestions = new();
            collection.TryGetValue("QuestionNames", out var questionNamesStringValues);

            for (int i = 1; i <= questionNamesStringValues.Count; i++)
            {
                collection.TryGetValue("AnswersForQuestion" + i, out var answersStringValues);
                collection.TryGetValue("RightAnswersForQuestion" + i, out var rightAnswersStringValues);

                if (questionNamesStringValues[i - 1].ToString() != string.Empty)
                {
                    List<Answer> answerList = new();

                    for (int j = 1; j <= answersStringValues.Count; j++)
                    {
                        if (answersStringValues[j - 1].ToString() != string.Empty)
                        {
                            answerList.Add(new Answer()
                            {
                                Id = j,
                                Text = answersStringValues[j - 1].ToString(),
                                IsRightAnswer = rightAnswersStringValues.ToArray().Select(int.Parse).Any(x => x == j)
                            });
                        }
                    }

                    if (answerList.Count > 0)
                    {
                        testQuestions.Add(new TestQuestion()
                        {
                            Id = testQuestions.Count + 1,
                            Question = questionNamesStringValues[i - 1].ToString(),
                            Answers = answerList
                        });
                    }
                }
            }

            collection.TryGetValue("Test.Name", out var testNameStringValue);
            course.Test.Name = testNameStringValue.ToString();
            course.Test.QuestionsList = testQuestions;
        }

        private void ValidateCertificateImageLink(Course courseModel)
        {
            courseModel.Certificate.CourseName = courseModel.Name;
            string[] imageFormats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            if ((courseModel.Certificate.ImageLink is null)
                || !(courseModel.Certificate.ImageLink.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                && imageFormats.Any(item => courseModel.Certificate.ImageLink.EndsWith(item, StringComparison.OrdinalIgnoreCase))))
            {
                courseModel.Certificate.ImageLink = string.Empty;
            }
        }

        private void SetTargetAudienciesList(Course course, IFormCollection collection)
        {
            collection.TryGetValue("targetAudienciesCheckboxList", out var audienciesStringValues);
            List<int> audienciesIds = audienciesStringValues.ToArray().Select(int.Parse).ToList();
            List<TargetAudience> availableTargetAudiencies = targetAudienceService.ReadAll();
            course.TargetAudienciesList = new List<TargetAudience>();

            foreach (var audiency in audienciesIds)
            {
                course.TargetAudienciesList.Add(availableTargetAudiencies.FirstOrDefault(x => x.Id == audiency));
            }
        }
    }
}