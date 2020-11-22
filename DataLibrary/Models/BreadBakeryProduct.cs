namespace DataLibrary.Models
{

    /// <summary>
    /// Class that describes BreadBakeryProduct
    /// </summary>
    public class BreadBakeryProduct : BakeryProduct
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BreadBakeryProduct(decimal markup = 50) : base() => Markup = markup;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the BreadBakeryProduct</param>
        /// <param name="markup">Markup of the BreadBakeryProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the BreadBakeryProduct</param>
        public BreadBakeryProduct(string name, decimal markup = 50, params Ingredient[] ingredients) : base(name, markup, ingredients) { }

        #endregion

    }

}
