using MVCPerson.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Services
{
    public interface IPeopleService 
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> GetAll();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel editPerson);

        void Remove(int id);
    }
}
