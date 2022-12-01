﻿using Microsoft.AspNetCore.Mvc;
using MVCPerson.Models.Services;
using MVCPerson.Models.ViewModels;
using MVCPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_countryService.All());

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(createCountry);                       
                return RedirectToAction(nameof(Index));
            }
            return View(createCountry);
        }

        public IActionResult Details(int Id)
        {
            Country country = _countryService.FindById(Id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Country country = _countryService.FindById(Id);
            if (country == null)
            {

                return RedirectToAction(nameof(Index));
            }
            CreateCountryViewModel createCountry = new CreateCountryViewModel();
            createCountry.CountryName = country.CountryName;
            ViewBag.Id = country.Id;
            return View(createCountry);

        }
        [HttpPost]
        public IActionResult Edit(int id, CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                if (_countryService.Edit(id, createCountry))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Id = id;
            return View(createCountry);

        }
        public IActionResult Delete(int id)
        {
            _countryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
