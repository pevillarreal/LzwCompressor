using PbvCompressor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
namespace PbvCompressor.Test
{
    
    
    /// <summary>
    ///This is a test class for FileNameSelectorTest and is intended
    ///to contain all FileNameSelectorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileNameSelectorTest
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
        ///A test for GetFileName
        ///</summary>
        [TestMethod()]
        public void GetFileNameTest() //test selector
        {
            string pFileName = "testFilename"; 
            string expected = pFileName; 
            string actual;
            actual = FileNameSelector.GetFileName(pFileName);
            Assert.AreEqual(expected, actual);

            string pFileName2 = "testnName2";
            expected = pFileName2;
            File.Create(pFileName);
            StringReader sr = new StringReader("n" + Environment.NewLine + pFileName2 + Environment.NewLine);
            Console.SetIn(sr);
            actual = FileNameSelector.GetFileName(pFileName);
            Assert.AreEqual(actual, expected);

            sr = new StringReader("y" + Environment.NewLine);
            Console.SetIn(sr);
            actual = FileNameSelector.GetFileName(pFileName);
            Assert.AreEqual(actual, pFileName);
        }
    }
}
