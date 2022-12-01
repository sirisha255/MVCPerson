using MVCPerson.Models.ViewModels;
using MVCPerson.Models.Repos;

namespace MVCPerson.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Create(CreateCityViewModel createCity)
        {
            if(string.IsNullOrWhiteSpace(createCity.CityName)) 
            {
                return null;
            }
            City city = new City()
            {
                CityName = createCity.CityName,
                CountryId = createCity.CountryId
            };
            return _cityRepo.Create(city);
        }
        public List<City> GetAll()
        {
          return _cityRepo.GetAll();
        }
        public List<City> FindBy(string search)
        {
            List<City> searchCity = _cityRepo.GetAll();
            foreach(City item in _cityRepo.GetAll())
            {
                if(item.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchCity.Add(item);
                }
            }
            if(searchCity.Count == 0) 
            {
                throw new ArgumentException("Could not find what you are looking for");
            }
            return searchCity;

        }
         
        public City FindById(int Id)
        {
            City cityFound = _cityRepo.FindBy(Id);
            return cityFound;

        }
        public bool Edit(int Id, CreateCityViewModel editCity)
        {
            City originalCountry = FindById(Id); 
            if(originalCountry == null) 
            {
                return false;
            }
            originalCountry.CityName = editCity.CityName;
            return _cityRepo.Update(originalCountry);
        }



        public bool Remove(int id)
        {
            City cityToDelete = _cityRepo.FindBy(id);
            bool success = _cityRepo.Delete(cityToDelete);
            return success;


        }
    }
}
