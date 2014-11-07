using WeShare.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;
using System.Collections.Generic;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for DATaskAssignmentTest and is intended
    ///to contain all DATaskAssignmentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DATaskAssignmentTest
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
        ///A test for UpdateTaskStatus
        ///</summary>
        [TestMethod()]
        public void UpdateTaskStatusTest()
        {
            DATaskAssignment target = new DATaskAssignment();
            int taskId = 1;
            string status = "completed";
            bool expected = true;
            bool actual;
            actual = target.UpdateTaskStatus(taskId, status);
            Assert.AreEqual(expected, actual);

        }

        
        /// <summary>
        ///A test for SaveAssignedTaskDetails
        ///</summary>
        [TestMethod()]
        public void SaveAssignedTaskDetailsTest()
        {
            DATaskAssignment target = new DATaskAssignment();
            TaskAssignmentInfo objTaskInfo = new TaskAssignmentInfo() { UserName = "Sandeep garimella", TaskId = 1, UserId = "sandeep@gmail.com", DueDate = "10/11/2014".ToDateTime(), Status = "completed" };
            bool expected = true;
            bool actual;
            actual = target.SaveAssignedTaskDetails(objTaskInfo);
            Assert.AreEqual(expected, actual);

        }
                
        /// <summary>
        ///A test for DATaskAssignment Constructor
        ///</summary>
        [TestMethod()]
        public void DATaskAssignmentConstructorTest()
        {
            DATaskAssignment target = new DATaskAssignment();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }


    }
}
