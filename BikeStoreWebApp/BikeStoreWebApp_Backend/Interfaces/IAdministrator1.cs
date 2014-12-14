using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Interfaces
{
    interface IAdministrator
    {
        //if store manager: do this (restricted)

        //else: as system admin do this (all)

        void AddNewProductToStore();
        void EditProductToStore();
        void DeleteProductToStore();
    }
}
