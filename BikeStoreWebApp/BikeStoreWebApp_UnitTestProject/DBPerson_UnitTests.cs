using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BikeStoreWebApp_Database;
using BikeStoreWebApp_Backend.Classes;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp.Models;


namespace BikeStoreWebApp_UnitTestProject
{
    /// <summary>
    /// Summary description for PersonUnitTest
    /// </summary>
    [TestClass]
    public class DBPersonUnitTest
    {

        BikeStoreWebApp_Backend.Classes.Person _pclass = new BikeStoreWebApp_Backend.Classes.Person(null);

        private IList<BikeStoreWebApp_Database.Person> people;

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetOnePerson" method Returns a valid person type.
        /// </summary>
        [TestInitialize()]        
        public void SetupTest()
        {
            #region Add new Poeple
            people = new List<BikeStoreWebApp_Database.Person>()
            {
                new BikeStoreWebApp_Database.Person()
                {
                    Title = "Mr.",
                    FirstName = "Allen",
                    LastName = "Conway",
                    PersonType = "EM",
                    BusinessEntityID = 1
                },
                new BikeStoreWebApp_Database.Person()
                {
                    Title = "Mr.",
                    FirstName = "John",
                    LastName = "Smith",
                    PersonType = "SC",
                    BusinessEntityID = 2
                }
            };
            #endregion
        }

        /// <summary>
        /// Test Method:
        /// -This test checks to see if the "GetAllCustmoers" returns a person type
        /// </summary>
        [TestMethod]
        public void tstPersonSearch_ShouldFind_ValidInstance()
        {
            //Arrange
            var repositoryMock = new Mock<IPerson<BikeStoreWebApp_Database.Person>>();
            //Setup mock that will return People list when called:
            repositoryMock.Setup(x => x.GetAllCusomters()).Returns(people);
            var person = new BikeStoreWebApp_Backend.Classes.Person(repositoryMock.Object);

            //Act (mocked up IRepository will supply the data when calls are made to the repository)
            var singlePerson = person.GetOnePerson("Allen", "Conway");

            //Assert
            Assert.IsNotNull(singlePerson); // Test if null
            Assert.IsInstanceOfType(singlePerson, typeof(BikeStoreWebApp_Database.Person)); // Test type
        }        

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetOnePerson" method Returns a valid person type.
        /// </summary>
        [TestMethod]
        public void tstValidateCorrect_ReturnType_GetOnePerson()
        {
            var mPerson = new Mock<IPerson<BikeStoreWebApp_Database.Person>>();

            mPerson.Setup(x => x.GetAllCusomters()).Returns(people);
            var person = new BikeStoreWebApp_Backend.Classes.Person(mPerson.Object);

            var singleperson = person.GetOnePerson(1);

            Assert.IsInstanceOfType(singleperson, typeof(BikeStoreWebApp_Database.Person));
        }

        /// <summary>
        /// Test Method:
        /// - Checks to see if the "GetOnperson" will not return a type person if t
        /// </summary>
        [TestMethod]
        public void tstValidateBad_ReturnType_GetOnePerson()
        {
            var mPerson = new Mock<IPerson<BikeStoreWebApp_Database.Person>>();

            mPerson.Setup(x => x.GetAllCusomters()).Returns(people);
            var person = new BikeStoreWebApp_Backend.Classes.Person(mPerson.Object);

            var singleperson = person.GetOnePerson(000);

            Assert.IsNotInstanceOfType(singleperson, typeof(BikeStoreWebApp_Database.Person));
        }

        /// <summary>
        /// Unit Test:
        /// -This Method will take 10minute to complete
        /// </summary>
        [TestMethod]
        public void tstEnsure_GetAllCusomtersViaSproc_NotNull()
        {
            //PersonModel pm = new PersonModel();

            ////Get all People in the DataBase
            //IQueryable<GetAllCustomers_Result> allPeople = pm.GetAllCusomtersViaSproc();

            ////If the list is not Empty, it shall pass
            //Assert.IsNotNull(allPeople);            
        }

        /// <summary>
        /// Unit Test:
        /// -This Test determines that type that is returned from the Method.
        /// </summary>
        [TestMethod]
        public void tstEnsure_GetAllCusomtersViaSproc_CheckType()
        {
            //PersonModel pm = new PersonModel();            

            ////Get all People in the DataBase
            //IQueryable<GetAllCustomers_Result> allPeople = pm.GetAllCustomers_Result();

            ////If the list is not Empty, it shall pass
            //Assert.IsInstanceOfType(allPeople, typeof(GetAllCustomers_Result));
        }

