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
            return View(new Tuple<CreatePersonViewModel, PeopleViewModel>(new CreatePersonViewModel(), _peopleService.All()));
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel, CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }
            return View(new Tuple<CreatePersonViewModel, PeopleViewModel>(createPerson, _peopleService.FindBy(peopleViewModel)));
        }

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
    }
}
