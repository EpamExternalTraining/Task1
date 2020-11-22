namespace DataLibrary.Models
{

    /// <summary>
    /// Class that describes WheatProduct
    /// </summary>
    public class LoafBakeryProduct : BakeryProduct
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public LoafBakeryProduct(decimal markup = 10):base() => Markup = markup;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the LoafBakeryProduct</param>
        /// <param name="markup">Markup of the LoafBakeryProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the LoafBakeryProduct</param>
        public LoafBakeryProduct(string name, decimal markup = 10, params Ingredient[] ingredients) : base(name, markup, ingredients) { }

        #endregion

    }

}
