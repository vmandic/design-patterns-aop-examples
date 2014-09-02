using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.ConsoleApp.Models;
using App.ConsoleApp;
using App.ConsoleApp.Interfaces;

namespace App.UnitTesting
{
    /// <summary>
    /// Summary description for ConsoleAppTests
    /// </summary>
    [TestClass]
    public class ConsoleAppTests
    {
        public ConsoleAppTests()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Person_Say_ShouldThrowArgumentException()
        {
            IHuman p = new Person("Ivan", "Ivanovski", 19);

            try
            {
                //send an empty message
                p.Say();
            }
            catch (ArgumentException ae)
            {
                StringAssert.Contains(ae.Message, ExceptionMessages.PersonSay.GetDescription());
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exceptions were thrown!")]
        public void Person_SelfIntroduce_ShouldThrowNullReferenceException()
        {
            //create an empty person with age only
            var p = new Person();
            p.Age = 26;

            //should throw exception
            p.SelfIntroduce();

            Assert.Fail("No exception was thrown.");
        }
    }
}
