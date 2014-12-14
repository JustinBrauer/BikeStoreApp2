using System;
using BikeStoreWebApp_Backend.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeStoreWebApp_UnitTestProject
{
    [TestClass]
    public class PersonInfo_test
    {
        Person p = new Person();

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckFirstName_Valid()
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
        public void tst_CheckFirstName_Invalid()
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
        public void tst_CheckFirstName_Value()
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
        public void tst_CheckEmail_Valid()
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
        public void tst_CheckEmail_Invalid()
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
        public void tst_CheckEmail_Value()
        {
            //Arrenge 
            string email = "jeb434@psu.edu";

            //Act
            bool validEmail = p.CheckEmail(email);

            //Assert
            Assert.AreEqual(true, validEmail);
        }

        public void tst_CheckStateCodes_Valid()
        {
            //Arrage
            string stateCode = "PA";

            //Act
            bool VaildCode = p.CheckFor_ValidStateCode(stateCode);

            //Assert
            Assert.IsTrue(VaildCode);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckStateCodes_InValid()
        {
            //Arrage
            string stateCode = "PP";

            //Act
            bool VaildCode = p.CheckFor_ValidStateCode(stateCode);

            //Assert
            Assert.IsFalse(VaildCode);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckStateCodes_Value()
        {
            //Arrage
            string stateCode = "PA";

            //Act
            bool VaildCode = p.CheckFor_ValidStateCode(stateCode);

            //Assert
            Assert.AreEqual(true, VaildCode);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPhoneNum_Valid()
        {
            //Arrange
            string phoneNum = "(240)552-5009";
            
            //Act
            bool validPhone = p.CheckFor_Valid_US_PhoneNum(phoneNum);

            //Assert
            Assert.IsTrue(validPhone);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPhoneNum_Invalid()
        {
            //Arrange
            string phoneNum = "(215222-2222";

            //Act
            bool validPhone = p.CheckFor_Valid_US_PhoneNum(phoneNum);

            //Assert
            Assert.IsFalse(validPhone);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPhoneNum_Value()
        {
            //Arrange
            string phoneNum = "(240)552-5009";

            //Act
            bool validPhone = p.CheckFor_Valid_US_PhoneNum(phoneNum);

            //Assert
            Assert.AreEqual(true, validPhone);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPostalCode_Valid()
        {
            //Arrange
            string code = "19001";

            //Act
            bool Validcode = p.CheckFor_ValidPostalCodes(code);

            //Assert
            Assert.IsTrue(Validcode);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPostalCode_Invalid()
        {
            //Arrange
            string code = "19001-2";

            //Act
            bool Validcode = p.CheckFor_ValidPostalCodes(code);

            //Assert
            Assert.IsFalse(Validcode);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckPostalCode_Value()
        {
            //Arrange
            string code = "19001";

            //Act
            bool Validcode = p.CheckFor_ValidPostalCodes(code);

            //Assert
            Assert.AreEqual(true, Validcode);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckStreetAddress_Valid()
        {
            //Arrange
            string streetAddr = "123 Anywhere Dr. apt #99 Somewhere, ST 55789";

            //Act
            bool validstreetAddr = p.CheckFor_ValidStreetAddress(streetAddr);

            //Assert
            Assert.IsTrue(validstreetAddr);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckStreetAddress_Invalid()
        {
            //Arrange
            string streetAddr = "123 Anywhere";

            //Act
            bool validstreetAddr = p.CheckFor_ValidStreetAddress(streetAddr);

            //Assert
            Assert.IsFalse(validstreetAddr);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CheckStreetAddress_Value()
        {
            //Arrange
            string streetAddr = "123 Anywhere Dr. apt #99 Somewhere, ST 55789";

            //Act
            bool validstreetAddr = p.CheckFor_ValidStreetAddress(streetAddr);

            //Assert
            Assert.IsTrue(validstreetAddr);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_Password_Valid()
        {
            string password = "MyLove2";

            bool validPassword = p.PasswordValidation(password);

            Assert.IsTrue(validPassword);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_Password_Invalid()
        {
            string password = "MyLove2,s";

            bool validPassword = p.PasswordValidation(password);

            Assert.IsFalse(validPassword);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_Password_Value()
        {
            string password = "MyLove2";

            bool validPassword = p.PasswordValidation(password);

            Assert.AreEqual(true, validPassword);
        }

    }
}
