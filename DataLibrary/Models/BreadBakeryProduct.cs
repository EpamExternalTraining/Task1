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
        public BreadBakeryProduct() : base() => Markup = 50;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the BreadBakeryProduct</param>
        /// <param name="ingredients">Ingredients which are requiered to bake the BreadBakeryProduct</param>
        public BreadBakeryProduct(string name, params Ingredient[] ingredients) : base(name, 50, ingredients) { }

        #endregion

    }

}
