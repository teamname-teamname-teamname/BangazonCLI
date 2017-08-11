using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;

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
        public static void DoAction(OrderManager om, ProductManager pm, CustomerManager cm)
        {
            // Get list of Products
            var products = pm.GetProductList();
            int counter;
            int chooseProduct;
            // Checks if there's an active customer. If not, kicks them to the main menu
            if (CustomerManager.activeCustomer == 0)
            {
                Console.Clear();
                Console.WriteLine("* Please choose an active customer before continuing *");
                Console.WriteLine("* Press 'ENTER' to return to the main menu *");
                Console.ReadLine();
            }
            else
            {
                int orderId;

                Order activeOrder = om.GetSingleOrder(CustomerManager.activeCustomer);
                List<Order> orders= om.GetOrders();

            
                foreach (Order order in orders)
                {
                    if (order.CustomerId == CustomerManager.activeCustomer && order.PaymentTypeId == null){
                        orderId = order.Id;
                    }
                }
                if (activeOrder.PaymentTypeId == null)
                {
                    orderId = activeOrder.Id;
                }
                else
                {
                    orderId = om.CreateOrder(CustomerManager.activeCustomer);
                }
                
                do{
                    Console.Clear();
                    counter = 1;
                    Console.WriteLine ("Choose a product to add to your cart");
                    foreach (var product in products)
                        {
                            Console.WriteLine($"{counter++}. {product.Name}");
                        }
                    Console.WriteLine($"Press {counter} to quit");
                    Console.Write ("> ");
                    chooseProduct = int.Parse(Console.ReadLine());
                    if (chooseProduct < counter){
                        om.AddProductToOrder(chooseProduct, orderId);
                    }
                }
                while (chooseProduct < counter);
            }
        }
    }
}