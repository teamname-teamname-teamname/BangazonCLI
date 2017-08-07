using System;
using System.Linq;
using Bangazon.Models;
using System.Threading.Tasks; 

namespace Bangazon.Data //worked on by Joey & Jackie, August 7th
{
    public static class DBInitializer{
        public static void Iniitialize(IServiceProvider serviceProvider){
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>()))
            {
                if(context.Customer.Any())
                {
                    return; //database is good
                }
                var customer = new Customer[]
                {
                    new Customer{
                        firstName = "Bobby",
                        lastName = "Schmurda",
                        address = "Ryker's Island",
                        city = "Brooklyn",
                        state = "NY",
                        zipCode = 12345, 
                        phoneNumber = "123-456-7891"
                    },
                    new Customer{
                        firstName = "Playboi",
                        lastName = "Carti",
                        address = "1 Main Street",
                        city = "Atlanta",
                        state = "GA",
                        zipCode = 54321, 
                        phoneNumber = "123-456-7891"
                    },
                    new Customer{
                        firstName = "Ski Mask",
                        lastName = "the Slump God",
                        address = "2 Main Street",
                        city = "Miami", 
                        state = "FL",
                        zipCode = 09876,
                        phoneNumber = "123-456-7713"
                    },
                    new Customer{
                        firstName = "Pusha", 
                        lastName = "T",
                        address = "3 Main Street", 
                        city = "Virginia Beach", 
                        state = "VA", 
                        zipCode = 12356,
                        phoneNumber = "345-677-0229"
                        
                    }
                };
                foreach(Customer i in customer)
                {
                    context.Customer.Add(i);
                }
                context.SaveChanges();
            }

        }
    }
}