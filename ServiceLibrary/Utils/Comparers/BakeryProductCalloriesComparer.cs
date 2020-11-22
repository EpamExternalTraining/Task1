using DataLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ServiceLibrary.Utils.Comparers
{
    internal class BakeryProductCaloriesComparer : IComparer<BakeryProduct>
    {
        public int Compare([AllowNull] BakeryProduct x, [AllowNull] BakeryProduct y)
        {
            return x.GetCaloriesAmount().CompareTo(y.GetCaloriesAmount());
        }
    }
}