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
        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }
        public List<Person> GetByCity(string City)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)
        {
            throw new NotImplementedException();
        }
        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
