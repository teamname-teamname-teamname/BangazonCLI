using System;
using System.Collections.Generic;
using Bangazon.Managers;
using Bangazon.Models;


namespace Bangazon.Actions
{
  public class CreateCustomer
  {
    public static void DoAction(CustomerManager registr)
    {
        Console.Clear();
        Console.WriteLine ("Enter customer first name");
        Console.Write ("> ");
        string firstName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine ("Enter customer last name");
        Console.Write ("> ");
        string lastName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine ("Enter customer city");
        Console.Write ("> ");
        string streetAddress = Console.ReadLine();
        Console.Clear();
        Console.WriteLine ("Enter customer state");
        Console.Write ("> ");
        string state = Console.ReadLine();
        Console.Clear();
        Console.WriteLine ("Enter customer postal code");
        Console.Write ("> ");
        int postalCode = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine ("Enter customer phone number");
        Console.Write ("> ");
    }
  }
}