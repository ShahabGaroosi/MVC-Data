using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Data.Models;
using MVC_Data.Models.Repo;
using MVC_Data.Models.Service;
using MVC_Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        IPeopleRepo _peopleRepo;
        public class CreatePersonOrPeopleViewModel
        {
            public CreatePersonViewModel CreatePerson { get; set; }
            public PeopleViewModel People { get; set; }
        }

        public PeopleController(IPeopleService peopleService, IPeopleRepo peopleRepo)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View(_peopleService.All());
        //}

        [HttpGet]
        public IActionResult Index()
        {
            CreatePersonOrPeopleViewModel _createPersonOrPeopleViewModel = new CreatePersonOrPeopleViewModel();
            _createPersonOrPeopleViewModel.People = _peopleService.All();
            return View(_createPersonOrPeopleViewModel);
        }

        //[HttpPost]
        //public IActionResult Index(PeopleViewModel peopleViewModel, CreatePersonViewModel createPerson)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _peopleService.Add(createPerson);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(new Tuple<CreatePersonViewModel, PeopleViewModel>(createPerson, _peopleService.FindBy(peopleViewModel)));
        //}

        //[HttpPost]
        //public IActionResult Index(PeopleViewModel peopleViewModel)
        //{
        //    return View(new Tuple<CreatePersonViewModel, PeopleViewModel> (new CreatePersonViewModel(), _peopleService.FindBy(peopleViewModel)));
        //}

        //[HttpPost]
        //public IActionResult Index(CreatePersonViewModel createPerson)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _peopleService.Add(createPerson);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(new Tuple<CreatePersonViewModel, PeopleViewModel>(createPerson, new PeopleViewModel()));
        //}
        [HttpPost]
        public IActionResult Index(CreatePersonOrPeopleViewModel createPersonOrPeopleViewModel)
        {
            createPersonOrPeopleViewModel.People = _peopleService.FindBy(createPersonOrPeopleViewModel.People);
            return View(createPersonOrPeopleViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonOrPeopleViewModel createPersonOrPeopleViewModel)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPersonOrPeopleViewModel.CreatePerson);

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult Index(CreatePersonOrPeopleViewModel createPersonOrPeopleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (createPersonOrPeopleViewModel.createPersonViewModel!=null)
        //        {
        //            _peopleService.Add(createPersonOrPeopleViewModel.createPersonViewModel);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        if (createPersonOrPeopleViewModel.peopleViewModel != null)
        //        {
        //            return View(_peopleService.FindBy(createPersonOrPeopleViewModel.peopleViewModel));
        //        }
        //    }
        //    return View();
        //}
    }
}
