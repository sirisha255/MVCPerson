using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MVCPerson.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name="PhoneNumber")]
        [Required]
        public string? PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required]
        public string? CityName { get; set; }
        
        public List<string> CityList
        {
            get
            {
                return new List<string>
                { "Malmo","Hesinborg","Amhult","Lund","vaxjo","gothenborg"};

            }

        }
    }
}
