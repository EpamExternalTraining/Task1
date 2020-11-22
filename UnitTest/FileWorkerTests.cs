using DataLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class FileWorkerTests
    {
        private readonly string _filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "products.txt");
        private readonly IProductFileWorker<BakeryProduct> _fileWorker = new BakeryProductFileWorker();


        


    }
}
