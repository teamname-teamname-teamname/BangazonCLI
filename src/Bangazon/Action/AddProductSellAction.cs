using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;


namespace Bangazon.Actions
{
  public class CreateProduct
  {
    public static void DoAction(ProductManager register)
    {
        if(CustomerManager.activeCustomer == 0)
        {
            Console.WriteLine("Please choose an active customer before continuing");
        }else
        {
            Console.Clear();
            Console.WriteLine("Enter product name");
            Console.Write ("> ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price");
            Console.Write ("> ");
            double price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product description");
            Console.Write ("> ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter product quantity");
            Console.Write ("> ");
            int quantity = int.Parse(Console.ReadLine());
        }
    }
  }
}