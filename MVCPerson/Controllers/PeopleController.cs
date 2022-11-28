using Microsoft.AspNetCore.Mvc;
using MVCPerson.Models;
using MVCPerson.Models.Repos;
using MVCPerson.Models.Services;
using MVCPerson.Models.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;


namespace MVCPerson.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
          _peopleService = peopleService;
        }
        public IActionResult People()
        {
            return View(_peopleService.All());
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        { 
            return View(new CreatePersonViewModel());   
        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Create(createPerson);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name,PhoneNumber & City", exception.Message);
                    return View(createPerson);
                }

                return RedirectToAction(nameof(People));
            }
            return View(createPerson);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }

            return View(person);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityName = person.CityName
            };

            return View(editPerson);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(People));
            }

            _peopleService.Create(editPerson);
            return View(editPerson);
        }
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
            }
            else
            {
                _peopleService.Remove(id);

            }

            return View();

        }
        [HttpPost]
        public IActionResult People(string search)
        {
            if (search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(People));
        }

        //****************Ajax********************//
        public IActionResult PartialViewPeople()
        {
            return PartialView("_PeopleList", _peopleService.GetAll());
        }
        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_PersonDetails", person);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                _peopleService.Remove(id);
                return PartialView("_PeopleList", _peopleService.GetAll());
            }
            return NotFound();
        }
    }
}

