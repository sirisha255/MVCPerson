using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPerson.Models.ViewModels;

namespace MVCPerson.Models.Repos
{
    public interface IPeopleRepo
    {

        //C Create
        Person Create(Person person);

        //R Read the People List
        public List<Person> GetAll();
        public Person GetById(int id);
        //U Update the People List
        public bool Update(Person person);

        //D Delete a Person from the List
        public void Delete(Person person);
       List<Person> GetByCity(string City);
    }
}
