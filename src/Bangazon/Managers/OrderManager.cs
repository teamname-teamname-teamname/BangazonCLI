using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class OrderManager
    {
        private List<Order> _order = new List<Order>();
        private DatabaseInterface _db;
        
        public OrderManager(DatabaseInterface db)
        {
            _db = db;
        }

        public int CreateOrder (Customer customer)
        {
            int id = _db.Insert( $"INSERT INTO [order] VALUES (null, {customer.id}, null)");
            _order.Add(
                new Order()
                {
                    Id = id,
                    PaymentTypeId = null,
                    CustomerId = customer.id
                }
            );
            return id;
        }

        public bool AddPaymentTypeToOrder(int payTypeId, int orderId)
        {
            _db.Update($"UPDATE [order] SET PaymentTypeId = {payTypeId} WHERE [order].Id = {orderId}");
            return true;
        }

        public int AddProductToOrder(int prodId, int orderid)
        {
            return 19;
        }
    }
}