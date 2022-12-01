using MVCPerson.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Repos
{
    public class DataBaseCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }

        public List<Country> GetAll()
        {
            List<Country> countrylist = _peopleDbContext.Countries.ToList();
            return countrylist;
        }

        public Country FindById(int id)
        {
           return _peopleDbContext.Countries.Find(id);
        }
       
        public bool Update(Country country)
        {
            _peopleDbContext.Countries.Update(country);
            int countryUp = _peopleDbContext.SaveChanges();
            if(countryUp> 0)
            {
                return true;
            }
            return false;

        }

        public bool Delete(Country country)
        {
            _peopleDbContext.Countries.Remove(country);
            int countryDel = _peopleDbContext.SaveChanges();
            if(countryDel> 0)
            {
                return true;
            }
            return false;

        }

    }
}
