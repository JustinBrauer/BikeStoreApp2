using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes
{
 /// <summary>
    /// Defines private global variables and implementation of the ICustomer Interface.
    /// </summary>
    /// <remarks>
    /// Methods implemented are typical customer and account holder interactions with setting up accounts or login/registration.
    /// </remarks>
    public class Customer 
    {
        /// <summary>
        /// Instance of the database entity.
        /// </summary>

        private ist440grp1Entities1 db1 = new ist440grp1Entities1();

        private int id;
        private string firstName;
        private string lastName;
        private ICollection<BikeStoreWebApp_Database.EmailAddress> email;
        private BikeStoreWebApp_Database.Password password;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private string zip;

        //public void BikeStoreApp.App_Code.Classes.Logger.Log(string message);

        /// <summary>
        /// Implementation of the ReadCustmerInfo method that will retrieve the customer's informatio based on the ID.
        /// </summary>
        /// <returns>Customer information as a List</returns>    
        public IList<BikeStoreWebApp_Database.Customer> GetCustomerInfo(int id)
        {   
            var customer = from c in db1.Customers
                           where c.CustomerID == id
                           select c;
            
            return customer.ToList();
        }

        /// <summary>
        /// Implementation of the Register method that creates a new account if the user submits a first name, last name, email, and password.
        /// </summary>
        /// <returns>If the information was updated correctly, it returns an int session variable</returns>
        public string Register(string first, string last, string email, string pass)
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query
            //insert into table a new first name, last name, email, and password
            //verify that the email and password were created ////according to specific requirements
            //if it was successful -- return true
            //else -- return false
            //sets some form of a webstate with a generic id for the duration

            try 
            {
                    //must add verification for email and password requirements

                var em = (from e in db1.EmailAddresses where e.EmailAddress1 == email select e.BusinessEntityID).Single();
                if (em != null)
                {
                    var person = (from p in db1.Customers where p.CustomerID == em select p).Single();

                    BikeStoreWebApp_Database.Password mail = new Password { ModifiedDate = DateTime.Now, PasswordHash = pass, PasswordSalt = DateTime.Now.ToString() };    //create new "password hash" like this for now until we implemenet the hash/salt
                    db1.SaveChanges();

                    return person.AccountNumber;    // should be returning an int sessionNum -- have to wait to set this up;
                }
                else
                {
                    using (ist440grp1Entities1 ent = new ist440grp1Entities1())
                    {
                        var create = new BikeStoreWebApp_Database.Person
                        {
                            ModifiedDate = DateTime.Now,
                            FirstName = first,
                            LastName = last,
                            Password = new Password() { ModifiedDate = DateTime.Now, PasswordHash = pass, PasswordSalt = DateTime.Now.ToString() },
                            //EmailAddresses = new List<EmailAddress>().Add()       //I have no idea how to complete this part
                        };

                        string value = "person created";

                        db1.SaveChanges();

                        return value;
            }
                }             
                //Login();  redirect straight to login automatically using the sessionNum?
            }

            catch (Exception ex)
            {
                string message = "Incorrect Email and Password";
                string e = ex.ToString();
                Console.WriteLine(e);
                return message;
            }
        }

        /// <summary>
        /// Implementation of the Login method that will accept a user's email and password for them to log into their account.
        /// </summary>
        /// <returns>True: if the email and password combination is valid</returns>
        public bool Login(string email, string pass)
        {
            //sets some form of a webstate with a generic id for the duration
            //must add verification for email and password requirements
            //compare that the email and password given is the same in the one in the database.


            var em = from e in db1.EmailAddresses where e.EmailAddress1 == email select e.BusinessEntityID;
            var pw = from w in db1.Passwords where w.PasswordHash == pass select w.BusinessEntityID;     //we really need to get the password thing going.

            if (em == pw)
            {
                return true;
            }
            else
                return false;


            //var onePerson = from p in db.Customers.Where(x => x.Person.EmailAddresses == email && x.Person.Password == password) select p;

            //switch case on account holder vs administrator
            //verify the type
        }

        /// <summary>
        /// Implementation of the DeleteAccount method that will accept a user's id and "delete" their account by deleting their password. 
        /// </summary>
        /// <returns>True: if the id is valid</returns>
        public bool DeleteAccount(int id)
        {
            // the main diff between an account holder and a customer is that the acct holder has a password

            //verify that the user is logged in
            //make sure that the database/table is connected
            //if logged in -- double check the EntityID
            //clicked yes -- drop the EntityID record
            //update all of the tables/views accordingly
            //else close database connection ???

            try 
            {
                if (id != null)
                {
                    var pass = (from p in db1.Passwords where p.BusinessEntityID == id select p).Single();
                    db1.Passwords.Remove(pass);
                        db1.SaveChanges();
                    return true;
                }
                else
                    return false;

                //change the sproc to make sure that it verifies that there is a password and that the password record is dropped or something similar?
            }
            
            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Implementation of EditAccountSettings method that will first read an account holder's information and then allow the user to edit/update their information.
        /// </summary>
        public bool ChangeAccountLastName(int id, string last)        //aka EditAccountSettings
        {
            //verify that the user is logged in
            //make sure that the database/table is connected
            //if logged in -- double check the EntityID
            //update the records based on the user's inputs
            //else

            try
            {
                if (id != null)
                {
                    var person = (from p in db1.Customers where p.CustomerID == id select p).Single();       //maybe change to verify for password and email combo first?
                    
                    person.Person.LastName = "Smith";
                    db1.SaveChanges();
                    return true;
                }
                else
                    return false;
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Implementation of ReadOrderHistory that accepts an Account Holder's first name, last name, and id and gets all of the orders associated with that account.
        /// </summary>
        public IList<BikeStoreWebApp_Database.SalesOrderHeader> ReadOrderHistory(int id)
        {
            //verify that the user is logged in
            //make sure that the database/table is connected
            //if logged in -- double check the EntityID
            //GetAllOrders based on the EntityID
            //else

            try
            {
                var orders = from o in db1.SalesOrderHeaders where o.CustomerID == id select o;
                return orders.ToList();
            
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
                return null;    /////////
            }
        }

        public void LogOff()
        {
            try
            {
                //this needs to delete a some form of webpage state and redirects the 
                //user back to the original home page 
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
            }
        }

        public bool Login()
        {
            return true;
        }      
    }
}