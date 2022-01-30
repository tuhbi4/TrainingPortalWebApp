﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.WebPL.Models.User;

namespace TrainingPortal.WebPL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IRepositoryService<User> userService;
        private readonly IRepositoryService<Role> roleService;
        private readonly IHashService md5Hash;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AccountController(IRepositoryService<User> userService, IRepositoryService<Role> roleService,
            IHashService md5Hash, IMapper mapper, ILogger logger)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.md5Hash = md5Hash;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: Account/Index
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            logger.Information($"User list was requested: initiator = \"{User.Identity.Name}\"");

            return View(userService.ReadAll().Select(x => mapper.Map<EditUserViewModel>(x)));
        }

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginUserViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    User user = userService.ReadAll().FirstOrDefault(x => x.Login == model.Login);

                    if (user is null)
                    {
                        ModelState.AddModelError(nameof(model.Login), "Login not found");
                        logger.Warning($"Authorization failed: login \"{model.Login}\" not found");

                        return View(model);
                    }
                    else if (md5Hash.GetHash(model.Password) != user.Password)
                    {
                        ModelState.AddModelError(nameof(model.Password), "Invalid password");
                        logger.Warning($"Authorization failed: invalid password");

                        return View(model);
                    }

                    var absoluteExpiration = Request.Form["RememberMeCheck"];
                    await Authenticate(user, absoluteExpiration);
                    logger.Debug($"Authorization was successful: user id = \"{user.Id}\"");
                }
                else
                {
                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Logout

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            logger.Debug($"User \"{User.Identity.Name}\" was signed out");

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUserViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    List<User> userList = userService.ReadAll();

                    if (userList.Any(x => x.Login == model.Login))
                    {
                        ModelState.AddModelError(nameof(model.Login), "This login is already taken");
                        logger.Warning($"An attempt to sign up with an existing login: \"{model.Login}\"");

                        return View(model);
                    }

                    if (userList.Any(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError(nameof(model.Email), "This email is already taken");
                        logger.Warning($"An attempt to sign up with an existing email: \"{model.Email}\"");

                        return View(model);
                    }

                    User user = mapper.Map<User>(model);
                    user.Password = md5Hash.GetHash(model.Password);
                    user.Role = new Role { Id = 1, Name = "user" };

                    if (userService.Create(user) > 0)
                    {
                        var absoluteExpiration = Request.Form["RememberMeCheck"];
                        await Authenticate(user, absoluteExpiration);
                        logger.Debug($"Registration was successful: new user id: \"{user.Id}\"");

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        logger.Error($"User was not created in the database: id = \"{user.Id}\", login = \"{user.Login}\", email = \"{user.Email}\"");
                    }
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterUserViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    List<User> userList = userService.ReadAll();

                    if (userList.Any(x => x.Login == model.Login))
                    {
                        ModelState.AddModelError(nameof(model.Login), "This login is already taken");
                        logger.Warning($"An attempt to create user with an existing login: \"{model.Login}\", initiator = \"{User.Identity.Name}\"");

                        return View(model);
                    }

                    if (userList.Any(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError(nameof(model.Email), "This email is already taken");
                        logger.Warning($"An attempt to create user with an existing email: \"{model.Email}\", initiator = \"{User.Identity.Name}\"");

                        return View(model);
                    }

                    User user = mapper.Map<User>(model);
                    user.Password = md5Hash.GetHash(model.Password);
                    user.Role = new Role { Id = 1, Name = "user" };

                    if (userService.Create(user) > 0)
                    {
                        logger.Debug($"User was created successful: new user id = \"{user.Id}\"");

                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        logger.Error($"User was not created in the database: id = \"{user.Id}\", login = \"{user.Login}\", email = \"{user.Email}\", initiator = \"{User.Identity.Name}\"");
                    }
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Profile
        public ActionResult Profile()
        {
            // UNDONE: Get course progress, download certificate, etc. - add implementation
            return RedirectToAction("NotImplemented", "Home");
        }

        // GET: Account/Settings
        public ActionResult Settings()
        {
            User user = userService.ReadAll().FirstOrDefault(x => x.Email == User.FindFirst(ClaimTypes.Email)?.Value);
            SettingsUserViewModel model = mapper.Map<SettingsUserViewModel>(user);
            logger.Information($"User settings was requested: user id = \"{user.Id}\"");

            return View(model);
        }

        // POST: Account/Settings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Settings(SettingsUserViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    List<User> userList = userService.ReadAll();

                    if (model.Login != User.FindFirst(ClaimTypes.Name)?.Value && userList.Any(x => x.Login == model.Login))
                    {
                        ModelState.AddModelError(nameof(model.Login), "This login is already taken");
                        logger.Warning($"An attempt to update user login with an existing: \"{model.Login}\"");

                        return View(model);
                    }

                    if (model.Email != User.FindFirst(ClaimTypes.Email)?.Value && userList.Any(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError(nameof(model.Email), "This email is already taken");
                        logger.Warning($"An attempt to update user email with an existing: \"{model.Email}\"");

                        return View(model);
                    }

                    User targetUser = userService.ReadAll().FirstOrDefault(x => x.Email == User.FindFirst(ClaimTypes.Email)?.Value);
                    User updatedUser = mapper.Map<User>(model);

                    if (updatedUser.Password is null)
                    {
                        updatedUser.Password = targetUser.Password;
                    }
                    else
                    {
                        updatedUser.Password = md5Hash.GetHash(targetUser.Password);
                    }

                    updatedUser.Role = targetUser.Role;

                    if (userService.Update(targetUser.Id, updatedUser) > 0)
                    {
                        var absoluteExpiration = new StringValues();
                        await Authenticate(updatedUser, absoluteExpiration);
                        logger.Debug($"User was updated successful: user id = \"{targetUser.Id}\"");

                        return View(model);
                    }
                    else
                    {
                        logger.Error($"User was not updated in the database: id = \"{targetUser.Id}\"");
                    }
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = roleService.ReadAll();
            logger.Information($"User editing was requested: Initiator = \"{User.Identity.Name}\"");

            return View(userService.ReadAll()
                .Select(x => mapper.Map<EditUserViewModel>(x))
                    .FirstOrDefault(x => x.Id == id));
        }

        // POST: Account/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    User targetUser = userService.Read(model.Id);
                    User updatedUser = mapper.Map<User>(model);
                    updatedUser.Password = targetUser.Password;
                    updatedUser.Role = roleService.Read(model.RoleId);

                    if (userService.Update(targetUser.Id, updatedUser) > 0)
                    {
                        logger.Debug($"User was updated successful: user id = \"{targetUser.Id}\", initiator = \"{User.Identity.Name}\"");
                        ViewBag.Roles = roleService.ReadAll();
                    }
                    else
                    {
                        logger.Error($"User was not updated in the database: id = \"{targetUser.Id}\", initiator = \"{User.Identity.Name}\"");
                    }
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            logger.Information($"User deleting was requested: initiator = \"{User.Identity.Name}\"");
            return View(userService.Read(id));
        }

        // POST: Account/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RegisterUserViewModel model)
        {
            if (User.Identity.IsAuthenticated && userService.Read(id) != null && userService.Delete(id) > 0)
            {
                logger.Debug($"User was deleted: id = \"{id}\", initiator = \"{User.Identity.Name}\"");
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        private async Task Authenticate(User user, StringValues absoluteExpiration)
        {
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.Name)
                    };

            if (user.Firstname != null)
            {
                claims.Add(new Claim(ClaimTypes.GivenName, user.Firstname));
            }

            if (user.Lastname != null)
            {
                claims.Add(new Claim(ClaimTypes.Surname, user.Lastname));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProoerties = new AuthenticationProperties();

            if (absoluteExpiration.Any())
            {
                authProoerties.IsPersistent = true;
                authProoerties.ExpiresUtc = DateTime.UtcNow.AddYears(20);
                logger.Information($"Cookie with absolute expiration requested: user id = \"{user.Id}\"");
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProoerties);
            logger.Information($"Authentication was successful: user id = \"{user.Id}\"");
        }
    }
}