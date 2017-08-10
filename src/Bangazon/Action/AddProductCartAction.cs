using System;
using System.Collections.Generic;
using Bangazon.Managers;

namespace Bangazon.Actions
{
    public class AddProductCart
    {
        /*
        Class:   AddProductCart
        Purpose: method that is called from Program.cs switch case: 5
                 accepts 3 arguments
                 first argument is an Instance of the Class ProductManager
                 second argument is an Instance of the Class OrderManager
                 third is the CustomerId that was selected and stored from switch case: 2
                 Assigns the product to the productOrder table
        Author:  Dilshod
        */
        public static void DoAction(OrderManager om, ProductManager pm, int custId)
        {
            // Get list of Products
            var products = pm.GetProductList();
            int chooseCustomer;
            int counter;
            do {
                counter = 1;
                Console.Clear();
                Console.WriteLine ("Choose a product to add to your cart");
                foreach (var product in products)
                    {
                        Console.WriteLine($"{counter++}. {product.Name}");
                    }
                Console.WriteLine($"Press {counter} to quit");
                Console.Write ("> ");
                chooseCustomer = int.Parse(Console.ReadLine());
            } while (chooseCustomer < counter);
        }
    }
}