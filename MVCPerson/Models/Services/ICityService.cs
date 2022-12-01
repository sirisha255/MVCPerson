using MVCPerson.Models.ViewModels;

namespace MVCPerson.Models.Services
{
    public interface ICityService
    {

        City Create(CreateCityViewModel createCityViewModel);
        List<City> GetAll();
        List<City> FindBy(string search);
        City FindById(int id);
        bool Edit(int id, CreateCityViewModel cityViewModel);
        bool Remove(int id);
    }
}
