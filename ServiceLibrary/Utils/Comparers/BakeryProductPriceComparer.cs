using DataLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ServiceLibrary.Utils.Comparers
{
    internal class BakeryProductPriceComparer : IComparer<BakeryProduct>
    {
        public int Compare([AllowNull] BakeryProduct x, [AllowNull] BakeryProduct y)
        {
            return x.GetPrice().CompareTo(y.GetPrice());
        }
    }
}