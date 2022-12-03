using MVCPerson.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Services
{
    public interface ICountryService
    {
        Country Create(CreateCityViewModel createCountry);
        List<Country> All();

        List<Country> FindBy(string search);

        Country FindById(int id);
        bool Edit(int id, CreateCountryViewModel editCountry);
        bool Remove(int id);
        void Create(CreateCountryViewModel createCountry);
    }
}
