using Microsoft.AspNetCore.Mvc;
using MVCPerson.Models;
using MVCPerson.Models.Repos;
using MVCPerson.Models.Services;
using MVCPerson.Models.ViewModels;
using System.Diagnostics;


namespace MVCPerson.Controllers
{
    public class PeopleController : Controller
    {
        readonly IPeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
          _peopleService = peopleService;
        }
        public IActionResult People()
        {
            return View(_peopleService.All());
        }
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
                    _peopleService.Add(createPerson);
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

            _peopleService.Add(editPerson);
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
            return PartialView("_PeopleList", _peopleService.All());
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
            if (_peopleService.Remove(id))
            {
                return PartialView("_PeopleList", _peopleService.All());
            }
            return NotFound();
        }
    }
}

