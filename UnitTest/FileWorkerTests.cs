using DataLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class FileWorkerTests
    {

        #region Fields

        private static IEnumerable<object[]> _correctProducts => TestsResources.CorrectProducts;
        private static string _filePath => TestsResources.FilePath;
        private static IProductFileWorker<BakeryProduct> _fileWorker => TestsResources.FileWorker;

        #endregion

        #region Tests

        [DataRow("Error reading")]
        [DataTestMethod, Description("Reading CSV data and catch FileNotFoundException")]
        public void ReadingCSVDataFromTxtFile_FileNotFoundException(string filePath)
        {
            Assert.ThrowsException<FileNotFoundException>(() => _fileWorker.ReadFromFile(filePath));
        }

        [DynamicData(nameof(_correctProducts))]
        [DataTestMethod, Description("Reading CSV data and check for correct reading")]
        public void ReadingCSVDataFromTXTFileAndComparingFirstData_CorrectReading(params BakeryProduct[] expectedProducts)
        {
            int i = 0;
            foreach(BakeryProduct item in _fileWorker.ReadFromFile(_filePath))
            {
                Assert.AreEqual(item, expectedProducts[i]);
                ++i;
            }
        }

        #endregion

    }
}
