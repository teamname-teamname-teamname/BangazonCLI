using System;
using Bangazon.Models;
using Microsoft.Data.Sqlite; 

namespace Bangazon
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
                        insert into customer values(null, 'Bobby', 'Schmurda', 'Rykers Island', 'Brooklyn', 'NY', '12345', '555-555-5555');
                        insert into customer values(null, 'Lil', 'Pump', '2 Main St.', 'Miami', 'FL', '23456', '555-555-5551');
                        insert into customer values(null, 'Smoke', 'Purpp', '3 Main St.', 'Miami', 'FL', '34567', '555-555-5552');

                        insert into paymentType values(null, 12, 'Cash', 1);
                        insert into paymentType values(null, 13, 'Visa', 2);
                        insert into paymentType values(null, 14, 'MasterCard', 3);

                        insert into [order] values (null, 1, 1);
                        insert into [order] values(null, 2, 2);
                        insert into [order] values(null, 3, 3);

                        insert into product values (null, 'Codine Cough Syrup', 3, 12.99, 1, 'Goes great with Sprite!');
                        insert into product values (null, 'SoundCloud Subscription', 2, 9.99, 2, 'Where all the good hip hop is at');
                        insert into product values (null, 'Soccer Ball', 1, 10.99, 3, 'Kick goals with it!');

                        insert into productOrder values (null, 1, 2);
                        insert into productOrder values (null, 2, 1);
                        insert into productOrder values (null, 3, 3);
                    ");
                }
            });
        }
    }
}
