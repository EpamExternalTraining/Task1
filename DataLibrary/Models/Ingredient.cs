namespace DataLibrary.Models
{

    /// <summary>
    /// Class that describes Ingredient
    /// </summary>
    public class Ingredient
    {

        #region Fields

        /// <summary>
        /// Calories amount of the Ingredient
        /// </summary>
        public double CaloriesAmount { get; set; }

        /// <summary>
        /// Price of the Ingredient
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Weight of the Ingredient
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Name of the Ingredient
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Ingredient() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="caloriesAmount">Calories amount of the Ingredient</param>
        /// <param name="price">Price of the Ingredient</param>
        /// <param name="name">Name of the Ingredient</param>
        /// <param name="weight">Weight of the Ingredient</param>
        public Ingredient(string name, double weight, decimal price, double caloriesAmount)
        {
            CaloriesAmount = caloriesAmount;
            Price = price;
            Name = name;
            Weight = weight;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified Ingredient is equal to the current Ingredient.
        /// </summary>
        /// <param name="obj">The Ingredient to compare with the current Ingredient.</param>
        /// <returns>true if the specified Ingredient is equal to the current Ingredient; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            Ingredient other = obj as Ingredient;

            bool Answer = other != null;
            if (!Answer) return Answer;

            Answer &= this.CaloriesAmount.Equals(other.CaloriesAmount);
            Answer &= this.Price.Equals(other.Price);
            Answer &= this.Name.Equals(other.Name);

            return Answer;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current Ingredient.</returns>
        public override int GetHashCode()
        {
            int hashCode = -3379;
            hashCode = hashCode * 9973 + CaloriesAmount.GetHashCode();
            hashCode = hashCode * 9973 + Price.GetHashCode();
            hashCode = hashCode * 9973 + Name.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current Ingredient.
        /// </summary>
        /// <returns>A string that represents the current Ingredient.</returns>
        public override string ToString()
        {
            return $"{Name}; {Weight}гр; {Price}р; {CaloriesAmount}Дж; ";
        }

        #endregion

    }

}