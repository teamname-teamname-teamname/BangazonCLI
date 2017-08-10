using System;
using System.Collections.Generic; 
using Bangazon.Managers;
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
                    //Checks if there's an active customer 
                    if(CustomerManager.activeCustomer == 0)
                    {
                        Console.WriteLine("* Please choose an active customer before continuing *");
                        Console.WriteLine("* Press 'ENTER' to return to the main menu *");
                        Console.ReadLine();
                    }else
                    {
                        // Enter in the necessary info to create a product
                    Console.WriteLine("Enter payment type(e.g. AmEx, Visa, Checking)");
                    Console.Write(">");
                    string name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter account number");
                    Console.Write(">");
                    int accountNumber = Convert.ToInt32(Console.ReadLine());
            
                // Builds/Sends a new payment type, where it gets added to the PaymentManager
                int payType = payment.AddPayment(new PaymentType()
                    {
                        Name = name, 
                        CustomerId = CustomerManager.activeCustomer,
                        AccountNumber = accountNumber
                    }
                
                );

                Console.WriteLine($"Payment Type: {payType} has been added to the menu!");
                Console.WriteLine("* Press 'ENTER' to return to the main menu *");
                Console.ReadLine();
            }
        }
    }
}