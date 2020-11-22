using DataLibrary.Models;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{
    public static class TestsResources
    {
        public static string FilePath { get; private set; } = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "products.txt");
        public static IProductFileWorker<BakeryProduct> FileWorker { get; private set; } = new BakeryProductFileWorker();
        public static IEnumerable<object[]> CorrectProducts 
            => new List<object[]>
            {
                new BakeryProduct[]
                {
                    new BreadBakeryProduct("Хлеб пшеничный",
                        new Ingredient("Соль", 10, 0.5m, 10),
                        new Ingredient("Тесто", 500, 2.5m, 100),
                        new Ingredient("Сахар", 10, 0.25m, 0.1),
                        new Ingredient("Вода", 1000, 2.8m, 0.01)),

                    new LoafBakeryProduct("Баттон французский",
                        new Ingredient("Соль", 10, 0.5m, 10),
                        new Ingredient("Тесто", 500, 2.5m, 100),
                        new Ingredient("Сахар", 100, 1m, 0.1),
                        new Ingredient("Вода", 1500, 5m, 0.01)),

                    new BreadBakeryProduct("Хлеб ржаной",
                        new Ingredient("Соль", 10, 0.5m, 10),
                        new Ingredient("Тесто", 500, 2.5m, 100),
                        new Ingredient("Сахар", 10, 0.25m, 0.1),
                        new Ingredient("Вода", 500, 1.8m, 0.01))
                }
            };
    }
}
