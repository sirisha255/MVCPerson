using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVCPerson.Data;

namespace MVCPerson.Models.Repos
{
    public class DataBaseCityRepo : ICityRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DataBaseCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
       public  




    }
}
