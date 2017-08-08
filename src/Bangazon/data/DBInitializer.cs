using System;
using Bangazon.Models;
using Microsoft.Data.Sqlite; 

namespace Bangazon.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseInterface dab)
        {
            bool customersExist = false; 
            dab.Query($"select id from customer",
            (SqliteDataReader reader) => {
                while(reader.Read())
                {
                    customersExist = true; 
                }
                if(customersExist == false)
                {
                    dab.BulkInsert($@"
                        insert into customer values(1, 'Bobby', 'Schmurda', 'Rykers Island', 'Brooklyn', 'NY', '12345', '555-555-5555');
                        insert into customer values(2, 'Lil', 'Pump', '2 Main St.', 'Miami', 'FL', '23456', '555-555-5551');
                        insert into customer values(3, 'Smoke', 'Purpp', '3 Main St.', 'Miami', 'FL', '34567', '555-555-5552');

                        insert into order values(null, 1);
                        insert into order values(null, 2);
                        insert into order values(null, 3);

                        insert into paymentType values(null, 'Cash', 1, 12);
                        insert into paymentType values(null, 'Visa', 2, 13);
                        insert into paymentType values(null, 'MasterCard', 3, 14);

                        instert into product(null, 'Codine Cough Syrup', 3, 12.99, 1, 'Goes great with Sprite!');
                        instert into product(null, 'SoundCloud Subscription', 2, 9.99, 2, 'Where all the good hip hop is at');
                        instert into product(null, 'Soccer Ball', 1, 10.99, 3, 'Kick goals with it!');

                        insert into productOrder(null, 1, 2);
                        insert into productOrder(null, 2, 1);
                        insert into productOrder(null, 3, 3);
                    ");
                }
            });
        }
    }
}
