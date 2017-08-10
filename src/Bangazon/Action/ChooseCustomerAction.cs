using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;

namespace Bangazon.Actions
{
    public class ChooseCustomer
    {
        public static void DoAction(CustomerManager cm)
        {
            Console.Clear();
            Console.WriteLine("Please Choose A Customer");
            List<Customer> customers = cm.GetCustomerList();

            foreach(Customer c in customers)
            {
                Console.WriteLine($"{c.id}. {c.firstName} {c.lastName}");
            }

            Console.Write("> ");
            int id = int.Parse(Console.ReadLine());
        }
    }
}