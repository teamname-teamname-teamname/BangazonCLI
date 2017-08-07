using System;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class CustomerManagerShould: IDisposable
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
        public void AddNewCustomer()
        {
            Customer newCustomer = new Customer();

            var result = _cm.AddCustomer(newCustomer);
            Assert.True(result != 0);
        }

        [Fact]
        public void ListCustomers()
        {

        }

        public void Dispose()
        {
            // _db.Delete("DELETE FROM customer");
        }
    }
}
