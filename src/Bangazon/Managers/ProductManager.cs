using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    /*
    Class: ProductManager
    Purpose: The ProductManager class is used to interact with the user and the database during actions pertaining to the 'Product' table.
    Author: Ollie
    Properties:
        AddCustomerProduct: Allows user to add a product the customer wants to sell to the database.
        GetProductList: Returns a list of all products from the system and displays them in the command line. User can then select a product to add to the shopping cart.
        SelectProduct(int productMenuNum): Allows the user to select a product from the list and returns the corresponding product id from the database.
     */
    public class ProductManager
    {
        private DatabaseInterface _db;
        
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }

        private List<Product> _products = new List<Product>();

        /* Adds a new product to the database.
        Requires an object:
        {
            id: null,
            name: "string",
            customerId: CustomerManager.ActiveCustomer,
            price: 12.99,
            quantity: 300,
            description: "description of item"
        }
        */
        public void AddCustomerProduct(Product newProduct)
        {
            _products.Add(newProduct);
        }

        /* Returns a list of all products. Displays them in the CLI in a numbered fashion
            i.e.   `1. Basketball
                    2. Silly Putty
                    3. etc.`
        */
        public List<Product> GetProductList()
        {
            return _products;
        }

        // Requires an int productMenuNum from the CLI (user types in menu number of product, e.g. 1 for 'Basketball'). Uses that int to select the corresponding product from the database. Returns that products id.
        public int SelectProduct(int productMenuNum)
        {
            return 1;
        }
    }
}