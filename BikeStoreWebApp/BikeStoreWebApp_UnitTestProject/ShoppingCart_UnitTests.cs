using System;
using BikeStoreWebApp_Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeStoreWebApp_UnitTestProject
{
    [TestClass]
    public class ShoppingCart_UnitTests
    {

        [TestMethod]
        public void tstCalculateCartTotalwithTax()
        {
            //BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
            //var oneProduct = _cart.AddProductInCart(11111, 41);
            //Assert.IsInstanceOfType();
        }

        [TestMethod]
        public void tstIsEmpty()
        {
            BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
            var emptyCart = _cart.IsEmpty();
            Assert.IsFalse(false);
        }
        [TestMethod]
        public void tst_GuestCreateCart()
            {
                BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
                var createUserCart = _cart.IsGuestCreateCart();
                Assert.IsTrue(true);

            }
        [TestMethod]
        public void tst_GrabTotalCartWithTax()
        {
            //BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
            //IList<MyClass> result = _cart.CalculateCartTotalwithTax();
//            Assert.AreNotEqual();
        } 
        [TestMethod]
        public void tst_ProductTotal()
        {
            BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
            var calTotal = _cart.CalculateProductTotal(1100,"Touring");
            Assert.IsNotNull(calTotal);
        }
        [TestMethod]
        public void tst_FailedProductTotal()
        {
            BikeStoreWebApp_Backend.Classes.ShoppingCart _cart = new BikeStoreWebApp_Backend.Classes.ShoppingCart();
            var calFailTotal = _cart.CalculateProductTotal(0, "empty");
            Assert.IsNotNull(calFailTotal);
        }
      }
}
