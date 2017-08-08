using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class ProductManager
    {
        private DatabaseInterface _db;
        
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }

        private List<Product> _products = new List<Product>();

        public void AddCustomerProduct(Product newProduct)
        {
            _products.Add(newProduct);
        }

        public List<Product> GetProductList()
        {
            return _products;
        }
    }
}