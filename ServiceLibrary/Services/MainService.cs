using DataLibrary.Models;
using ServiceLibrary.Utils.Comparers;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLibrary.Services
{

    /// <summary>
    /// Class that has main functionality for the Task
    /// </summary>
    public class MainService
    {

        #region Methods

        /// <summary>
        /// Clones and Sorts bakery products by Calories Ammount
        /// </summary>
        /// <param name="products">List of bakery products</param>
        /// <returns>cloned and sorted list of bakery products</returns>
        public List<BakeryProduct> CloneAndSortByCaloriesAmount(List<BakeryProduct> products)
        {
            List<BakeryProduct> productsRes = new List<BakeryProduct>();

            foreach (BakeryProduct product in products)
            {
                BakeryProduct currentProduct;
                List<Ingredient> ingredients = new List<Ingredient>();
                if (product is BreadBakeryProduct) currentProduct = new BreadBakeryProduct();
                else currentProduct = new LoafBakeryProduct();


                foreach (Ingredient ingredient in product.Ingredients)
                    ingredients.Add(new Ingredient(ingredient.Name, ingredient.Weight, ingredient.Price, ingredient.CaloriesAmount));


                if (product.Ingredients != null) currentProduct.Ingredients = ingredients;

            }

            productsRes.Sort(new BakeryProductCaloriesComparer());

            return productsRes;
        }

        /// <summary>
        /// Copies and Sorts bakery products by price
        /// </summary>
        /// <param name="products">List of bakery products</param>
        /// <returns>copied and sorted list of bakery products</returns>
        public List<BakeryProduct> CopyAndSortByPriceAmount(List<BakeryProduct> products)
        {
            List<BakeryProduct> productsRes = new List<BakeryProduct>();

            foreach (BakeryProduct product in products)
            {
                BakeryProduct currentProduct;
                List<Ingredient> ingredients = new List<Ingredient>();
                if (product is BreadBakeryProduct) currentProduct = new BreadBakeryProduct();
                else currentProduct = new LoafBakeryProduct();


                foreach (Ingredient ingredient in product.Ingredients)
                    ingredients.Add(new Ingredient(ingredient.Name, ingredient.Weight, ingredient.Price, ingredient.CaloriesAmount));


                if (product.Ingredients != null) currentProduct.Ingredients = ingredients;

            }

            productsRes.Sort(new BakeryProductPriceComparer());

            return productsRes;
        }

        /// <summary>
        /// Takes products from list which are equal to product with Price and Calories
        /// </summary>
        /// <param name="products">list where to take</param>
        /// <param name="product">comparable product</param>
        /// <returns>resulting list of products</returns>
        public List<BakeryProduct> TakeWhereProductsIsEqualTo(List<BakeryProduct> products, BakeryProduct product)
        {
            return products
                .Where(a =>
                    a.GetPrice() == product.GetPrice() &&
                    a.GetCaloriesAmount() == product.GetCaloriesAmount())
                .ToList();
        }

        /// <summary>
        /// Takes products from list where comparable ingredient weight is higher than
        /// </summary>
        /// <param name="products">list where to take</param>
        /// <param name="ingredient">comparable ingredient</param>
        /// <param name="weight">comparable weight</param>
        /// <returns>resulting list of products</returns>
        public List<BakeryProduct> TakeWhereProductsWeightIsHigherThan(List<BakeryProduct> products, Ingredient ingredient, double weight)
        {
            return products.Where(prd =>
                                    prd.Ingredients.Where(ingr => ingr == ingredient).Sum(ingr => ingr.Weight) > weight)
                           .ToList();
        }

        /// <summary>
        /// Takes products from list where ingredients count is higher than
        /// </summary>
        /// <param name="products">list where to take</param>
        /// <param name="count">comparable count</param>
        /// <returns>resulting list of products</returns>
        public List<BakeryProduct> TakeWhereIngredientCountIsHigherThan(List<BakeryProduct> products, int count)
        {
            return products.Where(prd => prd.Ingredients.Count() > count).ToList();
        }

        #endregion

    }

}
