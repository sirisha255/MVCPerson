using MVCPerson.Data;
using MVCPerson.Models.Repos;
using Microsoft.EntityFrameworkCore;
using MVCPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
           _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }
        public List<Person> GetAll()
        {
            return _peopleDbContext.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _peopleDbContext.Persons.SingleOrDefault(person => person.PersonId == id);
        }
        public List<Person> GetByCity(string city)
        {
            return _peopleDbContext.Persons.Where(person => person.CityName.Contains(city)).ToList();
        }
        public bool Update(Person person)
        {
            _peopleDbContext.Persons.Update(person);
           int result = _peopleDbContext.SaveChanges();
            if(result==0)
            {
                return false;
            }
            return true;
        }
        public void Delete(Person person)
        {
            _peopleDbContext.Remove(person);
            _peopleDbContext.SaveChanges();
        }
    }
}
