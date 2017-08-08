using System; 
using System.Collections.Generic;
using Bangazon.Models;
using Xunit; 

namespace Bangazon.Tests //worked on by Joey 8/8
{
    public class CustomerIsActive
    {
        private readonly CustomerManager _cm;
        private readonly DatabaseInterface _db;
        public CustomerIsActive()
        {
            _db = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _cm = new CustomerManager(_db);
            _db.CheckCustomerTable();
        }

        [Fact]
        public void AllActiveCustomers()
        {
            int gucci = _cm.ReturnActiveCustomer();           
            Assert.True(gucci > 0);       
        }

        
    }
}