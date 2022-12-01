using MessagePack;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPerson.Models
{
    public class City
    {
        //[Key]
        public int Id { get; set; }
        public City() { }
        public City(String cityName)
        {
            CityName = cityName;
        }
        public String CityName { get; set; }
        public List<Person> People { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
      // public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
