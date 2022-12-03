using Microsoft.EntityFrameworkCore;
using MVCPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCPerson.Data
{ 
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
         public DbSet<Country> Countries { get; set; }
    
    
    }
}