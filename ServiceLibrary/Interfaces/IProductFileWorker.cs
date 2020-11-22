using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiceLibrary.Interfaces
{

    /// <summary>
    /// Interface for reading/writing products to file
    /// </summary>
    /// <typeparam name="T">Product</typeparam>
    public interface IProductFileWorker<T>
    {

        #region Methods

        /// <summary>
        /// Read and returns List of Product from file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>List of BakeryProduct</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        List<T> ReadFromFile(string filePath);

        /// <summary>
        /// Write to file List of Product
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="products">List of BakeryProduct for writing to file</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        void WriteToFile(string filePath, List<T> products);

        #endregion

    }

}
