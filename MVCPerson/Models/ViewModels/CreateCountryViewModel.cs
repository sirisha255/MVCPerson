using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.ViewModels
{
    public class CreateCountryViewModel
    {

        [Required(ErrorMessage = "Enter a Country,it is required")]
        [StringLength(80,MinimumLength =1)]
        [Display(Name ="Country")]
        public string CountryName { get; set; }
    public List<City> CityList { get; set; }
    public CreateCountryViewModel()
        {
            CityList = new List<City>();
        }
    }
}
