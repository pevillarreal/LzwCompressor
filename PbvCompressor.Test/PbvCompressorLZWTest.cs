using PbvCompressor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace PbvCompressor.Test
{
    
    
    /// <summary>
    ///This is a test class for PbvCompressorLZWTest and is intended
    ///to contain all PbvCompressorLZWTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PbvCompressorLZWTest
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
        ///A test for Decompress
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PbvCompressor.exe")]
        public void FullTest() //test compression and decompression
        {
            string line = "GEM8-GEU8,F,A,0,60303042,60303042,-0.14,1156AH8,F,B,0,60306043,60306043,90.51,106AH8,F,A,0,60306043,60306043,90.57,106AH8,F,B,0,60306092,60306092,90.52,106AM8,F,B,0,60306131,60306131,89.35,16AM8,F,A,0,60306131,60306131,89.5,3GEZ9-GEM0,F,B,0,60306436,60306436,0.415,175";
            string originalFileName = "originalTestFile";
            string outFileName = originalFileName + ".lzw";
            string inflatedName = originalFileName + ".inflated";
            StreamWriter writer = new StreamWriter(File.Create(originalFileName));
            writer.WriteLine(line);
            writer.Close();


            PbvCompressorLZW_Accessor target = new PbvCompressorLZW_Accessor(); // TODO: Initialize to an appropriate value
            string pInputFileName = originalFileName;
            string pOutputFileName = outFileName;
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;

            if (actual = ( target.Compress(originalFileName, outFileName)
                && target.Decompress(outFileName, inflatedName)))
            {
                if (!File.Exists(pOutputFileName))
                    actual = false;
                else
                {
                    StreamReader reader = new StreamReader(File.OpenRead(inflatedName));
                    actual = line.Equals(reader.ReadToEnd().TrimEnd());
                    reader.Close();
                }
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
