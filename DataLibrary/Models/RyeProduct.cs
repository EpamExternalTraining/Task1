namespace DataLibrary.Models
{

    /// <summary>
    /// Class that describes RyeProduct
    /// </summary>
    public class RyeProduct : BakeryProduct
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RyeProduct(decimal markup = 50) : base() => Markup = markup;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the RyeProduct</param>
        /// <param name="markup">Markup of the RyeProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the RyeProduct</param>
        public RyeProduct(string name, decimal markup = 50, params Ingredient[] ingredients) : base(name, markup, ingredients) { }

        #endregion

    }

}
