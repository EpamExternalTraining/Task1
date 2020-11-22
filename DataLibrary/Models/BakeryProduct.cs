using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.Models
{

    /// <summary>
    /// Abstract class that describes BakeryProduct
    /// </summary>
    public abstract class BakeryProduct
    {

        #region Fields

        /// <summary>
        /// Ingredients which are requiered to bake the BakeryProduct
        /// </summary>
        public IEnumerable<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Markup of the BakeryProduct; 
        /// Indicated as a percentage
        /// </summary>
        public decimal Markup { get; set; }

        /// <summary>
        /// Name of the BakeryProduct
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors


        /// <summary>
        /// Constructor
        /// </summary>
        public BakeryProduct() 
        {
            Name = "Unknown";
            Markup = 0;
            Ingredients = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="markup">Markup of the BakeryProduct</param>
        /// <param name="name">Name of the BakeryProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the BakeryProduct</param>
        public BakeryProduct(string name, decimal markup, params Ingredient[] ingredients)
        {
            Ingredients = ingredients;
            Markup = markup;
            Name = name;
        }

        #endregion

        #region Methods 

        /// <summary>
        /// Calculates and returns calories amount of the BakeryProduct
        /// </summary>
        /// <returns>Calories amount of the BakeryProduct</returns>
        public virtual double GetCaloriesAmount() => Ingredients.Sum(a => a.CaloriesAmount);

        /// <summary>
        /// Calculates and returns price of the BakeryProduct
        /// </summary>
        /// <returns></returns>
        public virtual decimal GetPrice() => Ingredients.Sum(a => a.Price) * (1 + Markup/100);



        /// <summary>
        /// Determines whether the specified BakeryProduct is equal to the current BakeryProduct.
        /// </summary>
        /// <param name="obj">The BakeryProduct to compare with the current BakeryProduct.</param>
        /// <returns>true if the specified BakeryProduct is equal to the current BakeryProduct; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            BakeryProduct other = obj as BakeryProduct;

            bool Answer = other != null;
            if (!Answer) return Answer;

            Answer &= this.Markup.Equals(other.Markup);
            Answer &= this.Name.Equals(other.Name);
            Answer &= this.Ingredients.SequenceEqual(other.Ingredients);

            return Answer;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current BakeryProduct.</returns>
        public override int GetHashCode()
        {
            int hashCode = -3379;
            hashCode = hashCode * 9973 + Name.GetHashCode();
            hashCode = hashCode * 9973 + Markup.GetHashCode();

            foreach(Ingredient ingredient in Ingredients)
            {
                hashCode = hashCode * 9973 + ingredient.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current BakeryProduct.
        /// </summary>
        /// <returns>A string that represents the current BakeryProduct.</returns>
        public override string ToString()
        {
            return $"{Name}; {Markup}%; " + 
                Ingredients.Aggregate<Ingredient, string>
                (
                    "", 
                    (res, a) => res + a
                );
        }

        #endregion

    }

}
