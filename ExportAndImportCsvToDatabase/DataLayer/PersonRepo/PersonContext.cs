using DataLayer.ModelPerson;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersonRepo
{
    public class PersonContext : DbContext
    {
        public PersonContext():base("Test")
        {
        }
            public DbSet<Person> Persons { get; set; }
    }
}
