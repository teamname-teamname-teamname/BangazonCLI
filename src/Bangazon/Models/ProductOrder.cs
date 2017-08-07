namespace Bangazon.Models
{

//Class: OrderProduct
//Purpose: The OrderProduct class is used to store all order/product information (from the join table).
//Author: Jackie
//Properties:
//Id: A unique idetification number for each order 
//OrderId: The order created by the customer
//ProductId: The specific product included in this order

    public class ProductOrder
    {
        public int Id {get; set;}
        public int ProductId {get; set;}
        public int OrderId {get; set;}
    }
}