using DataLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Resources;

namespace UnitTest.Tests
{

    [TestClass]
    public class ModelsTest
    {

        #region Resources

        private static IEnumerable<object[]> _correctProducts => TestsResources.CorrectProducts;
        private static IProductFileWorker<BakeryProduct> _fileWorker => TestsResources.FileWorker;
        private static string _filePath => TestsResources.FilePath;

        #endregion

        #region Tests

        [DynamicData(nameof(_correctProducts))]
        [DataTestMethod, Description("Reading data from file and check for correct calories amount calculating")]
        public void ReadingCSVDataFromTXTFile_CorrectCaloriesAmountCalculating(params BakeryProduct[] products)
        {
            int i = 0;
            foreach(var item in _fileWorker.ReadFromFile(_filePath))
            {
                Assert.AreEqual(item.GetCaloriesAmount(), products[i].Ingredients.Sum(a => a.CaloriesAmount));
                ++i;
            }
        }

        [DynamicData(nameof(_correctProducts))]
        [DataTestMethod, Description("Reading data from file and check for correct price calculating")]
        public void ReadingCSVDataFromTXTFile_CorrectPriceCalculating(params BakeryProduct[] products)
        {
            int i = 0;
            foreach (var item in _fileWorker.ReadFromFile(_filePath))
            {
                Assert.AreEqual(item.GetPrice(), products[i].Ingredients.Sum(a => a.Price) * (1 + products[i].Markup/100));
                ++i;
            }
        }

        #endregion
    }

}
