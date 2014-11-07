using WeShare.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for BLTasksTest and is intended
    ///to contain all BLTasksTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BLTasksTest
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
        ///A test for SaveTaskDetails
        ///</summary>
        [TestMethod()]
        public void SaveTaskDetailsTest()
        {
            BLTasks target = new BLTasks(); // TODO: Initialize to an appropriate value
            TaskInfo objUserInfo = new TaskInfo() { TaskId = 1, TaskTitle = " cooking", TaskDescription = " cook food", PointsAllocated = 10, TaskType = "weekly", IsTaskRecursive = true };
            bool expected = true;
            bool actual;
            actual = target.SaveTaskDetails(objUserInfo);
            Assert.AreEqual(expected, actual);

        }
    }
}
