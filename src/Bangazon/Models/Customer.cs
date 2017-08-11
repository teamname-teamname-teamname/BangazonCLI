

namespace Bangazon.Models
{
    /*
    Class: Customer
    Purpose: The Customer class is used to store all customer information.
    Author: Dilshod
    Properties:
        id: A unique idetification number for each customer
        firstName: First name of customer.
        lastName: Last name of customer.
        address: Street address of customer.
        city: City of customer.
        state: State of customer.
        zipCode: Zip code of customer.
        phoneNumber: Phone number of customer. 
    */
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