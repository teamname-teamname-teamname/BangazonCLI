using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
            
        /*
    Class: Customer Manager
    Purpose: This class is used to write implementation code for 
             tests in the Bangazon_CustomerManagerShould.cs file.
    Author: Dilshod 8/8, Joey 8/9, 8/10
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
        // Method will add customer to database
        public int AddCustomer (Customer newCustomer) 
        {
           int id = _db.Insert($"insert into customer values(null, '{newCustomer.firstName}', '{newCustomer.lastName}', '{newCustomer.address}', '{newCustomer.city}', '{newCustomer.state}', '{newCustomer.zipCode}', '{newCustomer.phoneNumber}')");
           return id;
        }

        // Method will return list of all customers in database
        public List<Customer> GetCustomerList()
        {
            _db.Query("select id, firstName, lastName, address, city, state, zipCode, phoneNumber from customer",
            (SqliteDataReader reader) =>{
                while(reader.Read())
                {
                    _customer.Add(new Customer(){
                        id = reader.GetInt32(0),
                        firstName = reader[1].ToString(),
                        lastName = reader[2].ToString(),
                        address = reader[3].ToString(),
                        city = reader[4].ToString(),
                        state = reader[5].ToString(),
                        zipCode = reader[6].ToString(),
                        phoneNumber = reader[7].ToString()  

                    });
                }
            });

            return _customer;
        }

        // Method will return single customer 
        
        public Customer GetCustomer (int id) => _customer.SingleOrDefault(cust => cust.id == id);   

    }
}