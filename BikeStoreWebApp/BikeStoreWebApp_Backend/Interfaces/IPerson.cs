using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Interfaces
{
    /// <summary>
    /// This Interface has the Type being determined at the class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPerson<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<T> GetAllCusomters();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BikeStoreWebApp_Database.Person GetOnePerson(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        BikeStoreWebApp_Database.Person GetOnePerson(string firstName, string lastName);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool HasPersonalExperience(int personId);

    }
}
