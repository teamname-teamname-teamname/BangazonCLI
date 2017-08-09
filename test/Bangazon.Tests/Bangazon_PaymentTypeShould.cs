using System;
using System.Collections.Generic;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{

    /*
    Class: PaymentTypeManager
    Purpose: This class is specifically used to test if a payment type can be added to a list,
             and to test if a list of payments will be returned once a payment has been added. 
             Added a new test for selecting a payment type in the command line.
    Author: Jackie
    */
    public class PaymentTypeShould
    {
        private readonly PaymentTypeManager _pt;
        private readonly DatabaseInterface _db;

        public PaymentTypeShould()
        {
            _db = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _pt = new PaymentTypeManager(_db);
            _db.CheckPaymentTypeTable();
        }

        [Fact]
        public void AddPaymentTypeShould()
        {
            PaymentType payment = new PaymentType();

            List<PaymentType> result = _pt.AddPaymentToList(payment);

            Assert.Contains(payment, result);
        }
        
        [Fact]
        public void GetPaymentTypeListShould()
        {
            _pt.AddPaymentToList(new PaymentType());
            
            List<PaymentType> payments = _pt.getListOfPayments();
            
            Assert.IsType<List<PaymentType>>(payments);
            
            Assert.True(payments.Count > 0);
        }

        [Fact]
        public void SelectingAPaymentTypeShould()
        {
            int paymentTypeId = _pt.SelectPaymentType(0);
            Assert.IsType<int>(paymentTypeId);
            Assert.True(paymentTypeId > 0);
        }

    }
}