

namespace MVCPerson.Models.ViewModels
{
    public class CityViewModel
    {
        public List<City> Cities { get; set; }


        public CityViewModel() { Cities = new List<City>(); }
    }
}
