using MVCPerson.Models.Repos;
using MVCPerson.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Create(CreateCityViewModel createCountry)
        {
            if (string.IsNullOrWhiteSpace(createCountry.CountryName))
            {
                return null;
            }
            return _countryRepo.Create(new Country(createCountry.CountryName));


        }
        public List<Country> All()
        {
            return _countryRepo.GetAll();

        }
        public List<Country> FindBy(string search)
        {
            List<Country> searchCountry = _countryRepo.GetAll();

            foreach(Country item in _countryRepo.GetAll())
            {
                if(item.CountryName.Contains(search,StringComparison.OrdinalIgnoreCase))
                {
                    searchCountry.Add(item);
                }
            }
            if(searchCountry.Count == 0) 
            {
                throw new ArgumentException("Could not find what you where looking for");

            }
            return searchCountry;
        }  

        public Country FindById(int id)
        {
            Country countryFound = _countryRepo.FindById(id);
            return countryFound;
        }
        public bool Edit(int id, CreateCountryViewModel editCountry)
        {
            Country orginalCountry = FindById(id);
            if (orginalCountry == null)
            {
                return false;
            }
            orginalCountry.CountryName = editCountry.CountryName;
            return _countryRepo.Update(orginalCountry);

        }

        public bool Remove(int id)
        {
          Country countryTodDelete = _countryRepo.FindById(id);
            bool success = _countryRepo.Delete(countryTodDelete);
            return success;

        }
    }
}
