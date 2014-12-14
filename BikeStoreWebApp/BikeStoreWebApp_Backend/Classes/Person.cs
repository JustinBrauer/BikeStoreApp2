using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;
using System.Text.RegularExpressions;

namespace BikeStoreWebApp_Backend.Classes
{
    /// <summary>
    /// Person Class:
    /// -This is for actions that deal with any Persons, which include:
    /// -- Customers
    /// -- Manangers
    /// -- Employees
    /// </summary>
    public class Person : IPerson<BikeStoreWebApp_Database.Person>
    {
        private readonly IPerson<BikeStoreWebApp_Database.Person> personRepository;
        /// <summary>
        /// Implementation Method:
        /// -This constructor is blank for simple inheretance
        /// </summary>
        public Person()
        {

        }
        /// <summary>
        /// Implementation Method:
        /// -This Constructor is used for the Person repository.
        /// </summary>
        /// <param name="personRepository"></param>
        public Person(IPerson<BikeStoreWebApp_Database.Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        /// <summary>
        /// Implementation Method:
        /// -Thsi method will go into the DB and 
        /// </summary>
        /// <returns></returns>
        public IList<BikeStoreWebApp_Database.Person> GetAllCusomters()
        { 
            using (ist440grp1Entities1 entities = new ist440grp1Entities1())
            {
                var allPeople = from peeps in entities.People
                                where peeps.PersonType == "IN"
                                orderby peeps.BusinessEntityID ascending
                                 select peeps;
            return allPeople.ToList();          
        }
        }

        /// <summary>
        /// Implementation Mehtod: 
        /// -This will go into the DB and Get one Person according to the BusinessEntityId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BikeStoreWebApp_Database.Person GetOnePerson(int id)
        {
            try
            {
                BikeStoreWebApp_Database.Person onePerson;
                using (ist440grp1Entities1 entities = new ist440grp1Entities1())
                {
                    onePerson = (from p in entities.People
                                 where p.BusinessEntityID == id
                                 select p).Single();
            }

                return onePerson;
            }
            catch(InvalidOperationException IOE)
            {
                return null;
            }
            
        }

        /// <summary>
        /// Implementation Mehtod: 
        /// -This will go into the DB and Get one Person according to the First name and last name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public BikeStoreWebApp_Database.Person GetOnePerson(string firstName, string lastName)
        {
            try
            {
                BikeStoreWebApp_Database.Person onePerson;
                using (ist440grp1Entities1 entities = new ist440grp1Entities1())
                {
                    onePerson = (from p in entities.People
                                 where p.FirstName == firstName & p.LastName == lastName
                                 select p).Single();
                }

                return onePerson;
            }
            catch (InvalidOperationException IOE)
            {
                return null;
            }
        }

        /// <summary>
        /// Implementation Mehtod: 
        /// -This method checks to see if the user has specific user expereince rather than just the general display.
        /// </summary>
        /// <param name="personIds"></param>
        /// <returns></returns>
        public bool HasPersonalExperience(int personIds)
        {
            //Check Flag to see  if there Webiste is Taylored to what they personally like
            //Set Flag in C# Program to Switch all Pages to Specific Bike Type
            try
            {
                return true;
            }
            catch(InvalidOperationException IOE)
            {
                //Write to the Log File and also 
                return false;
            }
        }

        /// <summary>
        /// This method will check the Length of the FirstName
        /// to make sure that is eqaul to or greater than 2 characters 
        /// </summary>
        /// <param name="fName"></param>
        public bool CheckFirstNameValidation(string fName)
        {
            //Sets the length of the first Name to be equal to or
            //greater than 2 characters
            string pattern = ".{2,}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(fName);
        }

        /// <summary>
        /// This Expression Matches the valid Email. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// This checkes to make sure that the user input that proper State Code
        /// -The potentail is to have this as a Drop Down with in the application 
        /// and pull directly from the database.
        /// </summary>
        /// <param name="stateCode"></param>
        /// <returns></returns>
        public bool CheckFor_ValidStateCode(string stateCode)
        {
            return Regex.IsMatch(stateCode,
                "^((AL)|(AK)|(AS)|(AZ)|(AR)|(CA)|(CO)|(CT)|(DE)|(DC)|(FM)|(FL)|(GA)|(GU)|(HI)|(ID)|(IL)|(IN)|(IA)|(KS)" +
                "|(KY)|(LA)|(ME)|(MH)|(MD)|(MA)|(MI)|(MN)|(MS)|(MO)|(MT)|(NE)|(NV)|(NH)|(NJ)|(NM)|(NY)|(NC)|(ND)|(MP)|" +
                "(OH)|(OK)|(OR)|(PW)|(PA)|(PR)|(RI)|(SC)|(SD)|(TN)|(TX)|(UT)|(VT)|(VI)|(VA)|(WA)|(WV)|(WI)|(WY))$",
                RegexOptions.IgnoreCase);
        }
        
        /// <summary>
        /// This regular expressions matches phone numbers with area codes 
        /// and optional US country code and optional phone extension. User 
        /// have so many ways of entering phone numbers into input fields. 
        /// This allows for some of the ones I've encountered. 
        /// Matches:
        ///         2405525009 | 1(240) 652-5009 | 240/752-5009 ext.55
        /// Non-Matches:
        ///         (2405525009 | 2 (240) 652-5009
        /// Ref: http://www.regexlib.com/DisplayPatterns.aspx?cattabindex=6&categoryId=7&AspxAutoDetectCookieSupport=1
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public bool CheckFor_Valid_US_PhoneNum(string phoneNum)
        {
            return Regex.IsMatch(phoneNum, @"^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$");
        }


        /// <summary>
        /// This expression matches three different formats of postal codes:
        /// 5 digit US ZIP code, 5 digit US ZIP code + 4, and 6 digit alphanumeric
        /// Canadian Postal Code. The first one must be 5 numeric digits. The ZIP+4 
        /// must be 5 numeric digits, a hyphen, and then 4 numeric digits. The Canadian
        /// postal code must be of the form ANA NAN where A is any uppercase alphabetic
        /// character and N is a numeric digit from 0 to 9. 
        /// Matches: 
        ///         44240 | 44240-5555 | T2P 3C7
        /// Ref: http://www.regexlib.com/DisplayPatterns.aspx?cattabindex=6&categoryId=7&AspxAutoDetectCookieSupport=1
        /// </summary>
        /// <param name="PostalCodes"></param>
        /// <returns></returns>
        public bool CheckFor_ValidPostalCodes(string PostalCodes)
        {
            return Regex.IsMatch(PostalCodes,@"^((\d{5}-\d{4})|(\d{5})|([A-Z]\d[A-Z]\s\d[A-Z]\d))$");
        }

        /// <summary>
        /// This is a simple expression to check a US street address entered on one lines.
        /// Being short it does not check that the road qualifer is &quot;valid&quot; 
        /// (eg. drive, avenue, etc), but it does allow for the extended
        /// zip code. 
        /// Matches:
        ///         123 Anywhere Dr. apt #99 Somewhere, ST 55789 | 123 Anywhere Dr. 
        /// </summary>
        /// <param name="streetAddress"></param>
        /// <returns></returns>
        public bool CheckFor_ValidStreetAddress(string streetAddress)
        {
            return Regex.IsMatch(streetAddress, @"^[ \w]{3,}([A-Za-z]\.)?([ \w]*\#\d+)?(\r\n| )" + 
                    @"[ \w]{3,},\x20[A-Za-z]{2}\x20\d{5}(-\d{4})?$");
        }      

        /// <summary>
        /// Password expression. Password must be between 4 and 8 digits
        /// long and include at least one numeric digit.
        /// Macthes:
        ///          1234 | asdf1234 | asp123
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool PasswordValidation(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*\d).{4,8}$");
        }
             
    }
}