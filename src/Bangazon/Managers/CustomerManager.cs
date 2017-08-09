using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon 
            
        /*
    Class: Customer Manager
    Purpose: This class is used to write implementation code for 
             tests in the Bangazon_CustomerManagerShould.cs file.
    Author: Dilshod 8/8, Joey 8/9
    */

{
    public class CustomerManager
    {
        private List<Customer> _customer = new List<Customer>();
        private DatabaseInterface _db; 
        public static int activeCustomer;

        public static int SelectActiveCustomer(int selectedCustomer)
        {
                 activeCustomer = 1;
                return  activeCustomer;
        }
    
        public CustomerManager(DatabaseInterface db)
        {
            _db = db;
        }
        public List<Customer> AddCustomer (Customer newCustomer) 
        {
            _customer.Add(newCustomer);
            
            return _customer;
        }

        public List<Customer> GetCustomerList ()
        {
            return _customer;
        }

        public int ReturnActiveCustomer ()
        {
            return activeCustomer; 
        }


    }
}