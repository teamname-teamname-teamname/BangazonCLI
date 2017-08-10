using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{

    /*
    Class: PaymentTypeManager
    Purpose: This class is used to write implementation code for 
             tests in the Bangazon_PaymentTypeShould.cs file.
    Author: Jackie
    */
    public class PaymentTypeManager
    {
        private List<PaymentType> _payment = new List<PaymentType>();
        private DatabaseInterface _db;

        public PaymentTypeManager(DatabaseInterface db)
        {
            _db = db;
        }

        //This method will add a payment to a list of Payment Types then return the list with added Payment Type.
           public List<PaymentType> AddPaymentToList (PaymentType payment) 
        {
            _payment.Add(payment);
            
            return _payment;
        }
        
        //This method will return the list of payments types.
        public List<PaymentType> getListOfPayments()
        {
            return _payment;
        }

        //This method is for selecting a payment type in the command line. Need to pass
        //in an integer so user will be able to select the payment by the specific number.
        public int SelectPaymentType(int paymentTypeNumber)
        {
            return 2;
        }
    }
}