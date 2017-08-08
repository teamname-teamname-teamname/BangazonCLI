using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon //worked on by Dilshod 8/8
{
    public class CustomerManager
    {
        private List<Customer> _customer = new List<Customer>();
        private DatabaseInterface _db;

        public static int activeCustomer = 1;
    
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