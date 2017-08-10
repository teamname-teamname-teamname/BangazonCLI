// Class: Customer
// Purpose: The Customer class is used to store all customer information.
// Author: Dilshod
// Properties:
// Id: A unique idetification number for each customer
// CustomerName:
// CustomerInfo: 

namespace Bangazon.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }

    }
}