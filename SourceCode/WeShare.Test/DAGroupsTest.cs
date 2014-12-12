using WeShare.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;
using System.Collections.Generic;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for DAGroupsTest and is intended
    ///to contain all DAGroupsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DAGroupsTest
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
        ///A test for DAGroups Constructor
        ///</summary>
        [TestMethod()]
        public void DAGroupsConstructorTest()
        {
            DAGroups target = new DAGroups();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        



        /// <summary>
        ///A test for DeleteUserFromGroup
        ///</summary>
        [TestMethod()]
        public void DeleteUserFromGroupTest()
        {
            DAGroups target = new DAGroups(); // TODO: Initialize to an appropriate value
            string groupName = "2661E"; // TODO: Initialize to an appropriate value
            string userId = "srava@gmail.com"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteUserFromGroup(groupName, userId);
            Assert.AreEqual(expected, actual);

        }




    }
}
namespace WeShare.Test
{
    
    
    /// <summary>
    ///This is a test class for DAGroupsTest and is intended
    ///to contain all DAGroupsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DAGroupsTest
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
        ///A test for DeleteGroup
        ///</summary>
        [TestMethod()]
        public void DeleteGroupTest()
        {
            DAGroups target = new DAGroups(); // TODO: Initialize to an appropriate value
            string groupName = "2661E"; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteGroup(groupName);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveGroup
        ///</summary>
        [TestMethod()]
        public void SaveGroupTest()
        {
            DAGroups target = new DAGroups(); // TODO: Initialize to an appropriate value
            string userId = "garimella@gmail.com"; // TODO: Initialize to an appropriate value
            string currentNameofGroup = "2661E"; // TODO: Initialize to an appropriate value
            string newNameofGroup = "2661E"; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveGroup(userId, currentNameofGroup, newNameofGroup);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for AddUserToGroup
        ///</summary>
        [TestMethod()]
        public void AddUserToGroupTest()
        {
            DAGroups target = new DAGroups(); // TODO: Initialize to an appropriate value
            string groupName = "2661E"; // TODO: Initialize to an appropriate value
            string userId = "djanngo@gmail.com"; // TODO: Initialize to an appropriate value
            Decimal weeklyPoints = 40; // TODO: Initialize to an appropriate value
            DateTime recurrenceStartDate = "2014-12-12".ToDateTime(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddUserToGroup(groupName, userId, weeklyPoints, recurrenceStartDate);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetPointsDueByUserId
        ///</summary>
        [TestMethod()]
        public void GetPointsDueByUserIdTest()
        {
            DAGroups target = new DAGroups(); // TODO: Initialize to an appropriate value
            string userId = "garimella@gmail.com"; // TODO: Initialize to an appropriate value
            Decimal expected = 40; // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.GetPointsDueByUserId(userId);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
