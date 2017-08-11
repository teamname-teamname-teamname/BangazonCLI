using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;

namespace Bangazon.Actions

    /*
    Class: ChooseCustomer
    Purpose: This class is used for command line interaction. When a user selects
             2. Choose active customer, a list of customers from the database will
             be displayed and user will be able to select a customer based on id.
    Author: Jackie 8/10
    */

{
    public class ChooseCustomer
    {
        public static int DoAction(CustomerManager cm)
        {
            Console.Clear();
            Console.WriteLine("Please Choose A Customer");

            //jk-Call list of all customers from CustomerManager.cs
            List<Customer> customers = cm.GetCustomerList();

            int counter = 1;
            int chooseID = 0;

            foreach(Customer c in customers)
            {
                Console.WriteLine($"{counter}. {c.firstName} {c.lastName}");
                counter++;
            }

            Console.Write("> ");

            //jk-This will return an integer equivalent to the string in the command line
            int id = int.Parse(Console.ReadLine());
            
            //jk-This will go through the list of customers pulled back and grab the number that was selected minus 1 to grab the index for customer id
            chooseID = id - 1;
            Console.WriteLine($"You chose: {customers[chooseID].firstName} {customers[chooseID].lastName}");
            Console.WriteLine("* Press 'ENTER' to return to the main menu *");
            Console.ReadLine();
            
            //jk-This will set the active customer to the id chosen
            CustomerManager.activeCustomer = id;
            return chooseID;
        }
    }
}