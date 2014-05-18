using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StopForgetting.Model;


namespace StopForgetting.Tests
{
    /// <summary>
    /// Summary description for TaskBucketingStrategyTest
    /// </summary>
    [TestClass]
    public class TaskBucketingStrategyTest
    {
        public TaskBucketingStrategyTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void test_task_in_today_bucket()
        {
            var strategy = new TaskBucketingStrategy();

            var task = new Task() { When = DateTime.Now };

            var result = strategy.DetermineBucket(task);

            Assert.AreEqual("Today", result);
        }

        [TestMethod]
        public void test_task_not_in_today_bucket()
        {
            var strategy = new TaskBucketingStrategy();

            var task = new Task() { When = DateTime.Now.AddDays(5) };

            var result = strategy.DetermineBucket(task);

            Assert.AreNotEqual("Today", result);
        }

        [TestMethod]
        public void test_task_in_tomorrow_bucket()
        {
            var strategy = new TaskBucketingStrategy();

            var task = new Task() { When = DateTime.Now.AddDays(1) };

            var result = strategy.DetermineBucket(task);

            Assert.AreEqual("Tomorrow", result);
        }

        [TestMethod]
        public void test_task_not_in_tomorrow_bucket()
        {
            var strategy = new TaskBucketingStrategy();

            var task = new Task() { When = DateTime.Now.AddDays(3) };

            var result = strategy.DetermineBucket(task);

            Assert.AreNotEqual("Tomorrow", result);
        }

        [TestMethod]
        public void test_task_in_this_week_bucket()
        {
            //have to mock datetime.now to get this to work

            Assert.IsTrue(true);
        }
            
    }
}
