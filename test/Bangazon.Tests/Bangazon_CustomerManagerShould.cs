using System;
using System.Collections.Generic;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class CustomerManagerShould
    {
        private readonly CustomerManager _cm;
        private readonly DatabaseInterface _db;
        public CustomerManagerShould()
        {
            _db = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _cm = new CustomerManager(_db);
            _db.CheckCustomerTable();
        }

        [Fact]
        public void AddCustomerShould()
        {
            Customer newCustomer = new Customer();

            List<Customer> result = _cm.AddCustomer(newCustomer);
            Assert.Contains(newCustomer, result);
        }

        [Fact]
        public void GetCustomerListShould()
        {
            _cm.AddCustomer(new Customer());
            List<Customer> customers = _cm.GetCustomerList();
            Assert.IsType<List<Customer>>(customers);
            Assert.True(customers.Count > 0);
        }

        [Fact]
        public void AllActiveCustomers()
        {
            int gucci = _cm.ReturnActiveCustomer();           
            Assert.True(gucci > 0);       
        }

    }
}
