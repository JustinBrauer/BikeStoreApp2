using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp.Models
{
    public interface IPersonRepository
    {
        IQueryable<Person> People { get; }
        Person GetPersonByType(int personId);
        Person Save(Person person);
        void Delete(Person person);
    }
}
