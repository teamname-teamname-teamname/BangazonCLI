using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
{
    /*
    Class: OrderManager
    Purpose: This class is used to write implementation code for tests in the Bangazon_OrderManagerShould.cs file.
    Author: Dilshod
    */
    public class OrderManager
    {
        private List<Order> _order = new List<Order>();
        private DatabaseInterface _db;
        
        public OrderManager(DatabaseInterface db)
        {
            _db = db;
            _order = new List<Order>();
        }

        // This method will create a new order 
        public int CreateOrder (int custId)
        {
            int id = _db.Insert( $"INSERT INTO [order] VALUES (null, {custId}, null)");
            _order.Add(
                new Order()
                {
                    Id = id,
                    PaymentTypeId = null,
                    CustomerId = CustomerManager.activeCustomer
                }
            );
            return id;
        }

        // Return a List of All Orders
        public List<Order> GetOrders()
        {
            _db.Query($"SELECT id, customerId, paymentTypeId FROM [order]", 
                (SqliteDataReader reader) => {
                    _order.Clear();
                    while (reader.Read())
                    {
                        _order.Add(
                            new Order(){
                                Id = reader.GetInt32(0),
                                PaymentTypeId = reader.IsDBNull(reader.GetOrdinal("paymentTypeId")) ? (int?) null : reader.GetInt32(2),
                                CustomerId = reader.GetInt32(1),
                            }
                        );
                    }
                }
            );
            return _order;
        }


        // Return a single order
        public Order GetSingleOrder (int id) => _order.SingleOrDefault(ord => ord.CustomerId == id);

        // Add a payment to the null field "payment" in an order, return true once complete
        public bool AddPaymentTypeToOrder(int payTypeId, int orderId)
        {
            _db.Update($"UPDATE [order] SET PaymentTypeId = {payTypeId} WHERE [order].Id = {orderId}");
            return true;
        }


        // Add a product by productId to an order by orderId return the index of the item added to the productorder join table
        public int AddProductToOrder(int prodId, int orderId)
        {
            int prodOrdId = _db.Insert($"INSERT INTO productOrder VALUES (null, {prodId}, {orderId})");
            return prodOrdId;
        }

        /*  
            Author: Ollie
            Calls GetOrders and stores each order in a list. Then searches that list for an existing order for the active customer. If there is one AND the PaymentTypeId is null (meaning the order is incomplete). It returns that order id. Else it returns 0.
        */
        public int CheckActiveOrder()
        {
            List<Order> orders= GetOrders();
            
                foreach (Order order in orders)
                {
                    if (order.CustomerId == CustomerManager.activeCustomer && order.PaymentTypeId == null)
                    {
                        return order.Id;
                    }
                }
            return 0;
        }
    }
}