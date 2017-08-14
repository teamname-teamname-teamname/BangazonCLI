using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;


namespace Bangazon.Actions
{
    /*
    Class: CreateProduct
    Purpose: Command Line interaction to build a new product to sell and add it to the database.
    Author: Ollie
     */
    public class CreateProduct
    {
        public static void DoAction(ProductManager productManager)
        {
            Console.Clear();
            // Checks if there's an active customer. If not, kicks them to the main menu
            if(CustomerManager.activeCustomer == 0)
            {
                Console.WriteLine("* Please choose an active customer before continuing *");
                Console.WriteLine("* Press 'ENTER' to return to the main menu *");
                Console.ReadLine();
            }else
            {
                // Enter in the necessary info to create a product
                Console.WriteLine("Enter product name");
                Console.Write ("> ");
                string name = Console.ReadLine();
                Console.Clear();
                
                //jk-Wrapped Product Price in a do while to loop through the statement unless certain condition is met, if price is not a valid input, catch the error and make user re-enter a valid price
                bool priceIsADouble = true;
                double price = 0;
                
                do{
                Console.WriteLine("Enter product price");
                Console.Write ("> ");
                string line = Console.ReadLine();
                //Console.WriteLine(line);
                    try
                    {
                        price = double.Parse(line);
                        priceIsADouble = true;
                    }
                    catch(FormatException)
                    {
                            Console.WriteLine("{0} is not a valid price", line);
                            Console.WriteLine("*Press 'ENTER' and re-enter a valid price*");
                            Console.ReadLine();
                            priceIsADouble = false;
                    }
                }while(priceIsADouble == false);

                //Console.Clear();
                Console.WriteLine("Enter product description");
                Console.Write ("> ");
                string description = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter product quantity");
                Console.Write ("> ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Thank you!");

                // Builds/Sends a new product to ProductManager where it gets added to the database
                int prodId = productManager.AddCustomerProduct(new Product()
                    {
                        Name = name,
                        Price = price,
                        Description = description,
                        Quantity = quantity,
                        CustomerId = CustomerManager.activeCustomer
                    }
                );

                Console.WriteLine($"Product Id: {prodId} successfully added!");
                Console.WriteLine("* Press 'ENTER' to return to the main menu *");
                Console.ReadLine();
            }
        }
    }
}