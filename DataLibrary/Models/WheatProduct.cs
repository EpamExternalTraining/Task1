namespace DataLibrary.Models
{

    /// <summary>
    /// Class that describes WheatProduct
    /// </summary>
    public class WheatProduct : BakeryProduct
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public WheatProduct(decimal markup = 10):base() => Markup = markup;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the WheatProduct</param>
        /// <param name="markup">Markup of the WheatProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the WheatProduct</param>
        public WheatProduct(string name, decimal markup = 10, params Ingredient[] ingredients) : base(name, markup, ingredients) { }

        #endregion

    }

}
