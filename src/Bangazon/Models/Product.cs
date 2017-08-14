namespace Bangazon.Models
{
    /*
    Class: Product
    Purpose: The Product class is used to store all product information
    Author: Teamname-Teamname-Teamname
    Properties:
        ProductId: A unique idetification number for each product
        ProductTypeId: The unique identification number of the product type associated with this product
        Product Type: The name of the product type
        Price: The price of the specified product
        Title: The name of the specified product
        Description: A short description of the specified product
        CustomerId: The unique identification number for the customer
        Customer: The customer information
        OrderProducts: A collection of OrderProducts to allow database traversing
 */
    public class Product
    {
       public int? Id {get; set;}
       public string Name {get; set;}
       public int CustomerId {get; set;}
       public double Price {get; set;}
       public int Quantity {get; set;}
       public string Description {get; set;}
    }
}