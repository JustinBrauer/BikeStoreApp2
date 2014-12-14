using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeStoreWebApp_Backend;
using BikeStoreWebApp_Backend.Classes;

namespace BikeStoreWebApp_UnitTestProject
{
    [TestClass]
    public class Customer_UnitTests
    {
        Person p = new Person();

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckFirstNameForCustomer_Valid()
        {
            //Arrange
            string name = "Justin";

            //Act
            bool ValidName = p.CheckFirstNameValidation(name);

            Assert.IsTrue(ValidName, "The name is invalid, but expected a.");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckFirstNameForCustomer_Invalid()
        {
            //Arrange
            string name = "J";

            //Act
            bool ValidName = p.CheckFirstNameValidation(name);

            Assert.IsFalse(ValidName, "The name is not valid.");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckFirstNameForCustomer_Value()
        {
            //Arrange
            string name = "J";

            //Act
            bool ValidName = p.CheckFirstNameValidation(name);

            Assert.AreEqual(false, ValidName, "The Expected the value is  .");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckEmailForCustomer_Valid()
        {
            //Arrenge 
            string email = "jeb434@psu.edu";

            //Act
            bool validEmail = p.CheckEmail(email);

            //Assert
            Assert.IsTrue(validEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckEmailForCustomer_Invalid()
        {
            //Arrenge 
            string email = "jeb434psu.edu";

            //Act
            bool validEmail = p.CheckEmail(email);

            //Assert
            Assert.IsFalse(validEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckEmailForCustomer_Value()
        {
            //Arrenge 
            string email = "jeb434@psu.edu";

            //Act
            bool validEmail = p.CheckEmail(email);

            //Assert
            Assert.AreEqual(true, validEmail);
        }



    }
}
