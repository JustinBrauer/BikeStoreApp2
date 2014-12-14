using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Interfaces
{
    public interface IOrder
    {
        bool IsAccountHolder();
        decimal CalculateTotal();
        void SendConfirmationEmail();
        void UpdateOrder();
        void CreateNewOrder();
        void DeleteOrder();
        void ReadOrder();
    }
}
