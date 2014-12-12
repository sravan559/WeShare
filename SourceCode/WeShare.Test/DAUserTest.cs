using WeShare.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for DAUserTest and is intended
    ///to contain all DAUserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DAUserTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for IsUserValid
        ///</summary>
        [TestMethod()]
        public void IsUserValidTest()
        {
            DAUser target = new DAUser(); // TODO: Initialize to an appropriate value
            string userId = "sandeep@gmail.com"; // TODO: Initialize to an appropriate value
            string password = "123"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsUserValid(userId, password);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for SaveUserDetails
        ///</summary>
        [TestMethod()]
        public void SaveUserDetailsTest()
        {
            DAUser target = new DAUser(); // TODO: Initialize to an appropriate value
            UserInfo objUserInfo = new UserInfo() { UserId = "sand@gmail.com", FirstName = "Saehfep", LastName = "arimfffella", ContactNumber = "12545", Password = "16203" }; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveUserDetails(objUserInfo);
            Assert.AreEqual(expected, actual);
        }


    }
}
namespace WeShare.Test
{
    
    
    /// <summary>
    ///This is a test class for DAUserTest and is intended
    ///to contain all DAUserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DAUserTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUserTest()
        {
            DAUser target = new DAUser(); // TODO: Initialize to an appropriate value
            string userId = "django@gmail.com"; // TODO: Initialize to an appropriate value
            target.DeleteUser(userId);
            
        }
    }
}
