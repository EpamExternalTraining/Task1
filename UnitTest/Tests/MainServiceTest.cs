using DataLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Resources;

namespace UnitTest.Tests
{

    [TestClass]
    public class MainServiceTest
    {

        #region Resources

        private static IEnumerable<object[]> _correctProducts => TestsResources.CorrectProducts;
        private static string _filePath => TestsResources.FilePath;
        private static IProductFileWorker<BakeryProduct> _fileWorker => TestsResources.FileWorker;

        #endregion

        #region DataForTests


        private static IEnumerable<object[]> DataFor_CorrectResultOf_TakeWhereProductsIsEqualTo =>
            new List<object[]>
            {
                    new object[]
                    {
                        1,
                        _correctProducts.First()[0],
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    },
                    new object[]
                    {
                        0,
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    }
            };
        private static IEnumerable<object[]> DataFor_CorrectResultOf_TakeWhereProductsWeightIsHigherThan =>
            new List<object[]>
            {
                    new object[]
                    {
                        750,
                        "Вода",
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    },
                    new object[]
                    {
                        200,
                        "Сахар",
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    }
            };
        private static IEnumerable<object[]> DataFor_CorrectResultOf_TakeWhereIngredientCountIsHigherThan =>
            new List<object[]>
            {
                    new object[]
                    {
                        4,
                        0,
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    },
                    new object[]
                    {
                        3,
                        3,
                        _correctProducts.First()[0],
                        _correctProducts.First()[1],
                        _correctProducts.First()[2],
                    }
            };

        #endregion

        #region Tests

        [DynamicData(nameof(_correctProducts))]
        [DataTestMethod, Description("Checks if result of function CloneAndSortByCaloriesAmount is correct")]
        public void CorrectResultOf_CloneAndSortByCaloriesAmount(params BakeryProduct[] desiredProducts)
        {
            List<BakeryProduct> result = MainService.CloneAndSortByCaloriesAmount(_fileWorker.ReadFromFile(_filePath));

            desiredProducts = desiredProducts.OrderBy(a => a.GetCaloriesAmount()).ToArray();
            int i = 0;
            foreach(var item in result)
            {
                Assert.AreEqual(item, desiredProducts[0]);
                Assert.AreNotSame(item, desiredProducts[0]);
                ++i;
            }
        }

        [DynamicData(nameof(_correctProducts))]
        [DataTestMethod, Description("Checks if result of function CopyAndSortByPriceAmount is correct")]
        public void CorrectResultOf_CopyAndSortByPriceAmount(params BakeryProduct[] desiredProducts)
        {
            List<BakeryProduct> result = MainService.CloneAndSortByCaloriesAmount(_fileWorker.ReadFromFile(_filePath));

            desiredProducts = desiredProducts.OrderBy(a => a.GetPrice()).ToArray();
            int i = 0;
            foreach (var item in result)
            {
                Assert.AreEqual(item, desiredProducts[0]);
                Assert.AreNotSame(item, desiredProducts[0]);
                ++i;
            }
        }


        [DynamicData(nameof(DataFor_CorrectResultOf_TakeWhereProductsIsEqualTo))]
        [DataTestMethod, Description("Checks if result of function TakeWhereProductsIsEqualTo is correct")]
        public void CorrectResultOf_TakeWhereProductsIsEqualTo(int expectedCount, BakeryProduct expectedFirstProduct, params BakeryProduct[] desiredProducts)
        {
            var result = MainService.TakeWhereProductsIsEqualTo(desiredProducts.ToList(), expectedFirstProduct);

            Assert.AreEqual(expectedCount, result.Count);
            if (expectedCount != 0)
                Assert.AreEqual(expectedFirstProduct, result[0]);
        }


        [DynamicData(nameof(DataFor_CorrectResultOf_TakeWhereProductsWeightIsHigherThan))]
        [DataTestMethod, Description("Checks if result of function TakeWhereProductsWeightIsHigherThan is correct")]
        public void CorrectResultOf_TakeWhereProductsWeightIsHigherThan(double desiredWeight,string desiredIngredientName, params BakeryProduct[] desiredProducts)
        {
            var result = MainService.TakeWhereProductsWeightIsHigherThan(desiredProducts.ToList(), desiredIngredientName, desiredWeight);
            foreach (BakeryProduct item in result)
                Assert.IsTrue(item.Ingredients.Where(a => a.Name == desiredIngredientName).Sum(a => a.Weight) > desiredWeight);
        }

        [DynamicData(nameof(DataFor_CorrectResultOf_TakeWhereIngredientCountIsHigherThan))]
        [DataTestMethod, Description("Checks if count of elements of result of function TakeWhereIngredientCountIsHigherThan is correct")]
        public void CorrectResultOf_TakeWhereIngredientCountIsHigherThan(int desiredCount, int expectedResult, params BakeryProduct[] desiredProducts)
        {
            Assert.AreEqual(expectedResult, MainService.TakeWhereIngredientCountIsHigherThan(desiredProducts.ToList(), desiredCount).Count);
        }

        #endregion
    }

}
