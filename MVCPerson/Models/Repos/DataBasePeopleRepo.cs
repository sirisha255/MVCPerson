using MVCPerson.Data;
using MVCPerson.Models.Repos;
using Microsoft.EntityFrameworkCore;

namespace MVCPerson.Models.Repos
{
    public class DataBasePeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(string person)
        {
            throw new NotImplementedException();
        }

        
        public List<Person> GetAll()
        {
            return _peopleDbContext.Persons.ToList();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Person> GetByCity(string City)
        {
            throw new NotImplementedException();
        }
     
        public bool Update1(Person person)
        {
            throw new NotImplementedException();
        }
        public bool Delete1(Person person)
        {
            throw new NotImplementedException();
        }

    }
}
