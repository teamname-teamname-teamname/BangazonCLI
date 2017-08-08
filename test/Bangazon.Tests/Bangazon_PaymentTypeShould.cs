using System;
using System.Collections.Generic;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class PaymentTypeShould
    {
        private readonly PaymentTypeManager _pt;
        private readonly DatabaseInterface _db;

        public PaymentTypeShould()
        {
            _db = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _pt = new PaymentTypeManager(_db);
            //_db.CheckPaymentTypeTable();
        }

        [Fact]
        public void AddPaymentTypeShould()
        {
            PaymentType payment = new PaymentType();

            List<PaymentType> result = _pt.AddPaymentTypeToCustomer(payment);

            Assert.Contains(payment, result);
        }
    }
}