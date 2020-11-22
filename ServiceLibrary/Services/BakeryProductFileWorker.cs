using DataLibrary.Models;
using ServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiceLibrary.Services
{

    /// <summary>
    /// Static class that allowes you to read/write BakeryProducts from/to file
    /// </summary>
    public class BakeryProductFileWorker : IProductFileWorker<BakeryProduct>
    {

        #region Methods

        /// <summary>
        /// Read and returns List of BakeryProduct from file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>List of BakeryProduct</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public List<BakeryProduct> ReadFromFile(string filePath)
        {
            if (filePath is null) throw new ArgumentNullException("Variable filePath is null");
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File \"{filePath}\" not found");

            List<BakeryProduct> products = new List<BakeryProduct>();

            using (StreamReader reader = new StreamReader(filePath))
            {
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

                    int n = res.Length - 1;

                    if ((n - 2) % 4 != 0) throw new FileLoadException("Wrong format of Ingredients for this product");

                    List<Ingredient> ingredients = new List<Ingredient>();
                    for (int i = 2; i < n - 1; i += 4)
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
            }

            return products;
        }

        /// <summary>
        /// Write to file List of BakeryProduct
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="products">List of BakeryProduct for writing to file</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteToFile(string filePath, List<BakeryProduct> products)
        {
            if (filePath is null || products is null) throw new ArgumentNullException("Variable filePath is null");
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File \"{filePath}\" not found");


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (BakeryProduct product in products)
                {
                    StringBuilder productString = new StringBuilder("");

                    if (product is LoafBakeryProduct) productString.Append("Loaf; ");
                    if (product is BreadBakeryProduct) productString.Append("Bread; ");

                    productString.Append($"{product.Name}; ");

                    foreach (Ingredient ingredient in product.Ingredients)
                        productString.Append($"{ingredient.Name}; {ingredient.Weight}; {ingredient.Price}; {ingredient.CaloriesAmount}; ");

                    writer.WriteLine(productString);
                }
            }
        }

        #endregion

    }

}
