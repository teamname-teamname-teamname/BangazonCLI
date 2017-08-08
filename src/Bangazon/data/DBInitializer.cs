using System;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon.Data //worked on by Joey & Jackie, August 7th
{
    public static class DBInitializer{
        public static void Iniitialize(DatabaseInterface db){
            bool customerExist = false; 
            db.Query($"select id from customer",
            (SqliteDatatReader reader) => {
                while(reader.Read())
                {   
                   customerExist = true; 
                }
                if(customerExist = false)
                {
                    db.BulkInsert($@"
                        insert into customer values (null, "Bobby", "Schmurda", "Rykers Island", "Brooklyn", "New York", "12345", "123-456-7890" );
                    ");
                }
            });
            }

        }
    }
}