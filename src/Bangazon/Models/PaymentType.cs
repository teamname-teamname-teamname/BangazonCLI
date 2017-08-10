namespace Bangazon.Models
{
    /*
    Class: PaymentType
    Purpose: The PaymentType class is used to store all payment type information.
    Author: Ollie
    Properties:
    Id: A unique idetification number for each payment type
    CustomerId: The customer who created/completed this payment type
    AccountNumber: The account number associated with this payment type (i.e. bank account, or credit card number)
    Name: The name of this payment type
    */
    public class PaymentType
    {
        public int id {get; set;}
        public int AccountNumber {get; set;}
        public string Name {get; set;}
        public int CustomerId {get; set;}
    }
}