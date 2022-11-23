using Microsoft.EntityFrameworkCore;
using MVCPerson.Models;

namespace MVCPerson.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}