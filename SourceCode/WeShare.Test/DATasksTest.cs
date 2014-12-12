using WeShare.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;
using System.Collections.Generic;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for DATasksTest and is intended
    ///to contain all DATasksTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DATasksTest
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
            DATasks target = new DATasks(); // TODO: Initialize to an appropriate value
            TaskInfo objTaskInfo = new TaskInfo() { TaskId = 4, TaskTitle = "dishwashing", TaskDescription = "utensils", PointsAllocated = 10, TaskType = "weekly", IsTaskRecursive = true }; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveTaskDetails(objTaskInfo);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DeleteTask
        ///</summary>
        [TestMethod()]
        public void DeleteTaskTest()
        {
            DATasks target = new DATasks(); // TODO: Initialize to an appropriate value
            int TaskId = 3; // TODO: Initialize to an appropriate value
            target.DeleteTask(TaskId);
        }
    }
}
namespace WeShare.Test
{
    
    
    /// <summary>
    ///This is a test class for DATasksTest and is intended
    ///to contain all DATasksTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DATasksTest
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
        ///A test for GetTasksByGroupName
        ///</summary>
        [TestMethod()]
        public void GetTasksByGroupNameTest()
        {
            DATasks target = new DATasks(); // TODO: Initialize to an appropriate value
            string groupName = string.Empty; // TODO: Initialize to an appropriate value
            List<TaskInfo> expected = new List<TaskInfo>() {}; // TODO: Initialize to an appropriate value
            List<TaskInfo> actual;
            actual = target.GetTasksByGroupName(groupName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
