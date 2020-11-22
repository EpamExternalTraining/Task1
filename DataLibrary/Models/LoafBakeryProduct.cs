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
        public LoafBakeryProduct():base() => Markup = 10;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the LoafBakeryProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the LoafBakeryProduct</param>
        public LoafBakeryProduct(string name, params Ingredient[] ingredients) : base(name, 10, ingredients) { }

        #endregion

    }

}
