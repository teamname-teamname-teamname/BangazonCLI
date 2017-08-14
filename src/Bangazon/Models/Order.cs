namespace Bangazon.Models 
{

    /*
    Class: Order
    Purpose: The Order class is used to store all order information.
    Author: Jackie
    Properties:
        Id: A unique idetification number for each order.
        CustomerId: The customer who created/completed this order.
        PaymentTypeId: The specific payment that was used for this order.   This also indicates whether this is a current order, or a completed order. If the PaymentTypeId is null, the payment is current, if it has a value then the order has been completed by the user.
    */

    public class Order
    {
        public int Id {get; set;}
        public int? PaymentTypeId {get; set;}
        public int CustomerId {get; set;}

    }

}