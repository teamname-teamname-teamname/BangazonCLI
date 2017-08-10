using System;
using System.Collections.Generic; 
using Bangazon.Models; 

namespace Bangazon.Actions 
{
    public class AddPayment
    {
        /*
            Class: AddPayment
            Purpose: This class will allow users to enter payment type information into the command line. The user input will be addd to the database. 
            Author: Joey
        */
        public static void AddPay(PaymentTypeManager payment)
        {
            Console.Clear();
            Console.WriteLine("Enter payment type(e.g. AmEx, Visa, Checking)");
            Console.Write(">");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter account number");
            Console.Write(">");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
        }
    }
}