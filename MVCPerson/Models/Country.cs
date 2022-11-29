using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<City> Cities { get; set; }
        public Country(string countryName)
        {
            CountryName = countryName;
        }
        public Country()
        { }
    }
}
