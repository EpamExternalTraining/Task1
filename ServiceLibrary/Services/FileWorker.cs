using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiceLibrary.Services
{
    /// <summary>
    /// Static class that allowes you to read/write BakeryProducts from/to file
    /// </summary>
    public static class FileWorker
    {

        /// <summary>
        /// Read and returns List of BakeryProduct from file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>List of BakeryProduct</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static List<BakeryProduct> ReadFromFile(string filePath)
        {
            if (filePath is null) throw new ArgumentNullException("Variable filePath is null");
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {filePath} not found");

            List<BakeryProduct> products = new List<BakeryProduct>();

            StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                string[] res = reader.ReadLine().Split(';');
                BakeryProduct product;
                switch (res[0])
                {
                    case "Loaf": product = new LoafBakeryProduct(); break;
                    case "Bread": product = new BreadBakeryProduct(); break;
                    default: throw new FileLoadException("Wrong product category");
                }

                product.Name = res[1];

                int n = res.Length;

                if ((n - 2) % 4 != 0) throw new FileLoadException("Wrong format of Ingredients for this product");

                List<Ingredient> ingredients = new List<Ingredient>();
                for (int i = 2; i < n; i += 4)
                {
                    Ingredient ingredient;
                    try
                    {
                        ingredient =
                            new Ingredient(
                                            res[i],
                                            Convert.ToDouble(res[i + 1]),
                                            Convert.ToDecimal(res[i + 2]),
                                            Convert.ToDouble(res[i + 3])
                                          );
                    }
                    catch (Exception)
                    {
                        throw new FileLoadException("Wrong format of Ingredients for this product");
                    }
                    ingredients.Add(ingredient);
                }

                product.Ingredients = ingredients;

            }

            return products;
        }

        /// <summary>
        /// Write to file List of BakeryProduct
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static void WriteToFile(string filePath, List<BakeryProduct> products)
        {
            if (filePath is null || products is null) throw new ArgumentNullException("Variable filePath is null");
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {filePath} not found");


            StreamWriter writer = new StreamWriter(filePath, true);

            foreach(BakeryProduct product in products)
            {
                StringBuilder productString = new StringBuilder("");

                if (product is LoafBakeryProduct) productString.Append("Loaf; ");
                if (product is BreadBakeryProduct) productString.Append("Bread; ");

                foreach(Ingredient ingredient in product.Ingredients)
                    productString.Append($"{ingredient.Name}; {ingredient.Weight}; {ingredient.Price}; {ingredient.CaloriesAmount}; ");
                
                writer.WriteLine(productString);
            }
        }
    }
}
