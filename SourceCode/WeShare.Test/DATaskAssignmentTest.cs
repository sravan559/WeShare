using WeShare.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeShare.BusinessModel;
using System.Collections.Generic;

namespace WeShare.Test
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
        ///A test for DATaskAssignment Constructor
        ///</summary>
        [TestMethod()]
        public void DATaskAssignmentConstructorTest()
        {
            DATaskAssignment target = new DATaskAssignment();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AssignTask
        ///</summary>
        [TestMethod()]
        public void AssignTaskTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            TaskAssignmentInfo objTaskInfo = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AssignTask(objTaskInfo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAssignedTaskListByGroupName
        ///</summary>
        [TestMethod()]
        public void GetAssignedTaskListByGroupNameTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            string groupName = string.Empty; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> expected = null; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> actual;
            actual = target.GetAssignedTaskListByGroupName(groupName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRoomMatesAssignedTasks
        ///</summary>
        [TestMethod()]
        public void GetRoomMatesAssignedTasksTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            string userId = string.Empty; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> expected = null; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> actual;
            actual = target.GetRoomMatesAssignedTasks(userId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUnassignedTasksByGroup
        ///</summary>
        [TestMethod()]
        public void GetUnassignedTasksByGroupTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            string groupName = string.Empty; // TODO: Initialize to an appropriate value
            List<TaskInfo> expected = null; // TODO: Initialize to an appropriate value
            List<TaskInfo> actual;
            actual = target.GetUnassignedTasksByGroup(groupName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserTasksByMailId
        ///</summary>
        [TestMethod()]
        public void GetUserTasksByMailIdTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            string userId = string.Empty; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> expected = null; // TODO: Initialize to an appropriate value
            List<TaskAssignmentInfo> actual;
            actual = target.GetUserTasksByMailId(userId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MarkTaskAsComplete
        ///</summary>
        [TestMethod()]
        public void MarkTaskAsCompleteTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            int taskId = 0; // TODO: Initialize to an appropriate value
            DateTime taskCompletedDate = new DateTime(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MarkTaskAsComplete(taskId, taskCompletedDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateAssignedTaskDetails
        ///</summary>
        [TestMethod()]
        public void UpdateAssignedTaskDetailsTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            int taskId = 0; // TODO: Initialize to an appropriate value
            string userId = string.Empty; // TODO: Initialize to an appropriate value
            Nullable<DateTime> dtDueDate = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateAssignedTaskDetails(taskId, userId, dtDueDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateTaskPoints
        ///</summary>
        [TestMethod()]
        public void UpdateTaskPointsTest()
        {
            DATaskAssignment target = new DATaskAssignment(); // TODO: Initialize to an appropriate value
            Decimal taskpoints = new Decimal(); // TODO: Initialize to an appropriate value
            string userID = string.Empty; // TODO: Initialize to an appropriate value
            int taskID = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateTaskPoints(taskpoints, userID, taskID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
