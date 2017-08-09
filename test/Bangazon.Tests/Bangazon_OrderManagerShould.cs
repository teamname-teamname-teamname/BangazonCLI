using System;
using Xunit;
using Bangazon.Models;

namespace Bangazon.Tests
{
    public class OrderManagerShould: IDisposable
    {

        private readonly OrderManager _om;
        private readonly DatabaseInterface _db;

        public OrderManagerShould()
        {
            _db = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _om = new OrderManager(_db);
            _db.CheckOrderTable();
            _db.CheckCustomerTable();
            _db.CheckPaymentTypeTable();
        }

        [Fact]
        public void CreateNewOrderShould()
        {
            Customer customer = new Customer();
            int id = _om.CreateOrder(customer);
            Assert.IsType<int>(id);
        }

        [Fact]
        public void ListOrders()
        {

        }

        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
            var payment = _om.AddPaymentTypeToOrder(1, 18);
            Assert.True(payment);
        }

        [Fact]
        public void AddProductToOrderShould()
        {
            int prodOrdId = _om.AddProductToOrder(12, 23);
            Assert.True(prodOrdId > 0);
        }

        public void Dispose()
        {
            
            _db.Delete("DELETE FROM [order]");
        }
    }
}