        /// <summary>
        /// Unit Test:
        /// -This Method will take 10minute to complete
        /// </summary>
        [TestMethod]
        public void tstEnsure_GetAllCusomtersViaSproc_ReturnsaValue()
        {
            PersonModel pm = new PersonModel();

            //Get all People in the DataBase
            //var allPeople = pm.GetAllCustomersViaSproc();

            //var Oneperson = (from p in allPeople where
            //                p.FirstName.Contains("Anna")
            //                select p).Single();

            //string fname = Oneperson.FirstName;
            //foreach(var person in allPeople)
            //{
            //    Assert.IsInstanceOfType(person.FirstName, typeof(string));
            //    Assert.IsInstanceOfType(person.BusinessEntityID, typeof(int));
            //    break;
            //}

            ////If the list is not Empty, it shall pass
            //Assert.IsNotNull(allPeople);
        }

        /// <summary>
        /// Test Method:
        /// -This Unit Test is checking to make sure that the "GetAllPeople" method get a valid Instance of a Person type
        /// </summary>
         [TestMethod]
        public void tstEnsure_GetAllPeople_ReturnsAValidPerson()
        {
             //setup Test with variables
             int personId = 0;

            //Get all People in the DataBase
            var  allPeople = (List<GetAllCustomers_Result>)_pclass.GetAllCusomters();

             //Get the first Person Id
            foreach (var person in allPeople)
            {
                personId = person.customerId;
                break;
            }

            Assert.AreEqual(personId, 1699);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns a VALID person
        /// -This method is using the "GetSinglePerson" that searches by Id
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsNotNullValue_usingID()
        {
            var oneperson = _pclass.GetOnePerson(7430);

            Assert.IsTrue(oneperson != null);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns a VALID person
        /// -This method is using the "GetSinglePerson" that searches by Id
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsValidPerson_usingID()
        {
            var oneperson = _pclass.GetOnePerson(7430);

            Assert.IsInstanceOfType(oneperson, typeof(BikeStoreWebApp_Database.Person));
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns a INVALID person
        /// -This method is using the "GetSinglePerson" that searches by Id
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsInValidPerson_usingID()
        {
            var oneperson = _pclass.GetOnePerson(100000);

            Assert.IsTrue(oneperson == null);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns the proper value when searching for a Person
        /// -This method is using the "GetSinglePerson" that searches by Id
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsCorrectValue()
        {
            var oneperson = _pclass.GetOnePerson(7430);

            Assert.AreEqual("Ana", oneperson.FirstName);
            Assert.AreEqual("Price", oneperson.LastName);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns a VALID person
        /// -This method is using the "GetSinglePerson" that searches by First and Last Name
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsValidPerson_UsingNames()
        {
            var oneperson = _pclass.GetOnePerson("Gilbert", "Raje");

            Assert.IsTrue(oneperson != null);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns a INVALID person
        /// -This method is using the "GetSinglePerson" that searches by First and Last Name
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsInValidPerson_UsingNames()
        {
            var oneperson = _pclass.GetOnePerson("GWrong", "Raje");

            Assert.IsTrue(oneperson == null);
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns the proper value when searching for a Person
        /// -This method is using the "GetSinglePerson" that searches by First and Last Name
        /// </summary>
        [TestMethod]
        public void tstEnsure_Getsingleperson_returnsCorrectValue_UsingNames()
        {
            var oneperson = _pclass.GetOnePerson("GWrong", "Raje");

            Assert.AreEqual(9489, oneperson.BusinessEntityID);
        }
        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "HasPersonalExperience" 
        /// -This method is using the "HasPersonalExperience" which uses the Id as its parameter
        /// </summary>
        [TestMethod]
        public void tstEnsure_HasPersonalExperience_ReturnsValid()
        {
            bool isTaylored =false;
            int id = 7430;
            try
            {
                isTaylored = _pclass.HasPersonalExperience(id);
            }
            catch(InvalidOperationException IEO)
            {
                Assert.Fail();
            }
           
        }

        /// <summary>
        /// Test Method:
        /// -This method checks to see if the "GetSinglePerson" method returns the proper value when searching for a Person
        /// -This method is using the "HasPersonalExperience" which uses the Id as its parameter
        /// </summary>
        [TestMethod]
        public void tstEnsure_HasPersonalExperience_ReturnsInValid()
        {
            bool isTaylored = false;
            int id = 100000;
            
            isTaylored = _pclass.HasPersonalExperience(id);

            Assert.IsFalse(isTaylored, "It is Saying that this person Exist and will have a talored experience.");
        }
    }
      
}
