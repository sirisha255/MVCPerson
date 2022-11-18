using MVCPerson.Models;
using MVCPerson.Models.ViewModels;
using MVCPerson.Models.Repos;

namespace MVCPerson.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
            Person person = _peopleRepo.Create(createPerson.Name, createPerson.PhoneNumber, createPerson.CityName);
            if (string.IsNullOrWhiteSpace(createPerson.Name)
                            || string.IsNullOrWhiteSpace(createPerson.PhoneNumber)
                            || string.IsNullOrWhiteSpace(createPerson.CityName))
            {
                throw new ArgumentException("Name,PhoneNumber or City, not be consist of backspace(s)/whitespace(s)");
            }

            return person;
        }
    

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }
        public Person FindById(int id)
        {
            Person foundperson = _peopleRepo.Read(id);
            return foundperson;

        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            Person orginalPerson = FindById(id);
            if(orginalPerson != null)
            {
                orginalPerson.Name = editPerson.Name;
                orginalPerson.PhoneNumber = editPerson.PhoneNumber;
                orginalPerson.CityName = editPerson.CityName;
            }
            return _peopleRepo.Update(orginalPerson);

        }

        public bool Remove(int id)
        {
            Person personToDelete = _peopleRepo.Read(id);
            bool success = _peopleRepo.Delete(personToDelete);

            return success;

        }
        public List<Person> Search(string search)
        {
            List<Person> searchPerson = _peopleRepo.Read();
            {
                foreach (Person item in _peopleRepo.Read())
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
