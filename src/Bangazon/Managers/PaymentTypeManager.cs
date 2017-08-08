using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _payment = new List<PaymentType>();
        private DatabaseInterface _db;

        public PaymentTypeManager(DatabaseInterface db)
        {
            _db = db;
        }

           public List<PaymentType> AddPaymentTypeToCustomer (PaymentType payment) 
        {
            _payment.Add(payment);
            
            return _payment;
        }
    }
}