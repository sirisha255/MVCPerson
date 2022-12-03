using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVCPerson.Models.ViewModels;
using MVCPerson.Models.Repos;

namespace MVCPerson.Models.Services
{
    public class PeopleService : IPeopleService
    {
        readonly IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Create(CreatePersonViewModel createPerson)
        {

            if (string.IsNullOrWhiteSpace(createPerson.Name)
                            || string.IsNullOrWhiteSpace(createPerson.PhoneNumber)
                            || string.IsNullOrWhiteSpace(createPerson.CityName))
            {
                throw new ArgumentException("Name,PhoneNumber or City, not be consist of backspace(s)/whitespace(s)");

            }
            Person person = new Person()
            {
                Name = createPerson.Name,
                PhoneNumber = createPerson.PhoneNumber,
                CityName = createPerson.CityName,

            };
           _peopleRepo.Create(person);
            return person;
        }

        public List<Person> GetAll()
        {
            return _peopleRepo.GetAll();
        }
        public Person FindById(int id)
        {
            Person foundperson = _peopleRepo.GetById(id);
            return foundperson;

        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person orginalPerson = _peopleRepo.GetById(id);
            if(orginalPerson != null)
            {
                orginalPerson.Name = editPerson.Name;
                orginalPerson.PhoneNumber = editPerson.PhoneNumber;
                orginalPerson.CityName = editPerson.CityName;
            }
            return _peopleRepo.Update(orginalPerson);
        }

        public void  Remove(int id)
        {
            Person personToDelete = _peopleRepo.GetById(id);
            if(personToDelete != null)
            {
              _peopleRepo.Delete(personToDelete);
            }

        }
        public List<Person> Search(string search)
        {
            List<Person> searchPerson = _peopleRepo.GetAll();
            {
                foreach (Person item in _peopleRepo.GetAll())
                {
                    if (item.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                      || item.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
                    {
                        searchPerson = searchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper()) || p.CityName.Contains(search.ToUpper())).ToList();
                        searchPerson.Add(item);
                    }
                }
                if (searchPerson.Count == 0)
                {
                    throw new ArgumentException("Could not find what you where looking for");
                }
                return searchPerson;
            }
        }
    }
}
