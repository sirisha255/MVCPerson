using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        City FindBy(int id);
        bool Update(City city);
        bool Delete(City city);
        
    }
}
