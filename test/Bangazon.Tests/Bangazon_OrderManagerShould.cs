using System;
using Xunit;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class OrderManagerShould//: IDisposable
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
            _db.CheckProductOrderTable();
            _db.CheckProductTable();
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
            List<Order> orders = _om.GetOrders(); // Retrieve all orders as a List.
            foreach(Order o in orders) // Iterate through the list of orders.
            {
                Assert.IsType<Order>(o); // Assert that what is returned is a list of orders.
            }
            Assert.True(orders.Count > 0); // Checks if the order list has an order.
        }

        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
            bool payment = _om.AddPaymentTypeToOrder(1, 32); // First argument is Payment Type Id, second argument is Order Id
            Assert.True(payment);
        }

        [Fact]
        public void AddProductToOrderShould()
        {
            int prodOrdId = _om.AddProductToOrder(12, 32); // First argument is Product Id, second argument is Order Id
            Assert.IsType<int>(prodOrdId);
        }

        // public void Dispose()
        // {
        //     _db.Delete("DELETE FROM [order]");
        // }
    }
}
