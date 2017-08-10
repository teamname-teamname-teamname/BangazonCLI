using System;
using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Managers;
using Xunit;

namespace Bangazon.Tests
{
    public class CustomerManagerShould : IDisposable
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

            int result = _cm.AddCustomer(newCustomer);
            Assert.IsType<int>(result);
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
        public void UserSelectsAnActiveCustomer()
        {
            var raf = CustomerManager.SelectActiveCustomer(1);
            Assert.IsType<int>(raf);
            Assert.True(raf > 0);
        }

        [Fact]
        public void UserSelectsSingleCustomer()
        {
            int cartier = _cm.AddCustomer(new Customer());
            Assert.IsType<int>(cartier);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }

    }
}
