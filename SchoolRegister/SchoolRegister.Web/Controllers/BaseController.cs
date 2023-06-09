﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Web.Controllers;
[Authorize(Roles = "Teacher, Admin, Student")]
public class SubjectController : BaseController
{
    private readonly ISubjectService _subjectService;
    private readonly UserManager<User> _userManager;
    public SubjectController(ISubjectService subjectService,
    UserManager<User> userManager,
    IStringLocalizer localizer,
    ILogger logger,
    IMapper mapper) : base(logger, mapper, localizer)
    {
        _subjectService = subjectService;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        if (_userManager.IsInRoleAsync(user, "Admin").Result)
            return View(_subjectService.GetSubjects());
        else if (_userManager.IsInRoleAsync(user, "Teacher").Result && user is Teacher teacher)
        {
            return View(_subjectService.GetSubjects(x => x.TeacherId == teacher.Id));
        }
        else if (_userManager.IsInRoleAsync(user, "Student").Result)
            return RedirectToAction("Details", "Student", new { studentId = user.Id });
        else
            return View("Error");
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AddOrEditSubject(int? id = null)
    {
        //blanked out
        ViewBag.ActionType = "Add";
        return View();
    }
    public IActionResult Details(int id)
    {
        var subjectVm = _subjectService.GetSubject(x => x.Id == id);
        return View(subjectVm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public IActionResult AddOrEditSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm)
    {
        if (ModelState.IsValid)
        {
            _subjectService.AddOrUpdateSubject(addOrUpdateSubjectVm);
            return RedirectToAction("Index");
        }
        return View();
    }
}
