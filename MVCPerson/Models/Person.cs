using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPerson.Models
{
    public class Person
    {
        [Key]

        public int PersonId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CityName { get; set; }
        public Person(string name, string phonenumber, string cityname)
        {
            Name = name;
            PhoneNumber = phonenumber;
            CityName = cityname;
        }
        public Person() { }

    }
}
